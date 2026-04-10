/* CLASS: CMPT 291
 * LAB: X02L
 * ASSIGNMENT: RENTAL DATABASE PROJECT
 * AUTHOR(S): TEAM 5 - FIN, CHRISTIAN, BRICE, PIERRE
 * DUE DATE: APRIL 10TH 2025
 */
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MovieRental_Team5
{
    public partial class Order_Form : Form
    {
        private readonly string connection_string = Database_Connection.connection_string;
        // loading the form and its components.
        public Order_Form()
        {
            InitializeComponent();
            Load += order_form_load;
            back_button.Click += back_button_Click;
            record_order_button.Click += record_order_button_Click;
            button1.Click += clear_order_button_Click;
            comboBox2.SelectedIndexChanged += combo_box_2_selected_index_changed;
        }

        private void order_form_load(object sender, EventArgs e)
        {
            /*@desc
             * this functions purpose load the 
             * components of the order form and but checks if the employee is logged in or not first.
             * 
             */
            if (!Access_Control.ensure_employee_logged_in(this))
            {
                return;
            }

            load_customers();
            load_orders();
            set_employee_label();
            clear_order_fields();
        }

        private void load_customers()
        {
            /*@desc
             * this functions purpose
             * is to load the customers into the selection box 
             * Formats the customers by ID, first, ands last name
             * It also has error handling incase there is an issue with loading the customers from the database.
             * 
             */
            comboBox2.Items.Clear();

            try
            {
                using (SqlConnection conn = new SqlConnection(connection_string))
                {
                    conn.Open();
                    string query = "SELECT Customer_ID, First_Name, Last_Name FROM Customer_Data ORDER BY Last_Name, First_Name";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int customerId = Convert.ToInt32(reader["Customer_ID"]);
                        string customerName = customerId + " - " + reader["First_Name"] + " " + reader["Last_Name"];
                        comboBox2.Items.Add(new Order_Lookup_Item(customerId, customerName));
                    }
                }

                if (comboBox2.Items.Count > 0)
                {
                    comboBox2.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error loading customers: " + ex.Message);
            }
        }

        private int? get_selected_customer_id()
            // returns the selected customer ID from the combo box.
        {
            return comboBox2.SelectedItem is Order_Lookup_Item customer_item ? customer_item.Id : null;
        }

        private Order_Lookup_Item? get_next_available_queued_movie(SqlConnection conn, int customer_id)
        {
            /*@desc
             * this function checks the available movies in the customer queue
             * then it'll return the next available movie that the customer should rent based on the position and movie ID.
             * Using a string query, it checks the movie queue and movie data to find the next available movie.
             * It checks the availability of the movie by comparing the number of copies to the count of orders. 
             */
            string query = @"
                SELECT TOP 1
                    m.Movie_ID,
                    m.Movie_Name
                FROM Movie_Queue mq
                INNER JOIN Movie_Data m ON mq.Movie_ID = m.Movie_ID
                WHERE mq.Customer_ID = @customerId
                  AND m.Num_Copies >
                  (
                      SELECT COUNT(*)
                      FROM Order_Data o
                      WHERE o.Movie_ID = m.Movie_ID
                        AND o.Return_Date > GETDATE()
                  )
                ORDER BY mq.Queue_Position, m.Movie_ID";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@customerId", customer_id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        return null;
                    }

                    int movieId = Convert.ToInt32(reader["Movie_ID"]);
                    string movieName = movieId + " - " + reader["Movie_Name"];
                    return new Order_Lookup_Item(movieId, movieName);
                }
            }
        }

        private void load_movies()
            /*@desc
             * this function loads the movies into the movie selection combo box
             * based on the selected customer and their queue. 
             * Prioritizing movies in the customer's queue then the rest of the movies in alphabetical order
             */
        {
            comboBox3.Items.Clear();

            try
            {
                using (SqlConnection conn = new SqlConnection(connection_string))
                {
                    conn.Open();
                    int? selected_customer_id = get_selected_customer_id();
                    
                    /*@desc
                     * this string query selects movie that have
                     * available copies based on the count of orders that have a return date in the future
                     * Prioritizes movies in the customer's queue by sorting them first then alphabetically
                     */
                    string query = @"
                        SELECT m.Movie_ID, m.Movie_Name
                        FROM Movie_Data m
                        WHERE m.Num_Copies >
                        (
                            SELECT COUNT(*)
                            FROM Order_Data o
                            WHERE o.Movie_ID = m.Movie_ID
                              AND o.Return_Date > GETDATE()
                        )
                        ORDER BY
                            CASE
                                WHEN @customerId IS NOT NULL AND EXISTS
                                (
                                    SELECT 1
                                    FROM Movie_Queue mq
                                    WHERE mq.Customer_ID = @customerId
                                      AND mq.Movie_ID = m.Movie_ID
                                ) THEN 0
                                ELSE 1
                            END,
                            CASE
                                WHEN @customerId IS NOT NULL THEN
                                (
                                    SELECT TOP 1 mq.Queue_Position
                                    FROM Movie_Queue mq
                                    WHERE mq.Customer_ID = @customerId
                                      AND mq.Movie_ID = m.Movie_ID
                                )
                                ELSE NULL
                            END,
                            m.Movie_Name";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@customerId", (object?)selected_customer_id ?? DBNull.Value);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int movieId = Convert.ToInt32(reader["Movie_ID"]);
                        string movieName = movieId + " - " + reader["Movie_Name"];
                        comboBox3.Items.Add(new Order_Lookup_Item(movieId, movieName));
                    }
                }

                if (comboBox3.Items.Count > 0)
                {
                    comboBox3.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error loading movies: " + ex.Message);
            }
        }

        private void load_customer_queue()
        {
            /*@desc
             * this functions purpose is to load the customers queue into the data grid
             * based on the customer thats selected
             * It uses a string query to get the movies in the queue along with the position, ID, Name and Genre
             */
            int? customer_id = get_selected_customer_id();

            if (customer_id == null)
            {
                queue_grid.DataSource = null;
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connection_string))
                {
                    conn.Open();
                    // string query to get the movies from the customer queue. 
                    string query = @"
                        SELECT
                            mq.Queue_Position,
                            m.Movie_ID,
                            m.Movie_Name,
                            m.Movie_Genre,
                            (
                                SELECT AVG(CAST(rm.Rating AS DECIMAL(4,2)))
                                FROM Rate_Movie rm
                                INNER JOIN Order_Data od ON rm.Order_ID = od.Order_ID
                                WHERE od.Movie_ID = m.Movie_ID
                            ) AS Average_Rating
                        FROM Movie_Queue mq
                        INNER JOIN Movie_Data m ON mq.Movie_ID = m.Movie_ID
                        WHERE mq.Customer_ID = @customerId
                        ORDER BY mq.Queue_Position";

          
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@customerId", customer_id.Value);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    queue_grid.DataSource = table;
                    queue_grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error loading the customer queue: " + ex.Message);
            }
        }

        private void load_orders()
        {
            /*@desc
             * this functions purpose is to load the orders
             * into the data grid onto the form
             * has error handling as well.
             * Using a string query to get the order data along with the other details 
             * Orders are sorted by most recent based on the ID.
             */
            try
            {
                using (SqlConnection conn = new SqlConnection(connection_string))
                {
                    conn.Open();
                    string query = @"
                        SELECT
                            o.Order_ID,
                            m.Movie_Name,
                            c.First_Name + ' ' + c.Last_Name AS Customer_Name,
                            o.Employee_ID,
                            o.Checkout,
                            o.Return_Date
                        FROM Order_Data o
                        INNER JOIN Movie_Data m ON o.Movie_ID = m.Movie_ID
                        INNER JOIN Customer_Data c ON o.Customer_ID = c.Customer_ID
                        ORDER BY o.Order_ID DESC";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error loading orders: " + ex.Message);
            }
        }

        private void set_employee_label()
            // this is to set whos currently logged in as the employee. 
        {
            employee_ID_label.Text = Current_Session.employee_id != -1
                ? "Employee ID: " + Current_Session.employee_id
                : "Employee ID: not logged in";
        }

        private void clear_order_fields(bool preserveCustomerSelection = false)
            /*@desc
             * this functions purpose is to set 
             * the order fields back to default values and to clear the movie selection
             */
        {
            if (!preserveCustomerSelection && comboBox2.Items.Count > 0)
            {
                comboBox2.SelectedIndex = 0;
            }

            DateTime now = DateTime.Now;
            DateTime later = now.AddDays(3);
            checkout_time.Value = now;
            checkout_date.Value = now;
            return_date.Value = later;
            return_time.Value = later;
        }

        private void combo_box_2_selected_index_changed(object? sender, EventArgs e)
        {
            /*@desc
             * this functions purpose is to 
             * reload the movie dropdown for the selected customer and to reload the queue as well
             * It automatically selects the first queued movie in the drop down if its available, else
             * default to the first available movie. 
             * 
             * 
             */
            load_movies();
            load_customer_queue();

            if (queue_grid.Rows.Count > 0 && queue_grid.Rows[0].Cells["Movie_ID"].Value != null)
            {
                int queuedMovieId = Convert.ToInt32(queue_grid.Rows[0].Cells["Movie_ID"].Value);

                for (int i = 0; i < comboBox3.Items.Count; i++)
                {
                    if (comboBox3.Items[i] is Order_Lookup_Item movie_item && movie_item.Id == queuedMovieId)
                    {
                        comboBox3.SelectedIndex = i;
                        break;
                    }
                }
            }
            else if (comboBox3.Items.Count > 0)
            {
                comboBox3.SelectedIndex = 0;
            }
        }

        private void queue_grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*@desc
             * this functions purpose is to read the selected movie queues ID
             * find the same movie in that dropdown and it'll display if the movie is currently unavailable.
            */
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row = queue_grid.Rows[e.RowIndex];

            if (row.IsNewRow ||
                row.Cells["Movie_ID"].Value == null ||
                row.Cells["Movie_ID"].Value == DBNull.Value)
            {
                return;
            }

            int movieId = Convert.ToInt32(row.Cells["Movie_ID"].Value);

            for (int i = 0; i < comboBox3.Items.Count; i++)
            {
                if (comboBox3.Items[i] is Order_Lookup_Item movie_item && movie_item.Id == movieId)
                {
                    comboBox3.SelectedIndex = i;
                    return;
                }
            }

            MessageBox.Show("That queued movie is not currently available.");
        }

        // UI elements
        private void back_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void clear_order_button_Click(object sender, EventArgs e)
        {
            clear_order_fields();
        }

        private void record_order_button_Click(object sender, EventArgs e)
        {
            /*@desc
             * this functions purpose is to 
             * record the order into the databased based on the selected customers 
             * return date and check out date.
             * Before recording the order it has error handles
             * for scenarios if the employee is not logged in and if the customer or movie is not seleccted.
             * 
             */
            if (Current_Session.employee_id == -1)
            {
                MessageBox.Show("There is an error. No employee is logged in.");
                return;
            }

            if (comboBox2.SelectedItem == null || comboBox3.SelectedItem == null)
            {
                MessageBox.Show("Please select a customer and a movie.");
                return;
            }
            

            // this section of the code is to combine and compared the checkout date and time and the return date and time to make sure its returned after checkout time.

            Order_Lookup_Item customer_item = (Order_Lookup_Item)comboBox2.SelectedItem;
            Order_Lookup_Item movie_item = (Order_Lookup_Item)comboBox3.SelectedItem;

            DateTime checkoutDateTime = checkout_date.Value.Date + checkout_time.Value.TimeOfDay;
            DateTime returnDateTime = return_date.Value.Date + return_time.Value.TimeOfDay;

            if (returnDateTime <= checkoutDateTime)
            {
                MessageBox.Show("Return date and time must be after the checkout date and time.");
                return;
            }

            try
            {
                /*@desc
                 * this section of the code involves checking 
                 * if the the movie is avaiable based on the number of copies and count of orders with return dates in the future.
                 * 
                 * However befoore that, whatever movie thats first in the queue must be rented before any other movie can be rented even if the selected movie is avaialble.
                 */
                using (SqlConnection conn = new SqlConnection(connection_string))
                {
                    conn.Open();
                    Order_Lookup_Item? next_queued_movie = get_next_available_queued_movie(conn, customer_item.Id);

                    if (next_queued_movie != null && movie_item.Id != next_queued_movie.Id)
                    {
                        MessageBox.Show("This customer must be rented their next available queued movie first: " + next_queued_movie.DisplayText);
                        load_movies();
                        load_customer_queue();
                        return;
                    }

                    // string query to check availability
                    string availabilityQuery = @"
                        SELECT Num_Copies -
                        (
                            SELECT COUNT(*)
                            FROM Order_Data
                            WHERE Movie_ID = @movieId
                              AND Return_Date > GETDATE()
                        )
                        FROM Movie_Data
                        WHERE Movie_ID = @movieId";

                    SqlCommand availabilityCmd = new SqlCommand(availabilityQuery, conn);
                    availabilityCmd.Parameters.AddWithValue("@movieId", movie_item.Id);
                    object availableCopiesValue = availabilityCmd.ExecuteScalar();

                    if (availableCopiesValue == null || Convert.ToInt32(availableCopiesValue) <= 0)
                    {
                        MessageBox.Show("This movie is currently unavailable.");
                        load_movies();
                        return;
                    }

                    // string query to inser the order into the database.

                    string insertQuery = @"
                        INSERT INTO Order_Data
                        (Checkout, Return_Date, Movie_ID, Customer_ID, Employee_ID)
                        VALUES
                        (@checkout, @returnDate, @movieId, @customerId, @employeeId)";

                    SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@checkout", checkoutDateTime);
                    insertCmd.Parameters.AddWithValue("@returnDate", returnDateTime);
                    insertCmd.Parameters.AddWithValue("@movieId", movie_item.Id);
                    insertCmd.Parameters.AddWithValue("@customerId", customer_item.Id);
                    insertCmd.Parameters.AddWithValue("@employeeId", Current_Session.employee_id);
                    insertCmd.ExecuteNonQuery();

                    // if the movie was just rented then it'll be removed from the customers queue and position will be resequenced.
                    string removeQueueQuery = "DELETE FROM Movie_Queue WHERE Customer_ID = @customerId AND Movie_ID = @movieId";
                    SqlCommand removeQueueCmd = new SqlCommand(removeQueueQuery, conn);
                    removeQueueCmd.Parameters.AddWithValue("@customerId", customer_item.Id);
                    removeQueueCmd.Parameters.AddWithValue("@movieId", movie_item.Id);
                    removeQueueCmd.ExecuteNonQuery();

                    resequence_customer_queue(conn, customer_item.Id);
                }
                // refresh
                MessageBox.Show("Order recorded successfully!");
                load_orders();
                load_movies();
                load_customer_queue();
                clear_order_fields(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error recording the order: " + ex.Message);
            }
        }

        private class Order_Lookup_Item
        {
            public int Id;
            public string DisplayText;

            public Order_Lookup_Item(int id, string displayText)
            {
                Id = id;
                DisplayText = displayText;
            }

            public override string ToString()
            {
                return DisplayText;
            }
        }

        private void resequence_customer_queue(SqlConnection conn, int customer_id)
        {
            /*@desc
             * this functions purpose 
             * is to resequence the customer queue positions after a movie has been
             * safely removed from the queue 
             */
            string query = @"
                WITH OrderedQueue AS
                (
                    SELECT
                        Customer_ID,
                        Movie_ID,
                        ROW_NUMBER() OVER (ORDER BY Queue_Position, Movie_ID) AS NewQueuePosition
                    FROM Movie_Queue
                    WHERE Customer_ID = @customerId
                )
                UPDATE mq
                SET Queue_Position = oq.NewQueuePosition
                FROM Movie_Queue mq
                INNER JOIN OrderedQueue oq
                    ON mq.Customer_ID = oq.Customer_ID
                   AND mq.Movie_ID = oq.Movie_ID";

            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@customerId", customer_id);
                command.ExecuteNonQuery();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}

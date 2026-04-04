using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MovieRental_Team5
{
    public partial class OrderForm : Form
    {
        string connectionString = DatabaseConnection.ConnectionString;

        public OrderForm()
        {
            // Initializing the form
            InitializeComponent();
            Load += OrderForm_Load;
            back_button.Click += back_button_Click;
            record_order_button.Click += record_order_button_Click;
            button1.Click += clear_order_button_Click;
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            if (!AccessControl.EnsureEmployeeLoggedIn(this))
            {
                return;
            }

            // Loading form
            load_customers();
            load_movies();
            load_orders();
            set_employee_label();
            clear_order_fields();
        }

        private void load_customers()
        {
            comboBox2.Items.Clear();

            try
            {
                /*@ desc 
                 * this functions purpose is to load the customers
                 * inside of the box, it'll display the ID, First & Last name and it'll order it.
                 */
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Customer_ID, First_Name, Last_Name FROM Customer_Data ORDER BY Last_Name, First_Name";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        // Creating a display string that displays the customer information
                        int customerId = Convert.ToInt32(reader["Customer_ID"]);
                        string customerName = customerId + " - " + reader["First_Name"].ToString() + " " + reader["Last_Name"].ToString();
                        comboBox2.Items.Add(new OrderLookupItem(customerId, customerName));
                    }

                    reader.Close();
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

        private void load_movies()
        {
            comboBox3.Items.Clear();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    /*@desc 
                     * this section of the code is to load the movies that exist and itll display 
                     * the ID and name of the movie, it'll also order it by the name. The query also checks if there are copies available by 
                     * comparing the number of copies to the number of orders that have a return date in at a later date.
                     */
                    conn.Open();
                    string query = @"
                        SELECT m.Movie_ID, m.Movie_Name
                        FROM Movie_Data m
                        WHERE m.Num_Copies >
                        (
                            SELECT COUNT(*)
                            FROM Order_Data o
                            WHERE o.Movie_ID = m.Movie_ID
                            AND DATETIMEFROMPARTS(o.Return_Year, o.Return_Month, o.Return_Day,
                                DATEPART(HOUR, o.Return_Time), DATEPART(MINUTE, o.Return_Time), DATEPART(SECOND, o.Return_Time), 0) > GETDATE()
                        )
                        ORDER BY m.Movie_Name";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int movieId = Convert.ToInt32(reader["Movie_ID"]);
                        string movieName = movieId + " - " + reader["Movie_Name"].ToString();
                        comboBox3.Items.Add(new OrderLookupItem(movieId, movieName));
                    }

                    reader.Close();
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

        private void load_orders()
            /*@desc: this functions purpose is to load orders into the data grid view
             * Displaying the customer information and movie information
             * Also displaying the rest of the information such as return date and checkout.
             */
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            o.Order_ID,
                            m.Movie_Name,
                            c.First_Name + ' ' + c.Last_Name AS Customer_Name,
                            o.Employee_ID,
                            CONCAT(o.Checkout_Year, '-', RIGHT('00' + CAST(o.Checkout_Month AS varchar(2)), 2), '-', RIGHT('00' + CAST(o.Checkout_Day AS varchar(2)), 2)) AS Checkout_Date,
                            CONVERT(varchar(8), o.Checkout_Time, 108) AS Checkout_Time,
                            CONCAT(o.Return_Year, '-', RIGHT('00' + CAST(o.Return_Month AS varchar(2)), 2), '-', RIGHT('00' + CAST(o.Return_Day AS varchar(2)), 2)) AS Return_Date,
                            CONVERT(varchar(8), o.Return_Time, 108) AS Return_Time
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
        {
            /*@desc this functions purpose is to set the employee label to the ID thats logged in
             * 
             */
            if (CurrentSession.EmployeeId != -1)
            {
                employee_ID_label.Text = "Employee ID: " + CurrentSession.EmployeeId;
            }
            else
            {
                employee_ID_label.Text = "Employee ID: not logged in";
            }
        }

        private void clear_order_fields()
        {
            /*@desc
             * this functions purpose is to clear the order fields and resetting them 
             * to default values
             */
            if (comboBox2.Items.Count > 0)
            {
                comboBox2.SelectedIndex = 0;
            }

            if (comboBox3.Items.Count > 0)
            {
                comboBox3.SelectedIndex = 0;
            }

            DateTime now = DateTime.Now;
            DateTime later = now.AddDays(3);

            checkout_time.Value = now;
            checkout_date.Value = now;
            return_date.Value = later;
            return_time.Value = later;
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clear_order_button_Click(object sender, EventArgs e)
        {
            clear_order_fields();
        }

        private void record_order_button_Click(object sender, EventArgs e)
        {
            /*@desc
             * this functions purpose is to record the order into the database
             * it first check if theres an employee logged in or not and checks if the customer and movie are selected
             * it checks if the return date is after the checkout date before proceeding
             * checks if  the movie is available by comparing the number of copies to num of orders
             */
            if (CurrentSession.EmployeeId == -1)
            {
                MessageBox.Show("There is an error. No employee is logged in.");
                return;
            }

            if (comboBox2.SelectedItem == null || comboBox3.SelectedItem == null)
            {
                MessageBox.Show("Please select a customer and a movie.");
                return;
            }

            OrderLookupItem customerItem = (OrderLookupItem)comboBox2.SelectedItem;
            OrderLookupItem movieItem = (OrderLookupItem)comboBox3.SelectedItem;

            // Combining date and time for check out
            DateTime checkoutDateTime = checkout_time.Value.Date + checkout_date.Value.TimeOfDay;
            DateTime returnDateTime = return_date.Value.Date + return_time.Value.TimeOfDay;

            if (returnDateTime <= checkoutDateTime)
            {
                MessageBox.Show("Return date and time must be after the checkout date and time.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // this query checks if movie is available by comparing # of copies to # of orders.
                    string availabilityQuery = @"
                        SELECT Num_Copies -
                        (
                            SELECT COUNT(*)
                            FROM Order_Data
                            WHERE Movie_ID = @movieId
                            AND DATETIMEFROMPARTS(Return_Year, Return_Month, Return_Day,
                                DATEPART(HOUR, Return_Time), DATEPART(MINUTE, Return_Time), DATEPART(SECOND, Return_Time), 0) > GETDATE()
                        )
                        FROM Movie_Data
                        WHERE Movie_ID = @movieId";

                    SqlCommand availabilityCmd = new SqlCommand(availabilityQuery, conn);
                    availabilityCmd.Parameters.AddWithValue("@movieId", movieItem.Id);
                    object availableCopiesValue = availabilityCmd.ExecuteScalar();

                    if (availableCopiesValue == null || Convert.ToInt32(availableCopiesValue) <= 0)
                    {
                        MessageBox.Show("This movie is currently unavailable.");
                        load_movies();
                        return;
                    }
           
                    string insertQuery = @"
                        INSERT INTO Order_Data
                        (Checkout_Year, Checkout_Month, Checkout_Day, Checkout_Time,
                         Return_Year, Return_Month, Return_Day, Return_Time, Movie_ID, Customer_ID, Employee_ID)
                        VALUES
                        (@checkoutYear, @checkoutMonth, @checkoutDay, @checkoutTime,
                         @returnYear, @returnMonth, @returnDay, @returnTime, @movieId, @customerId, @employeeId)";
                    // this block of code inserts the order into the database with the necessary information for th eorder.
                    SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@checkoutYear", checkoutDateTime.Year);
                    insertCmd.Parameters.AddWithValue("@checkoutMonth", checkoutDateTime.Month);
                    insertCmd.Parameters.AddWithValue("@checkoutDay", checkoutDateTime.Day);
                    insertCmd.Parameters.AddWithValue("@checkoutTime", checkoutDateTime.TimeOfDay);
                    insertCmd.Parameters.AddWithValue("@returnYear", returnDateTime.Year);
                    insertCmd.Parameters.AddWithValue("@returnMonth", returnDateTime.Month);
                    insertCmd.Parameters.AddWithValue("@returnDay", returnDateTime.Day);
                    insertCmd.Parameters.AddWithValue("@returnTime", returnDateTime.TimeOfDay);
                    insertCmd.Parameters.AddWithValue("@movieId", movieItem.Id);
                    insertCmd.Parameters.AddWithValue("@customerId", customerItem.Id);
                    insertCmd.Parameters.AddWithValue("@employeeId", CurrentSession.EmployeeId);
                    insertCmd.ExecuteNonQuery();
                }

                MessageBox.Show("Order recorded successfully!");
                load_orders();
                load_movies();
                clear_order_fields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error recording the order: " + ex.Message);
            }
        }

        private class OrderLookupItem
        {
            public int Id;
            public string DisplayText;

            public OrderLookupItem(int id, string displayText)
            {
                Id = id;
                DisplayText = displayText;
            }

            public override string ToString()
            {
                return DisplayText;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void OpenHelpTopic(string topic)
        {
            using (HelpForm helpForm = new HelpForm(topic))
            {
                helpForm.ShowDialog(this);
            }
        }

        private void helpOverviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenHelpTopic(HelpTopics.GettingStarted);
        }

        private void helpOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenHelpTopic(HelpTopics.Orders);
        }

        private void helpMoviesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenHelpTopic(HelpTopics.Movies);
        }

        private void helpAboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenHelpTopic(HelpTopics.About);
        }
    }
}

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
    public partial class Customer_Form : Form
    {
        private readonly string connection_string = Database_Connection.connection_string;
        private int selected_customer_id = -1;

        public Customer_Form()
        {
            InitializeComponent();
            Load += customer_form_load;
        }

        private void customer_form_load(object? sender, EventArgs e)
        {
            /*@desc this method is called when the form loads and checks if an employee is logged in. If not,
             * 
             */
            if (!Access_Control.ensure_employee_logged_in(this))
            {
                return;
            }

            load_customers();
            clear_fields();
            load_customer_queue_and_history();
        }

        private void load_customers()
        {
            /*@desc
             * this functions purpose is to load the customers
             * from the database then after display them.
             * It includes a search functionality as well that can let the employee
             * filter by first, last or email.
             */
            try
            {
                using (SqlConnection connection = new SqlConnection(connection_string))
                {
                    connection.Open();
                    string query = @"
                        SELECT
                            c.Customer_ID,
                            c.First_Name,
                            c.Last_Name,
                            c.Email_Address,
                            c.City,
                            c.Province,
                            c.Address,
                            c.Postal_Code,
                            c.Account_Number,
                            c.Account_Creation_Date,
                            c.Credit_Card_Number,
                            (
                                SELECT AVG(CAST(mr.Rating AS DECIMAL(4,2)))
                                FROM Rate_Movie mr
                                INNER JOIN Order_Data od ON mr.Order_ID = mr.Order_ID
                                WHERE od.Customer_ID = c.Customer_ID
                            ) AS Average_Rating
                        FROM Customer_Data c
                        WHERE (@firstName = '' OR c.First_Name LIKE '%' + @firstName + '%')
                          AND (@lastName = '' OR c.Last_Name LIKE '%' + @lastName + '%')
                          AND (@email = '' OR c.Email_Address LIKE '%' + @email + '%')
                        ORDER BY c.Last_Name, c.First_Name";

                    // Retrieve customer data with the filters applied.
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@firstName", customer_search_first_field.Text.Trim());
                    adapter.SelectCommand.Parameters.AddWithValue("@lastName", customer_search_last_field.Text.Trim());
                    adapter.SelectCommand.Parameters.AddWithValue("@email", customer_search_email_field.Text.Trim());
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    customer_grid.DataSource = table;
                    customer_grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error loading customers: " + ex.Message);
            }
        }

        private void clear_fields()
        {
            /*@desc this method is used to clear all input fields
             * then reset the customer queue and history grids.
             */
            first_name_field.Text = "";
            last_name_field.Text = "";
            email_field.Text = "";
            city_field.Text = "";
            province_field.Text = "";
            address_field.Text = "";
            postal_code_field.Text = "";
            account_number_field.Text = "";
            credit_card_field.Text = "";
            average_rating_field.Text = "";
            account_creation_picker.Value = DateTime.Today;
            selected_customer_id = -1;
            load_customer_queue_and_history();
        }

        private bool validate_required_fields()
            /*@desc
             * this method is used to check if all fields are validated
             * else it'll throw an error message and return false
             * It also checks for the account number as well.
             */
        {
            if (string.IsNullOrWhiteSpace(first_name_field.Text) ||
                string.IsNullOrWhiteSpace(last_name_field.Text) ||
                string.IsNullOrWhiteSpace(email_field.Text) ||
                string.IsNullOrWhiteSpace(city_field.Text) ||
                string.IsNullOrWhiteSpace(province_field.Text) ||
                string.IsNullOrWhiteSpace(address_field.Text) ||
                string.IsNullOrWhiteSpace(postal_code_field.Text) ||
                string.IsNullOrWhiteSpace(account_number_field.Text) ||
                string.IsNullOrWhiteSpace(credit_card_field.Text))
            {
                MessageBox.Show("All customer fields except average rating must be entered.");
                return false;
            }

            if (!int.TryParse(account_number_field.Text.Trim(), out _))
            {
                MessageBox.Show("Account number must be a whole number.");
                return false;
            }

            return true;
        }

        private void customer_grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*@desc
             * this method is used to handle the event when a call in the 
             * customer grid is selected. Populating the fields
             * with selected customer information and loading the necessary information
             * 
             */
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row = customer_grid.Rows[e.RowIndex];
            // this is to make sure that deal with an issue where clicking on a blank row throws an exception/trap inside the debugger.
            if (row.IsNewRow ||
                row.Cells["Customer_ID"].Value == null ||
                row.Cells["Customer_ID"].Value == DBNull.Value)
            {
                return;
            }

            selected_customer_id = Convert.ToInt32(row.Cells["Customer_ID"].Value);
            first_name_field.Text = row.Cells["First_Name"].Value?.ToString() ?? "";
            last_name_field.Text = row.Cells["Last_Name"].Value?.ToString() ?? "";
            email_field.Text = row.Cells["Email_Address"].Value?.ToString() ?? "";
            city_field.Text = row.Cells["City"].Value?.ToString() ?? "";
            province_field.Text = row.Cells["Province"].Value?.ToString() ?? "";
            address_field.Text = row.Cells["Address"].Value?.ToString() ?? "";
            postal_code_field.Text = row.Cells["Postal_Code"].Value?.ToString() ?? "";
            account_number_field.Text = row.Cells["Account_Number"].Value?.ToString() ?? "";
            credit_card_field.Text = row.Cells["Credit_Card_Number"].Value?.ToString() ?? "";
            average_rating_field.Text = row.Cells["Average_Rating"].Value == DBNull.Value ? "" : row.Cells["Average_Rating"].Value?.ToString() ?? "";

            if (row.Cells["Account_Creation_Date"].Value is DateTime creationDate)
            {
                account_creation_picker.Value = creationDate;
            }

            load_customer_queue_and_history();
        }

        // UI elements
        private void load_customers_button_Click(object sender, EventArgs e)
        {
            load_customers();
        }

        private void search_customers_button_Click(object sender, EventArgs e)
        {
            load_customers();
        }

        private void clear_button_Click(object sender, EventArgs e)
        {
            clear_fields();
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void add_customer_button_Click(object sender, EventArgs e)
        {
            /*@desc
             * this functions purpose
             * is to add a customer to the database with the information provided into the fields
             * Also includes error handling
             * 
             * the function also has error handling in place to make address any cases.
             */
            if (!validate_required_fields())
            {
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connection_string))
                {
                    connection.Open();
                    // insert query
                    string query = @"
                        INSERT INTO Customer_Data
                        (First_Name, Last_Name, Email_Address, City, Province, Address, Postal_Code,
                         Account_Number, Account_Creation_Date, Credit_Card_Number)
                        VALUES
                        (@firstName, @lastName, @email, @city, @province, @address, @postalCode,
                         @accountNumber, @accountCreationDate, @creditCardNumber)";
                    // Executing the query to insert a new customer record into the database with the provided information.
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@firstName", first_name_field.Text.Trim());
                    command.Parameters.AddWithValue("@lastName", last_name_field.Text.Trim());
                    command.Parameters.AddWithValue("@email", email_field.Text.Trim());
                    command.Parameters.AddWithValue("@city", city_field.Text.Trim());
                    command.Parameters.AddWithValue("@province", province_field.Text.Trim());
                    command.Parameters.AddWithValue("@address", address_field.Text.Trim());
                    command.Parameters.AddWithValue("@postalCode", postal_code_field.Text.Trim());
                    command.Parameters.AddWithValue("@accountNumber", int.Parse(account_number_field.Text.Trim()));
                    command.Parameters.AddWithValue("@accountCreationDate", account_creation_picker.Value.Date);
                    command.Parameters.AddWithValue("@creditCardNumber", credit_card_field.Text.Trim());
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Customer added successfully!");
                load_customers();
                clear_fields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error adding a customer: " + ex.Message);
            }
        }

        private void update_customer_button_Click(object sender, EventArgs e)
        {
            /*@desc
             * this functions purpose is to update
             * the customer information of the selected customer
             * with the information thats in the fields.
             * it also includes error handling
             */
            if (selected_customer_id == -1)
            {
                MessageBox.Show("Please select a customer to update.");
                return;
            }

            if (!validate_required_fields())
            {
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connection_string))
                {
                    // update query
                    connection.Open();
                    string query = @"
                        UPDATE Customer_Data
                        SET First_Name = @firstName,
                            Last_Name = @lastName,
                            Email_Address = @email,
                            City = @city,
                            Province = @province,
                            Address = @address,
                            Postal_Code = @postalCode,
                            Account_Number = @accountNumber,
                            Account_Creation_Date = @accountCreationDate,
                            Credit_Card_Number = @creditCardNumber
                        WHERE Customer_ID = @customerId";

                    // executing the query to update the selected customers information.
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@firstName", first_name_field.Text.Trim());
                    command.Parameters.AddWithValue("@lastName", last_name_field.Text.Trim());
                    command.Parameters.AddWithValue("@email", email_field.Text.Trim());
                    command.Parameters.AddWithValue("@city", city_field.Text.Trim());
                    command.Parameters.AddWithValue("@province", province_field.Text.Trim());
                    command.Parameters.AddWithValue("@address", address_field.Text.Trim());
                    command.Parameters.AddWithValue("@postalCode", postal_code_field.Text.Trim());
                    command.Parameters.AddWithValue("@accountNumber", int.Parse(account_number_field.Text.Trim()));
                    command.Parameters.AddWithValue("@accountCreationDate", account_creation_picker.Value.Date);
                    command.Parameters.AddWithValue("@creditCardNumber", credit_card_field.Text.Trim());
                    command.Parameters.AddWithValue("@customerId", selected_customer_id);
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Customer updated successfully!");
                load_customers();
                clear_fields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error updating a customer: " + ex.Message);
            }
        }

        private void delete_customer_button_Click(object sender, EventArgs e)
        /*@desc
         * this functions purpose is to delete the selected customer from the database
         * it also includes error handling and checks to make sure that the customer can be deleted
         * such as if they have existing orders or not.
         * 
         * The function also provides a secondary confirmation of deleting an actor. 
         */
        {
            if (selected_customer_id == -1)
            {
                MessageBox.Show("Please select a customer to delete.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this customer?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                return;
            }

            try
            {
                // this section checks if the customer has an existing order and has a error handle if they do.
                using (SqlConnection connection = new SqlConnection(connection_string))
                {
                    connection.Open();
                    string checkQuery = "SELECT COUNT(*) FROM Order_Data WHERE Customer_ID = @customerId";
                    SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                    checkCommand.Parameters.AddWithValue("@customerId", selected_customer_id);
                    int orderCount = Convert.ToInt32(checkCommand.ExecuteScalar());

                    if (orderCount > 0)
                    {
                        MessageBox.Show("This customer cannot be deleted because they have existing orders.");
                        return;
                    }
                    // Once confirmed it proceeds to delete the customer fro the database.
                    SqlCommand deleteQueue = new SqlCommand("DELETE FROM Movie_Queue WHERE Customer_ID = @customerId", connection);
                    deleteQueue.Parameters.AddWithValue("@customerId", selected_customer_id);
                    deleteQueue.ExecuteNonQuery();

                    string deleteQuery = "DELETE FROM Customer_Data WHERE Customer_ID = @customerId";
                    SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                    deleteCommand.Parameters.AddWithValue("@customerId", selected_customer_id);
                    deleteCommand.ExecuteNonQuery();
                }

                MessageBox.Show("Customer deleted successfully!");
                load_customers();
                clear_fields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error deleting a customer: " + ex.Message);
            }
        }

        private void load_customer_queue_and_history()
        {
            /*@desc
             * this function is used to load the customer queue
             * and their history.
             */
            if (selected_customer_id == -1)
            {
                customer_queue_grid.DataSource = null;
                customer_history_grid.DataSource = null;
                return;
            }

            load_customer_queue();
            load_customer_history();
        }

        private void load_customer_queue()
        {
            /*@desc
             * this functions purpose is to load the customer queue for the selected customer
             * then it'll display in a grid.
             * 
             */
            try
            {
                using (SqlConnection connection = new SqlConnection(connection_string))
                {
                    connection.Open();
                    string query = @"
                        SELECT
                            mq.Queue_Position,
                            movie.Movie_ID,
                            movie.Movie_Name,
                            movie.Movie_Genre,
                            (
                                SELECT AVG(CAST(rm.Rating AS DECIMAL(4,2)))
                                FROM Rate_Movie rm
                                INNER JOIN Order_Data od ON rm.Order_ID = od.Order_ID
                                WHERE od.Movie_ID = movie.Movie_ID
                            ) AS Average_Rating
                        FROM Movie_Queue mq
                        INNER JOIN Movie_Data movie ON mq.Movie_ID = movie.Movie_ID
                        WHERE mq.Customer_ID = @customerId
                        ORDER BY mq.Queue_Position";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@customerId", selected_customer_id);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    customer_queue_grid.DataSource = table;
                    customer_queue_grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error loading the customer queue: " + ex.Message);
            }
        }

        private void load_customer_history()
        {
            /*@desc
             * this function here is used to load the customer
             * order history for the customer thats selected
             * it also has error handling in place. 
             * 
             */
            try
            {
                using (SqlConnection connection = new SqlConnection(connection_string))
                {
                    connection.Open();
                    string query = @"
                        SELECT
                            o.Order_ID,
                            m.Movie_Name,
                            o.Checkout,
                            o.Return_Date
                        FROM Order_Data o
                        INNER JOIN Movie_Data m ON o.Movie_ID = m.Movie_ID
                        WHERE o.Customer_ID = @customerId
                        ORDER BY o.Order_ID DESC";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@customerId", selected_customer_id);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    customer_history_grid.DataSource = table;
                    customer_history_grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error loading the customer order history: " + ex.Message);
            }
        }
    }
}

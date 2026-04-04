using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MovieRental_Team5
{
    public partial class CustomerPortalForm : Form
    {
        private readonly string connectionString = DatabaseConnection.ConnectionString;

        public CustomerPortalForm()
        {
            InitializeComponent();
            Load += CustomerPortalForm_Load;
        }

        private void CustomerPortalForm_Load(object? sender, EventArgs e)
        {
            LoadCustomers();
            LoadBestSellers();
            LoadAvailableMovies();
        }

        private void LoadCustomers()
        {
            customer_selector.Items.Clear();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        SELECT Customer_ID, First_Name, Last_Name
                        FROM Customer_Data
                        ORDER BY Last_Name, First_Name";

                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int customerId = Convert.ToInt32(reader["Customer_ID"]);
                        string displayText = customerId + " - " + reader["First_Name"] + " " + reader["Last_Name"];
                        customer_selector.Items.Add(new CustomerLookupItem(customerId, displayText));
                    }
                }

                if (customer_selector.Items.Count > 0)
                {
                    customer_selector.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error loading customers: " + ex.Message);
            }
        }

        private int? GetSelectedCustomerId()
        {
            if (customer_selector.SelectedItem is CustomerLookupItem customer)
            {
                return customer.Id;
            }

            return null;
        }

        private void customer_selector_SelectedIndexChanged(object sender, EventArgs e)
        {
            int? customerId = GetSelectedCustomerId();
            if (customerId == null)
            {
                return;
            }

            LoadCustomerAccount(customerId.Value);
            LoadCurrentRentals(customerId.Value);
            LoadOrderHistory(customerId.Value);
            LoadSuggestions(customerId.Value);
        }

        private void LoadCustomerAccount(int customerId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        SELECT First_Name, Last_Name, Email_Address, City, Province, Address,
                               Postal_Code, Account_Number, Account_Creation_Date, Average_Rating
                        FROM Customer_Data
                        WHERE Customer_ID = @customerId";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@customerId", customerId);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        account_name_value.Text = reader["First_Name"] + " " + reader["Last_Name"];
                        account_email_value.Text = reader["Email_Address"]?.ToString() ?? "";
                        account_city_value.Text = reader["City"]?.ToString() ?? "";
                        account_province_value.Text = reader["Province"]?.ToString() ?? "";
                        account_address_value.Text = reader["Address"]?.ToString() ?? "";
                        account_postal_value.Text = reader["Postal_Code"]?.ToString() ?? "";
                        account_number_value.Text = reader["Account_Number"]?.ToString() ?? "";
                        account_created_value.Text = Convert.ToDateTime(reader["Account_Creation_Date"]).ToShortDateString();
                        account_rating_value.Text = reader["Average_Rating"]?.ToString() ?? "0";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error loading account details: " + ex.Message);
            }
        }

        private void LoadCurrentRentals(int customerId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        SELECT
                            o.Order_ID,
                            m.Movie_Name,
                            m.Movie_Genre,
                            CONCAT(o.Checkout_Year, '-', RIGHT('00' + CAST(o.Checkout_Month AS varchar(2)), 2), '-', RIGHT('00' + CAST(o.Checkout_Day AS varchar(2)), 2)) AS Checkout_Date,
                            CONVERT(varchar(8), o.Checkout_Time, 108) AS Checkout_Time,
                            CONCAT(o.Return_Year, '-', RIGHT('00' + CAST(o.Return_Month AS varchar(2)), 2), '-', RIGHT('00' + CAST(o.Return_Day AS varchar(2)), 2)) AS Return_Date,
                            CONVERT(varchar(8), o.Return_Time, 108) AS Return_Time
                        FROM Order_Data o
                        INNER JOIN Movie_Data m ON o.Movie_ID = m.Movie_ID
                        WHERE o.Customer_ID = @customerId
                          AND DATETIMEFROMPARTS(o.Return_Year, o.Return_Month, o.Return_Day,
                              DATEPART(HOUR, o.Return_Time), DATEPART(MINUTE, o.Return_Time), DATEPART(SECOND, o.Return_Time), 0) > GETDATE()
                        ORDER BY o.Return_Year, o.Return_Month, o.Return_Day, o.Return_Time";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@customerId", customerId);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    current_rentals_grid.DataSource = table;
                    current_rentals_grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error loading current rentals: " + ex.Message);
            }
        }

        private void LoadOrderHistory(int customerId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        SELECT
                            o.Order_ID,
                            m.Movie_Name,
                            m.Movie_Genre,
                            CONCAT(o.Checkout_Year, '-', RIGHT('00' + CAST(o.Checkout_Month AS varchar(2)), 2), '-', RIGHT('00' + CAST(o.Checkout_Day AS varchar(2)), 2)) AS Checkout_Date,
                            CONVERT(varchar(8), o.Checkout_Time, 108) AS Checkout_Time,
                            CONCAT(o.Return_Year, '-', RIGHT('00' + CAST(o.Return_Month AS varchar(2)), 2), '-', RIGHT('00' + CAST(o.Return_Day AS varchar(2)), 2)) AS Return_Date,
                            CONVERT(varchar(8), o.Return_Time, 108) AS Return_Time
                        FROM Order_Data o
                        INNER JOIN Movie_Data m ON o.Movie_ID = m.Movie_ID
                        WHERE o.Customer_ID = @customerId
                        ORDER BY o.Order_ID DESC";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@customerId", customerId);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    history_grid.DataSource = table;
                    history_grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error loading order history: " + ex.Message);
            }
        }

        private void LoadAvailableMovies()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        SELECT
                            m.Movie_ID,
                            m.Movie_Name,
                            m.Movie_Genre,
                            m.Distribution_Fee,
                            m.Num_Copies,
                            m.Average_Rating
                        FROM Movie_Data m
                        WHERE m.Num_Copies >
                        (
                            SELECT COUNT(*)
                            FROM Order_Data o
                            WHERE o.Movie_ID = m.Movie_ID
                              AND DATETIMEFROMPARTS(o.Return_Year, o.Return_Month, o.Return_Day,
                                  DATEPART(HOUR, o.Return_Time), DATEPART(MINUTE, o.Return_Time), DATEPART(SECOND, o.Return_Time), 0) > GETDATE()
                        )
                          AND (@genre = '' OR m.Movie_Genre = @genre)
                          AND (@keyword = '' OR m.Movie_Name LIKE '%' + @keyword + '%')
                        ORDER BY m.Movie_Name";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@genre", movie_type_filter.Text == "All" ? "" : movie_type_filter.Text);
                    adapter.SelectCommand.Parameters.AddWithValue("@keyword", keyword_filter.Text.Trim());
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    available_movies_grid.DataSource = table;
                    available_movies_grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error loading available movies: " + ex.Message);
            }
        }

        private void LoadBestSellers()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        SELECT TOP (10)
                            m.Movie_Name,
                            m.Movie_Genre,
                            COUNT(*) AS Total_Rentals
                        FROM Order_Data o
                        INNER JOIN Movie_Data m ON o.Movie_ID = m.Movie_ID
                        GROUP BY m.Movie_Name, m.Movie_Genre
                        ORDER BY COUNT(*) DESC, m.Movie_Name";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    bestseller_grid.DataSource = table;
                    bestseller_grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error loading best sellers: " + ex.Message);
            }
        }

        private void LoadSuggestions(int customerId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        WITH FavoriteGenre AS
                        (
                            SELECT TOP (1) m.Movie_Genre
                            FROM Order_Data o
                            INNER JOIN Movie_Data m ON o.Movie_ID = m.Movie_ID
                            WHERE o.Customer_ID = @customerId
                            GROUP BY m.Movie_Genre
                            ORDER BY COUNT(*) DESC
                        )
                        SELECT TOP (5)
                            m.Movie_Name,
                            m.Movie_Genre,
                            m.Average_Rating,
                            m.Distribution_Fee
                        FROM Movie_Data m
                        WHERE m.Num_Copies >
                        (
                            SELECT COUNT(*)
                            FROM Order_Data activeOrders
                            WHERE activeOrders.Movie_ID = m.Movie_ID
                              AND DATETIMEFROMPARTS(activeOrders.Return_Year, activeOrders.Return_Month, activeOrders.Return_Day,
                                  DATEPART(HOUR, activeOrders.Return_Time), DATEPART(MINUTE, activeOrders.Return_Time), DATEPART(SECOND, activeOrders.Return_Time), 0) > GETDATE()
                        )
                          AND (
                              m.Movie_Genre IN (SELECT Movie_Genre FROM FavoriteGenre)
                              OR NOT EXISTS (SELECT 1 FROM FavoriteGenre)
                          )
                          AND m.Movie_ID NOT IN
                          (
                              SELECT Movie_ID
                              FROM Order_Data
                              WHERE Customer_ID = @customerId
                          )
                        ORDER BY m.Average_Rating DESC, m.Movie_Name";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@customerId", customerId);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    suggestions_grid.DataSource = table;
                    suggestions_grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error loading suggestions: " + ex.Message);
            }
        }

        private void browse_button_Click(object sender, EventArgs e)
        {
            LoadAvailableMovies();
            int? customerId = GetSelectedCustomerId();
            if (customerId != null)
            {
                LoadSuggestions(customerId.Value);
            }
        }

        private void refresh_button_Click(object sender, EventArgs e)
        {
            LoadCustomers();
            LoadBestSellers();
            LoadAvailableMovies();
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            Close();
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

        private void helpCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenHelpTopic(HelpTopics.CustomerManagement);
        }

        private void helpAboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenHelpTopic(HelpTopics.About);
        }

        private class CustomerLookupItem
        {
            public int Id;
            public string DisplayText;

            public CustomerLookupItem(int id, string displayText)
            {
                Id = id;
                DisplayText = displayText;
            }

            public override string ToString()
            {
                return DisplayText;
            }
        }
    }
}

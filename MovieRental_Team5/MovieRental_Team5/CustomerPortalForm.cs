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
                using SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string query = "SELECT Customer_ID, First_Name, Last_Name FROM Customer_Data ORDER BY Last_Name, First_Name";
                using SqlCommand command = new SqlCommand(query, connection);
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["Customer_ID"]);
                    string name = id + " - " + reader["First_Name"] + " " + reader["Last_Name"];
                    customer_selector.Items.Add(new PortalLookupItem(id, name));
                }
                if (customer_selector.Items.Count > 0) customer_selector.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error loading customers: " + ex.Message);
            }
        }

        private int? GetSelectedCustomerId()
        {
            return customer_selector.SelectedItem is PortalLookupItem item ? item.Id : null;
        }

        private void customer_selector_SelectedIndexChanged(object sender, EventArgs e)
        {
            int? customerId = GetSelectedCustomerId();
            if (customerId == null) return;
            LoadCustomerPortal(customerId.Value);
        }

        private void LoadCustomerPortal(int customerId)
        {
            LoadCustomerAccount(customerId);
            LoadCurrentRentals(customerId);
            LoadOrderHistory(customerId);
            LoadQueue(customerId);
            LoadQueueMovieOptions(customerId);
            LoadRatingOptions(customerId);
            LoadAvailableMovies();
            LoadSuggestions(customerId);
        }

        private void LoadCustomerAccount(int customerId)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string query = @"SELECT First_Name, Last_Name, Email_Address, City, Province, Address,
                                 Postal_Code, Account_Number, Account_Creation_Date, Average_Rating
                                 FROM Customer_Data WHERE Customer_ID = @customerId";
                using SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@customerId", customerId);
                using SqlDataReader reader = command.ExecuteReader();
                if (!reader.Read()) return;
                account_name_value.Text = reader["First_Name"] + " " + reader["Last_Name"];
                account_email_value.Text = reader["Email_Address"]?.ToString() ?? "";
                account_city_value.Text = reader["City"]?.ToString() ?? "";
                account_province_value.Text = reader["Province"]?.ToString() ?? "";
                account_address_value.Text = reader["Address"]?.ToString() ?? "";
                account_postal_value.Text = reader["Postal_Code"]?.ToString() ?? "";
                account_number_value.Text = reader["Account_Number"]?.ToString() ?? "";
                account_created_value.Text = Convert.ToDateTime(reader["Account_Creation_Date"]).ToShortDateString();
                account_rating_value.Text = reader["Average_Rating"] == DBNull.Value ? "Not Rated" : Convert.ToDecimal(reader["Average_Rating"]).ToString("0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error loading account details: " + ex.Message);
            }
        }

        private void LoadCurrentRentals(int customerId)
        {
            LoadGrid(current_rentals_grid, @"SELECT o.Order_ID,m.Movie_Name,m.Movie_Genre,
                CONCAT(o.Checkout_Year,'-',RIGHT('00'+CAST(o.Checkout_Month AS varchar(2)),2),'-',RIGHT('00'+CAST(o.Checkout_Day AS varchar(2)),2)) AS Checkout_Date,
                CONVERT(varchar(8),o.Checkout_Time,108) AS Checkout_Time,
                CONCAT(o.Return_Year,'-',RIGHT('00'+CAST(o.Return_Month AS varchar(2)),2),'-',RIGHT('00'+CAST(o.Return_Day AS varchar(2)),2)) AS Return_Date,
                CONVERT(varchar(8),o.Return_Time,108) AS Return_Time
                FROM Order_Data o INNER JOIN Movie_Data m ON o.Movie_ID=m.Movie_ID
                WHERE o.Customer_ID=@customerId AND DATETIMEFROMPARTS(o.Return_Year,o.Return_Month,o.Return_Day,
                DATEPART(HOUR,o.Return_Time),DATEPART(MINUTE,o.Return_Time),DATEPART(SECOND,o.Return_Time),0)>GETDATE()
                ORDER BY o.Return_Year,o.Return_Month,o.Return_Day,o.Return_Time", customerId);
        }

        private void LoadOrderHistory(int customerId)
        {
            LoadGrid(history_grid, @"SELECT o.Order_ID,m.Movie_Name,m.Movie_Genre,
                CONCAT(o.Checkout_Year,'-',RIGHT('00'+CAST(o.Checkout_Month AS varchar(2)),2),'-',RIGHT('00'+CAST(o.Checkout_Day AS varchar(2)),2)) AS Checkout_Date,
                CONVERT(varchar(8),o.Checkout_Time,108) AS Checkout_Time,
                CONCAT(o.Return_Year,'-',RIGHT('00'+CAST(o.Return_Month AS varchar(2)),2),'-',RIGHT('00'+CAST(o.Return_Day AS varchar(2)),2)) AS Return_Date,
                CONVERT(varchar(8),o.Return_Time,108) AS Return_Time
                FROM Order_Data o INNER JOIN Movie_Data m ON o.Movie_ID=m.Movie_ID
                WHERE o.Customer_ID=@customerId ORDER BY o.Order_ID DESC", customerId);
        }

        private void LoadQueue(int customerId)
        {
            LoadGrid(queue_grid, @"SELECT m.Movie_ID,m.Movie_Name,m.Movie_Genre,m.Distribution_Fee,m.Average_Rating
                FROM Queue q INNER JOIN Movie_Data m ON q.Movie_ID=m.Movie_ID
                WHERE q.Customer_ID=@customerId ORDER BY m.Movie_Name", customerId);
        }

        private void LoadQueueMovieOptions(int customerId)
        {
            queue_movie_selector.Items.Clear();
            try
            {
                using SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string query = @"SELECT m.Movie_ID,m.Movie_Name FROM Movie_Data m
                                 WHERE m.Movie_ID NOT IN (SELECT Movie_ID FROM Queue WHERE Customer_ID=@customerId)
                                 ORDER BY m.Movie_Name";
                using SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@customerId", customerId);
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                    queue_movie_selector.Items.Add(new PortalLookupItem(Convert.ToInt32(reader["Movie_ID"]), reader["Movie_Name"]?.ToString() ?? ""));
                if (queue_movie_selector.Items.Count > 0) queue_movie_selector.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error loading queue options: " + ex.Message);
            }
        }

        private void LoadRatingOptions(int customerId)
        {
            rated_movie_selector.Items.Clear();
            rated_actor_selector.Items.Clear();
            try
            {
                using SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                using (SqlCommand movieCommand = new SqlCommand(@"SELECT DISTINCT m.Movie_ID,m.Movie_Name
                    FROM Order_Data o INNER JOIN Movie_Data m ON o.Movie_ID=m.Movie_ID
                    WHERE o.Customer_ID=@customerId ORDER BY m.Movie_Name", connection))
                {
                    movieCommand.Parameters.AddWithValue("@customerId", customerId);
                    using SqlDataReader reader = movieCommand.ExecuteReader();
                    while (reader.Read())
                        rated_movie_selector.Items.Add(new PortalLookupItem(Convert.ToInt32(reader["Movie_ID"]), reader["Movie_Name"]?.ToString() ?? ""));
                }
                using (SqlCommand actorCommand = new SqlCommand(@"SELECT DISTINCT a.Actor_ID,a.Actor_Name
                    FROM Order_Data o INNER JOIN Appears_In ai ON o.Movie_ID=ai.Movie_ID
                    INNER JOIN Actor_Data a ON ai.Actor_ID=a.Actor_ID
                    WHERE o.Customer_ID=@customerId ORDER BY a.Actor_Name", connection))
                {
                    actorCommand.Parameters.AddWithValue("@customerId", customerId);
                    using SqlDataReader reader = actorCommand.ExecuteReader();
                    while (reader.Read())
                        rated_actor_selector.Items.Add(new PortalLookupItem(Convert.ToInt32(reader["Actor_ID"]), reader["Actor_Name"]?.ToString() ?? ""));
                }
                if (rated_movie_selector.Items.Count > 0) rated_movie_selector.SelectedIndex = 0;
                if (rated_actor_selector.Items.Count > 0) rated_actor_selector.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error loading rating options: " + ex.Message);
            }
        }

        private void LoadAvailableMovies()
        {
            try
            {
                using SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string query = @"SELECT m.Movie_ID,m.Movie_Name,m.Movie_Genre,m.Distribution_Fee,m.Num_Copies,m.Average_Rating
                    FROM Movie_Data m
                    WHERE m.Num_Copies > (SELECT COUNT(*) FROM Order_Data o WHERE o.Movie_ID=m.Movie_ID
                    AND DATETIMEFROMPARTS(o.Return_Year,o.Return_Month,o.Return_Day,DATEPART(HOUR,o.Return_Time),DATEPART(MINUTE,o.Return_Time),DATEPART(SECOND,o.Return_Time),0)>GETDATE())
                    AND (@genre='' OR m.Movie_Genre=@genre)
                    AND (@keyword='' OR m.Movie_Name LIKE '%' + @keyword + '%')
                    AND (@actorNames='' OR m.Movie_ID IN (
                        SELECT ai.Movie_ID FROM Appears_In ai
                        INNER JOIN Actor_Data a ON ai.Actor_ID=a.Actor_ID
                        INNER JOIN STRING_SPLIT(@actorNames, ',') actorFilter
                            ON a.Actor_Name LIKE '%' + LTRIM(RTRIM(actorFilter.value)) + '%'
                        WHERE LTRIM(RTRIM(actorFilter.value)) <> ''
                        GROUP BY ai.Movie_ID
                        HAVING COUNT(DISTINCT LTRIM(RTRIM(actorFilter.value))) =
                            (SELECT COUNT(*) FROM STRING_SPLIT(@actorNames, ',') WHERE LTRIM(RTRIM(value)) <> '')
                    ))
                    ORDER BY m.Movie_Name";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@genre", movie_type_filter.Text == "All" ? "" : movie_type_filter.Text);
                adapter.SelectCommand.Parameters.AddWithValue("@keyword", keyword_filter.Text.Trim());
                adapter.SelectCommand.Parameters.AddWithValue("@actorNames", actor_filter.Text.Trim());
                DataTable table = new DataTable();
                adapter.Fill(table);
                available_movies_grid.DataSource = table;
                available_movies_grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
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
                using SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(@"SELECT TOP (10) m.Movie_Name,m.Movie_Genre,COUNT(*) AS Total_Rentals
                    FROM Order_Data o INNER JOIN Movie_Data m ON o.Movie_ID=m.Movie_ID
                    GROUP BY m.Movie_Name,m.Movie_Genre ORDER BY COUNT(*) DESC,m.Movie_Name", connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                bestseller_grid.DataSource = table;
                bestseller_grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error loading best sellers: " + ex.Message);
            }
        }

        private void LoadSuggestions(int customerId)
        {
            LoadGrid(suggestions_grid, @"WITH FavoriteGenre AS (
                SELECT TOP (1) m.Movie_Genre
                FROM Order_Data o INNER JOIN Movie_Data m ON o.Movie_ID=m.Movie_ID
                WHERE o.Customer_ID=@customerId GROUP BY m.Movie_Genre ORDER BY COUNT(*) DESC)
                SELECT TOP (5) m.Movie_Name,m.Movie_Genre,m.Average_Rating,m.Distribution_Fee
                FROM Movie_Data m
                WHERE m.Num_Copies > (SELECT COUNT(*) FROM Order_Data activeOrders WHERE activeOrders.Movie_ID=m.Movie_ID
                    AND DATETIMEFROMPARTS(activeOrders.Return_Year,activeOrders.Return_Month,activeOrders.Return_Day,
                    DATEPART(HOUR,activeOrders.Return_Time),DATEPART(MINUTE,activeOrders.Return_Time),DATEPART(SECOND,activeOrders.Return_Time),0)>GETDATE())
                AND (m.Movie_Genre IN (SELECT Movie_Genre FROM FavoriteGenre) OR NOT EXISTS (SELECT 1 FROM FavoriteGenre))
                AND m.Movie_ID NOT IN (SELECT Movie_ID FROM Order_Data WHERE Customer_ID=@customerId)
                ORDER BY m.Average_Rating DESC,m.Movie_Name", customerId);
        }

        private void LoadGrid(DataGridView grid, string query, int customerId)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@customerId", customerId);
                DataTable table = new DataTable();
                adapter.Fill(table);
                grid.DataSource = table;
                grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error loading customer data: " + ex.Message);
            }
        }

        private void browse_button_Click(object sender, EventArgs e)
        {
            LoadAvailableMovies();
            int? customerId = GetSelectedCustomerId();
            if (customerId != null) LoadSuggestions(customerId.Value);
        }

        private void add_to_queue_button_Click(object sender, EventArgs e)
        {
            int? customerId = GetSelectedCustomerId();
            if (customerId == null) { MessageBox.Show("Please select a customer first."); return; }
            if (queue_movie_selector.SelectedItem is not PortalLookupItem movie) { MessageBox.Show("Please select a movie to add to the queue."); return; }
            try
            {
                using SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                using SqlCommand command = new SqlCommand("INSERT INTO Queue (Customer_ID, Movie_ID) VALUES (@customerId, @movieId)", connection);
                command.Parameters.AddWithValue("@customerId", customerId.Value);
                command.Parameters.AddWithValue("@movieId", movie.Id);
                command.ExecuteNonQuery();
                LoadQueue(customerId.Value);
                LoadQueueMovieOptions(customerId.Value);
                MessageBox.Show("Movie added to queue successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error adding the movie to the queue: " + ex.Message);
            }
        }

        private void remove_from_queue_button_Click(object sender, EventArgs e)
        {
            int? customerId = GetSelectedCustomerId();
            if (customerId == null) { MessageBox.Show("Please select a customer first."); return; }
            if (queue_grid.CurrentRow == null || queue_grid.CurrentRow.Cells["Movie_ID"].Value == null) { MessageBox.Show("Please select a queued movie to remove."); return; }
            int movieId = Convert.ToInt32(queue_grid.CurrentRow.Cells["Movie_ID"].Value);
            try
            {
                using SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                using SqlCommand command = new SqlCommand("DELETE FROM Queue WHERE Customer_ID=@customerId AND Movie_ID=@movieId", connection);
                command.Parameters.AddWithValue("@customerId", customerId.Value);
                command.Parameters.AddWithValue("@movieId", movieId);
                command.ExecuteNonQuery();
                LoadQueue(customerId.Value);
                LoadQueueMovieOptions(customerId.Value);
                MessageBox.Show("Movie removed from queue successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error removing the movie from the queue: " + ex.Message);
            }
        }

        private void rate_movie_button_Click(object sender, EventArgs e)
        {
            int? customerId = GetSelectedCustomerId();
            if (customerId == null) { MessageBox.Show("Please select a customer first."); return; }
            if (rated_movie_selector.SelectedItem is not PortalLookupItem movie) { MessageBox.Show("Please select a rented movie first."); return; }
            try
            {
                using SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                UpsertMovieRating(connection, movie.Id, customerId.Value, Convert.ToInt32(movie_rating_input.Value));
                UpdateMovieAverage(connection, movie.Id);
                UpdateCustomerAverage(connection, customerId.Value);
                LoadCustomerAccount(customerId.Value);
                LoadAvailableMovies();
                LoadSuggestions(customerId.Value);
                MessageBox.Show("Movie rating saved successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error saving the movie rating: " + ex.Message);
            }
        }

        private void rate_actor_button_Click(object sender, EventArgs e)
        {
            int? customerId = GetSelectedCustomerId();
            if (customerId == null) { MessageBox.Show("Please select a customer first."); return; }
            if (rated_actor_selector.SelectedItem is not PortalLookupItem actor) { MessageBox.Show("Please select an actor first."); return; }
            try
            {
                using SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                UpsertActorRating(connection, actor.Id, customerId.Value, Convert.ToInt32(actor_rating_input.Value));
                UpdateActorAverage(connection, actor.Id);
                MessageBox.Show("Actor rating saved successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error saving the actor rating: " + ex.Message);
            }
        }

        private void UpsertMovieRating(SqlConnection connection, int movieId, int customerId, int rating)
        {
            string query = @"IF EXISTS (SELECT 1 FROM Movie_Ratings WHERE Movie_ID=@movieId AND Customer_ID=@customerId)
                UPDATE Movie_Ratings SET Rating=@rating WHERE Movie_ID=@movieId AND Customer_ID=@customerId
                ELSE INSERT INTO Movie_Ratings (Movie_ID, Customer_ID, Rating) VALUES (@movieId, @customerId, @rating)";
            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@movieId", movieId);
            command.Parameters.AddWithValue("@customerId", customerId);
            command.Parameters.AddWithValue("@rating", rating);
            command.ExecuteNonQuery();
        }

        private void UpsertActorRating(SqlConnection connection, int actorId, int customerId, int rating)
        {
            string query = @"IF EXISTS (SELECT 1 FROM Actor_Ratings WHERE Actor_ID=@actorId AND Customer_ID=@customerId)
                UPDATE Actor_Ratings SET Rating=@rating WHERE Actor_ID=@actorId AND Customer_ID=@customerId
                ELSE INSERT INTO Actor_Ratings (Actor_ID, Customer_ID, Rating) VALUES (@actorId, @customerId, @rating)";
            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@actorId", actorId);
            command.Parameters.AddWithValue("@customerId", customerId);
            command.Parameters.AddWithValue("@rating", rating);
            command.ExecuteNonQuery();
        }

        private void UpdateMovieAverage(SqlConnection connection, int movieId)
        {
            using SqlCommand command = new SqlCommand(@"UPDATE Movie_Data SET Average_Rating =
                (SELECT AVG(CAST(Rating AS DECIMAL(3,2))) FROM Movie_Ratings WHERE Movie_ID=@movieId) WHERE Movie_ID=@movieId", connection);
            command.Parameters.AddWithValue("@movieId", movieId);
            command.ExecuteNonQuery();
        }

        private void UpdateActorAverage(SqlConnection connection, int actorId)
        {
            using SqlCommand command = new SqlCommand(@"UPDATE Actor_Data SET Average_Rating =
                (SELECT AVG(CAST(Rating AS DECIMAL(3,2))) FROM Actor_Ratings WHERE Actor_ID=@actorId) WHERE Actor_ID=@actorId", connection);
            command.Parameters.AddWithValue("@actorId", actorId);
            command.ExecuteNonQuery();
        }

        private void UpdateCustomerAverage(SqlConnection connection, int customerId)
        {
            using SqlCommand command = new SqlCommand(@"UPDATE Customer_Data SET Average_Rating =
                (SELECT AVG(CAST(Rating AS DECIMAL(3,2))) FROM Movie_Ratings WHERE Customer_ID=@customerId) WHERE Customer_ID=@customerId", connection);
            command.Parameters.AddWithValue("@customerId", customerId);
            command.ExecuteNonQuery();
        }

        private void refresh_button_Click(object sender, EventArgs e)
        {
            LoadCustomers();
            LoadBestSellers();
            LoadAvailableMovies();
        }

        private void back_button_Click(object sender, EventArgs e) => Close();

        private void OpenHelpTopic(string topic)
        {
            using HelpForm helpForm = new HelpForm(topic);
            helpForm.ShowDialog(this);
        }

        private void helpOverviewToolStripMenuItem_Click(object sender, EventArgs e) => OpenHelpTopic(HelpTopics.GettingStarted);
        private void helpCustomersToolStripMenuItem_Click(object sender, EventArgs e) => OpenHelpTopic(HelpTopics.CustomerManagement);
        private void helpAboutToolStripMenuItem_Click(object sender, EventArgs e) => OpenHelpTopic(HelpTopics.About);

        private class PortalLookupItem
        {
            public int Id { get; }
            public string DisplayText { get; }
            public PortalLookupItem(int id, string displayText) { Id = id; DisplayText = displayText; }
            public override string ToString() => DisplayText;
        }
    }
}

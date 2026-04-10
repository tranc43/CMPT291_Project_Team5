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
    public partial class Movie_Form : Form
    {
        private readonly string connection = Database_Connection.connection_string;
        private int selected_movie_id = -1;

        public Movie_Form()
        {
            InitializeComponent();
        }

        private void movie_form_load(object sender, EventArgs e)
        {
            // checks if employee is logged in 
            if (!Access_Control.ensure_employee_logged_in(this))
            {
                return;
            }
            // genre dropdown selection
            genre_dropdown.Items.Clear();
            genre_dropdown.Items.AddRange(new string[] { "Action", "Comedy", "Drama", "Foreign" });
            genre_dropdown.SelectedIndex = 0;
            load_actors();
            load_movie_list();
            clear_fields();
        }

        private void load_movie_list()
        {
            /*@desc 
             * this functions purpose is to load the movie list
             * from the database into the data grid
             * it also implements the search functionality for movie name and genre. 
             */
            try
            {
                using (SqlConnection connectionNew = new SqlConnection(connection))
                {
                    connectionNew.Open();
                    string query = @"
                        SELECT
                            m.Movie_ID,
                            m.Movie_Name,
                            m.Movie_Genre,
                            m.Distribution_Fee,
                            m.Num_Copies,
                            (
                                SELECT AVG(CAST(rm.Rating AS DECIMAL(4,2)))
                                FROM Rate_Movie rm
                                INNER JOIN Order_Data od ON rm.Order_ID = od.Order_ID
                                WHERE od.Movie_ID = m.Movie_ID
                            ) AS Average_Rating
                        FROM Movie_Data m
                        WHERE (@name = '' OR m.Movie_Name LIKE '%' + @name + '%')
                          AND (@genre = '' OR m.Movie_Genre = @genre)
                        ORDER BY m.Movie_Name";
                    
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connectionNew);
              
                    adapter.SelectCommand.Parameters.AddWithValue("@name", search_movie_field.Text.Trim());
                    adapter.SelectCommand.Parameters.AddWithValue("@genre", genre_search_dropdown.Text == "All" ? "" : genre_search_dropdown.Text);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    movie_grid.DataSource = table;
                    movie_grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error loading movies: " + ex.Message);
            }
        }

        private void load_actors()
            /*@desc
             * loads the actors from the database into 
             * the actor dropdown. Has order by actor name and error handlings.
             */
        {
            actor_dropdown.Items.Clear();

            try
            {
                using (SqlConnection connectionNew = new SqlConnection(connection))
                {
                    connectionNew.Open();
                    string query = "SELECT Actor_ID, Actor_Name FROM Actor_Data ORDER BY Actor_Name";
                    SqlCommand command = new SqlCommand(query, connectionNew);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        actor_dropdown.Items.Add(new Lookup_Item(
                            Convert.ToInt32(reader["Actor_ID"]),
                            reader["Actor_Name"]?.ToString() ?? ""));
                    }
                }

                if (actor_dropdown.Items.Count > 0)
                {
                    actor_dropdown.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error loading actors: " + ex.Message);
            }
        }

        private void load_assigned_actors()
            /*@desc
             * 
             * this functons purpose is to load the actors that are 
             * parrt of a specific movie. 
             */
        {
            if (selected_movie_id == -1)
            {
                movie_actor_grid.DataSource = null;
                return;
            }

            try
            {
                using (SqlConnection connectionNew = new SqlConnection(connection))
                {
                    connectionNew.Open();
                    string query = @"
                        SELECT
                            a.Actor_ID,
                            a.Actor_Name,
                            a.Gender,
                            (
                                SELECT AVG(CAST(ra.Rating AS DECIMAL(4,2)))
                                FROM Rate_Actor ra
                                WHERE ra.Actor_ID = a.Actor_ID
                            ) AS Average_Rating
                        FROM Appears_In ai
                        INNER JOIN Actor_Data a ON ai.Actor_ID = a.Actor_ID
                        WHERE ai.Movie_ID = @movieId
                        ORDER BY a.Actor_Name";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connectionNew);
                    adapter.SelectCommand.Parameters.AddWithValue("@movieId", selected_movie_id);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    movie_actor_grid.DataSource = table;
                    movie_actor_grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error loading assigned actors: " + ex.Message);
            }
        }

        // ui elements
        private void load_movies_Click(object sender, EventArgs e)
        {
            load_movie_list();
        }

        private void search_button_Click(object sender, EventArgs e)
        {
            load_movie_list();
        }

        private void movie_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*@desc
             * this functions purpose is to load the selected movie data 
             * upon clicking a cell on the grid.
             * It also has error handling when clicking on a empty row.
             */
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row = movie_grid.Rows[e.RowIndex];

            if (row.IsNewRow ||
                row.Cells["Movie_ID"].Value == null ||
                row.Cells["Movie_ID"].Value == DBNull.Value)
            {
                return;
            }

            selected_movie_id = Convert.ToInt32(row.Cells["Movie_ID"].Value);
            title_field.Text = row.Cells["Movie_Name"].Value?.ToString() ?? "";
            genre_dropdown.SelectedItem = row.Cells["Movie_Genre"].Value?.ToString() ?? "Action";
            fee_field.Text = row.Cells["Distribution_Fee"].Value?.ToString() ?? "";
            num_copies.Text = row.Cells["Num_Copies"].Value?.ToString() ?? "";
            load_assigned_actors();
        }

        private void add_movie_Click(object sender, EventArgs e)
            /*@desc
             * this functions purpose
             * is to add a movie to the database 
             * it uses a string query to insert the movie into the database.
             */
        {
            if (!validate_movie_fields())
            {
                return;
            }

            try
            {
                using (SqlConnection connectionNew = new SqlConnection(connection))
                {
                    connectionNew.Open();
                    string query = "INSERT INTO Movie_Data (Movie_Name, Movie_Genre, Distribution_Fee, Num_Copies) VALUES (@name, @genre, @fee, @copies)";
                    SqlCommand command = new SqlCommand(query, connectionNew);
                    command.Parameters.AddWithValue("@name", title_field.Text.Trim());
                    command.Parameters.AddWithValue("@genre", genre_dropdown.SelectedItem?.ToString() ?? "Action");
                    command.Parameters.AddWithValue("@fee", decimal.Parse(fee_field.Text));
                    command.Parameters.AddWithValue("@copies", int.Parse(num_copies.Text));
                    command.ExecuteNonQuery();
                }

            // refreshing movie list and error handling
                MessageBox.Show("Movie added successfully!");
                load_movie_list();
                clear_fields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error adding a movie: " + ex.Message);
            }
        }

        private void update_movie_Click(object sender, EventArgs e)
            /*@desc
             * this functions purpose
             * is to update the move in the database
             * using a string query to update the movies in the database
             * it also has error handling
             */
        {
            if (selected_movie_id == -1)
            {
                MessageBox.Show("Please select a movie to update.");
                return;
            }

            if (!validate_movie_fields())
            {
                return;
            }

            try
            {
                using (SqlConnection connectionNew = new SqlConnection(connection))
                {
                    connectionNew.Open();
                    // Updating the movie data based on the selected movie ID and values.
                    string query = "UPDATE Movie_Data SET Movie_Name = @name, Movie_Genre = @genre, Distribution_Fee = @fee, Num_Copies = @copies WHERE Movie_ID = @id";
                    SqlCommand command = new SqlCommand(query, connectionNew);
                    command.Parameters.AddWithValue("@name", title_field.Text.Trim());
                    command.Parameters.AddWithValue("@genre", genre_dropdown.SelectedItem?.ToString() ?? "Action");
                    command.Parameters.AddWithValue("@fee", decimal.Parse(fee_field.Text));
                    command.Parameters.AddWithValue("@copies", int.Parse(num_copies.Text));
                    command.Parameters.AddWithValue("@id", selected_movie_id);
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Movie updated successfully!");
                load_movie_list();
                clear_fields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error updating a movie: " + ex.Message);
            }
        }

        private void delete_movie_Click(object sender, EventArgs e)
            /*@desc
             * this functions purpose is to handle 
             * deleting a movie. Before deleting a movie,
             * error handling is implemented to make sure that there is a movie
             * thats selected and then a second confirmation if the user wants to delete the movie 
             * However, before deleting the movie, there is a check to see
             * if the movie is currently in any existing orders. If there is a movie 
             * with an existing order, it'll throw the error message saying the movie cannot be deleted.
             * 
             */
        {
            if (selected_movie_id == -1)
            {
                MessageBox.Show("Please select a movie to delete.");
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this movie?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using (SqlConnection connectionNew = new SqlConnection(connection))
                {
                    connectionNew.Open();

                    // This section handles the logic of checking if movies are associated with an order and the process of deleting the movie.
                    SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM Order_Data WHERE Movie_ID = @id", connectionNew);
                    checkCommand.Parameters.AddWithValue("@id", selected_movie_id);
                    int orderCount = Convert.ToInt32(checkCommand.ExecuteScalar());

                    if (orderCount > 0)
                    {
                        MessageBox.Show("This movie cannot be deleted because it is associated with existing rentals.");
                        return;
                    }
                    // deletes everything associated with the movie like the actor assigned to it.
                    SqlCommand deleteAppearances = new SqlCommand("DELETE FROM Appears_In WHERE Movie_ID = @id", connectionNew);
                    deleteAppearances.Parameters.AddWithValue("@id", selected_movie_id);
                    deleteAppearances.ExecuteNonQuery();

                    SqlCommand deleteQueue = new SqlCommand("DELETE FROM Movie_Queue WHERE Movie_ID = @id", connectionNew);
                    deleteQueue.Parameters.AddWithValue("@id", selected_movie_id);
                    deleteQueue.ExecuteNonQuery();

                    SqlCommand command = new SqlCommand("DELETE FROM Movie_Data WHERE Movie_ID = @id", connectionNew);
                    command.Parameters.AddWithValue("@id", selected_movie_id);
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Movie deleted successfully!");
                load_movie_list();
                clear_fields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error deleting a movie: " + ex.Message);
            }
        }

        private void assign_actor_button_Click(object sender, EventArgs e)
        {
            /*@desc 
             * this functions serves for assigning actors to a movie
             * It ensures that movie and and actors are selected first prior to assigning.
             * 
             */
            if (selected_movie_id == -1)
            {
                MessageBox.Show("Please select a movie first.");
                return;
            }

            if (actor_dropdown.SelectedItem is not Lookup_Item actor)
            {
                MessageBox.Show("Please select an actor.");
                return;
            }

            try
            {
                using (SqlConnection connectionNew = new SqlConnection(connection))
                {
                    /*@desc
                     * When selecting an actor
                     * It checks whether or not the actor is already in the movie before assigning
                     * if they exist then it'll throw the error that the acotr is already assigned
                     * if they arent then they'll be inserted.
                     */
                    connectionNew.Open();
                    string check_query = "SELECT COUNT(*) FROM Appears_In WHERE Movie_ID = @movieId AND Actor_ID = @actorId";
                    SqlCommand check_command = new SqlCommand(check_query, connectionNew);
                    check_command.Parameters.AddWithValue("@movieId", selected_movie_id);
                    check_command.Parameters.AddWithValue("@actorId", actor.Id);

                    // checks if an actor already exists in the selected movie.
                    int existing_assignment_count = Convert.ToInt32(check_command.ExecuteScalar());

                    if (existing_assignment_count > 0)
                    {
                        MessageBox.Show("This actor is already assigned to the selected movie.");
                        return;
                    }

                    // inserting the actor once it has been successfully verified. 
                    string insert_query = "INSERT INTO Appears_In (Movie_ID, Actor_ID) VALUES (@movieId, @actorId)";
                    SqlCommand insert_command = new SqlCommand(insert_query, connectionNew);
                    insert_command.Parameters.AddWithValue("@movieId", selected_movie_id);
                    insert_command.Parameters.AddWithValue("@actorId", actor.Id);
                    insert_command.ExecuteNonQuery();
                }
                // Reloading the assigned actors.
                load_assigned_actors();
                MessageBox.Show("Actor assigned successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error assigning the actor: " + ex.Message);
            }
        }

        private void remove_actor_button_Click(object sender, EventArgs e)
        {
            /*@desc
             * this functions serves 
             * for removing the actors, it make sures if there is a movie and actor selected first
             * before removing anything. then verifies if the actor is assigned to the movie or not
             */
            if (selected_movie_id == -1)
            {
                MessageBox.Show("Please select a movie first.");
                return;
            }

            DialogResult result = MessageBox.Show("" +
                "Are you Sure you want to delete this actor?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                return;
            }

            if (movie_actor_grid.CurrentRow == null || movie_actor_grid.CurrentRow.Cells["Actor_ID"].Value == null)
            {
                MessageBox.Show("Please select an assigned actor to remove.");
                return;
            }
            // Retrieves the actor ID
            int actorId = Convert.ToInt32(movie_actor_grid.CurrentRow.Cells["Actor_ID"].Value);

            try
            {
                using (SqlConnection connectionNew = new SqlConnection(connection))
                {
                    // This query checks if the actor is assigned to the movie before attempting to remove them
                    connectionNew.Open();
                    SqlCommand command = new SqlCommand("DELETE FROM Appears_In WHERE Movie_ID = @movieId AND Actor_ID = @actorId", connectionNew);
                    command.Parameters.AddWithValue("@movieId", selected_movie_id);
                    command.Parameters.AddWithValue("@actorId", actorId);
                    command.ExecuteNonQuery();
                }
                // Reloading the assigned actors upon removing.
                load_assigned_actors();
                MessageBox.Show("Actor removed successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error removing the actor: " + ex.Message);
            }
        }

        private bool validate_movie_fields()
        {
            /*@desc
             * this method is used to validate movie fields 
             * such as all the movie fields,
             * distribution fee and number of copies
             */
            if (string.IsNullOrWhiteSpace(title_field.Text) || string.IsNullOrWhiteSpace(fee_field.Text) || string.IsNullOrWhiteSpace(num_copies.Text))
            {
                MessageBox.Show("All movie fields must be entered.");
                return false;
            }

            if (!decimal.TryParse(fee_field.Text, out decimal fee) || fee < 0)
            {
                MessageBox.Show("Distribution fee must be a valid positive number.");
                return false;
            }

            if (!int.TryParse(num_copies.Text, out int copies) || copies < 0)
            {
                MessageBox.Show("Number of copies must be a valid positive whole number.");
                return false;
            }

            return true;
        }

        private void clear_fields()
            /*@desc: this functions is used to clear the fields
             * and resetting everything back to default.
             * 
             */
        {
            title_field.Text = "";
            fee_field.Text = "";
            num_copies.Text = "";
            genre_dropdown.SelectedItem = "Action";
            selected_movie_id = -1;
            movie_actor_grid.DataSource = null;
        }
        /* this section for the code is for the buttons like the back button,
         * clear button, Help button, etc.
         */
        private void clear_button_Click(object sender, EventArgs e)
        {
            clear_fields();
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        // this class is used to represent items in the actor dropdown 
        private class Lookup_Item
        {
            public int Id;
            public string display_text;

            public Lookup_Item(int id, string display_text_value)
            {
                Id = id;
                display_text = display_text_value;
            }

            public override string ToString()
            {
                return display_text;
            }
        }
    }
}

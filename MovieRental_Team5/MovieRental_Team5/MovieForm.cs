using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace MovieRental_Team5
{
    public partial class MovieForm : Form
    {
        string connection = @"Server=DESKTOP-CHLK2FI\SQLEXPRESS;Database=MovieRental_Team5;Trusted_Connection=yes;";
        private int selectedMovieID = -1; // for tracking movies editing/deleting
        public MovieForm()
        {
            InitializeComponent();
        }

        private void MovieForm_Load(object sender, EventArgs e)
        {
            genre_dropdown.Items.Clear();
            genre_dropdown.Items.AddRange(new string[] { " Action", "Comedy", "Drama", "Foreign" });
            genre_dropdown.SelectedIndex = 0;
            load_movie();
        }
        private void load_movie()
        {
            try
            {
                using (SqlConnection connection_new = new SqlConnection(connection))
                {
                    connection_new.Open();
                    string movie_query = "SELECT Movie_ID, Movie_Name, Movie_Genre, Distribution_Fee, Num_Copies, Average_Rating FROM Movie_Data";
                    SqlDataAdapter adapter = new SqlDataAdapter(movie_query, connection);
                    DataTable data_t = new DataTable();
                    adapter.Fill(data_t);
                    movie_grid.DataSource = data_t;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error loading movies: " + ex.Message);
            }
        }

        private void load_movies_Click(object sender, EventArgs e)
        {
            load_movie();
        }

        private void movie_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = movie_grid.Rows[e.RowIndex];
                selectedMovieID = Convert.ToInt32(row.Cells["Movie_ID"].Value);
                title_search.Text = row.Cells["Movie_Name"].Value.ToString();
                genre_dropdown.SelectedItem = row.Cells["Movie_Genre"].Value.ToString().Trim();
                distribution_fee.Text = row.Cells["Distribution_Fee"].Value.ToString();
                num_copies.Text = row.Cells["Num_Copies"].Value.ToString();

            }
        }

        private void add_movie_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(title_search.Text) || string.IsNullOrEmpty(fee_field.Text) || string.IsNullOrEmpty(num_copies.Text))
            {
                MessageBox.Show("There is an error! All fields must be entered!"); return;
            }

            try
            {
                using (SqlConnection connection_new = new SqlConnection(connection))
                {
                    connection_new.Open();
                    string insert_query = "INSERT INTO Movie_Data (Movie_Name, Movie_Genre, Distribution_Fee, Num_Copies) VALUES (@name, @genre, @fee, @copies)";
                    SqlCommand cmd = new SqlCommand(insert_query, connection_new);
                    cmd.Parameters.AddWithValue("@name", title_search.Text.Trim());
                    cmd.Parameters.AddWithValue("@genre", genre_dropdown.SelectedItem.ToString().Trim());
                    cmd.Parameters.AddWithValue("@fee", decimal.Parse(fee_field.Text));
                    cmd.Parameters.AddWithValue("@copies", int.Parse(num_copies.Text));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Movie added successfully!");
                    load_movie();
                    clear_fields();
                }
            }
            catch (Exception ex) { MessageBox.Show("There is an error adding a movie " + ex); }

        }



        private void clear_fields()
        {
            // this functions purpose is to clear all the fields and reset the movie ID
            title_search.Text = "";
            fee_field.Text = "";
            num_copies.Text = "";
            genre_dropdown.SelectedIndex = 0;
            selectedMovieID = -1;
        }
        private void clear_button_Click(object sender, EventArgs e)
        {
            // This functions purpose is to clear all the fields
            clear_fields();
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void update_movie_Click(object sender, EventArgs e)
        {
            if (selectedMovieID == -1)
            {
                MessageBox.Show("Error! Please select a movie in order to update");
                return;
            }

            try
            {
                using (SqlConnection connection_new = new SqlConnection(connection))
                {
                    connection_new.Open();
                    string update_query = "UPDATE Movie_Data SET Movie_Name = @name, Movie_Genre = @genre, Distribution_Fee = @fee, Num_Copies = @copies WHERE Movie_ID = @id";
                    SqlCommand cmd = new SqlCommand(update_query, connection_new);
                    cmd.Parameters.AddWithValue("@name", title_search.Text.Trim());
                    cmd.Parameters.AddWithValue("@genre", genre_dropdown.SelectedItem.ToString().Trim());
                    cmd.Parameters.AddWithValue("@fee", decimal.Parse(fee_field.Text));
                    cmd.Parameters.AddWithValue("@copies", int.Parse(num_copies.Text));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Success! Movie updated successfully!");
                    load_movie();
                    clear_fields();
                }
            }
            catch (Exception ex) { MessageBox.Show("There is an error updating a movie " + ex); }
        }

        private void delete_movie_Click(object sender, EventArgs e)
        {
            if (selectedMovieID == -1)
            {
                MessageBox.Show("Error! Please select a movie in order to delete");
                return;
            }
            DialogResult result = MessageBox.Show("Are you sure you want to delete this movie?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try                 {
                    using (SqlConnection connection_new = new SqlConnection(connection))
                    {
                        connection_new.Open();
                        // Checks if the movie is associated with any existing rentals. 
                        string check_query = "SELECT COUNT(*) FROM Order_Data WHERE Movie_ID = @id";
                        SqlCommand checkCmd = new SqlCommand(check_query, connection_new);
                        checkCmd.Parameters.AddWithValue("@id", selectedMovieID);
                        int order_count = (int)checkCmd.ExecuteScalar();

                        if (order_count > 0)
                        {
                            MessageBox.Show("Error! This movie cannot be deleted because it is associated with existing rentals.");
                            return;
                        }

                        // Deletion confirmation and deleting movie.
                    
                        string delete_query = "DELETE FROM Movie_Data WHERE Movie_ID = @id";
                        SqlCommand cmd = new SqlCommand(delete_query, connection_new);
                        cmd.Parameters.AddWithValue("@id", selectedMovieID);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Success! Movie deleted successfully!");
                        load_movie();
                        clear_fields();
                    }
                }
                catch (Exception ex) { MessageBox.Show("There is an error deleting a movie " + ex); }
            }
        }
    }
}

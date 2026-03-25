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
            load_movies();
        }
        private void load_movies()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connection))
                {
                    connection.Open();
                    string movie_query = "SELECT Movie_ID, Movie_Name, Movie_Genre, Distribution_Fee, Num_Copies, Average_Rating FROM Movie_Data";
                    SqlDataAdapter adapter = new SqlDataAdapter(movie_query, connection);
                    DataTable data_t = new DataTable();
                    adapter.Fill(data_t);
                    movie_grid.DataSource = data_t;
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}

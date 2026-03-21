using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MovieRental_Team5
{
    public partial class Form1 : Form
    {
        string connectionString = @"Server=ServerName;Database=MovieRental_Team5;Trusted_Connection=yes;";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    MessageBox.Show("Database connection successful!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database connection failed: " + ex.Message);
            }
        }
    }
}
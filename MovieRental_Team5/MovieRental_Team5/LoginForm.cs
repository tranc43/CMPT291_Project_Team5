using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MovieRental_Team5
{
    public partial class LoginForm : Form
    {
        string connectionString = @"Server=;Database=MovieRental_Team5;Trusted_Connection=yes;";

        public LoginForm()
        {
            InitializeComponent();
        }
        // this is making sure if the sql connection succeeds. If it does, it will show a message box saying "Database connection successful!" If it fails, it will show a message box with the error message.
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
        private void LoginButton_Click(object sender, EventArgs e)
        {
            string email = EmailField.Text.Trim();

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Error", "Please enter your email :(");
                return;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Employee Reader
                    string employee_query = "SELECT Employee_ID, First_Name, Last_Name FROM Employee_Data WHERE SIN = @input";
                    SqlCommand empCmd = new SqlCommand(employee_query, conn);

                    empCmd.Parameters.AddWithValue("@input", email);
                    SqlDataReader empReader = empCmd.ExecuteReader();

                    if (empReader.HasRows)
                    {
                        empReader.Read();
                        string employee_name = empReader["First_Name"].ToString() + empReader["Last_Name"].ToString();
                        empReader.Close();
                        MessageBox.Show("Login Successful! " + " Welcome Back, " + employee_name + " ! ");
                        return;

                    }
                    empReader.Close();

                    // Customer check
                    string customer_query = "SELECT Customer_ID, First_Name, Last_Name FROM Customer_Data WHERE Email_Address = @input";
                    SqlCommand customer_cmd = new SqlCommand(customer_query, conn);

                    customer_cmd.Parameters.AddWithValue("@input", email);
                    SqlDataReader customer_reader = customer_cmd.ExecuteReader();

                    if (customer_reader.HasRows)
                    {
                        customer_reader.Read();
                        string customer_name = customer_reader["First_Name"].ToString() + customer_reader["Last_Name"].ToString();
                        customer_reader.Close();
                        MessageBox.Show("Login Successful!" + "Welcome Back," + customer_name + "!");
                        return;

                    }
                    customer_reader.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + "there is an error!");
            }
        }

        private void EmailAddressInput(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Exit_Application_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

   
    }
}
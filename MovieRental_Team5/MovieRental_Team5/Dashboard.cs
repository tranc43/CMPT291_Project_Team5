using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MovieRental_Team5
{
    public partial class Dashboard_Form : Form
    {
        private string employee_name;
        public Dashboard_Form(string name)
        {
            InitializeComponent();
            employee_name = name;
        }

        private void manage_customers_Click(object sender, EventArgs e)
        {
            CustomerForm customerForm = new CustomerForm();
            customerForm.Show();
        }

        private void Title_Click(object sender, EventArgs e)
        {
            welcome_title.Text = "Welcome, " + employee_name + "!";
        }

        private void log_out_button_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void orders_Click(object sender, EventArgs e)
        {
            OrderForm orderForm = new OrderForm();
            orderForm.Show();
        }


        private void manage_movies_Click(object sender, EventArgs e)
        {
            MovieForm movieForm = new MovieForm();
            movieForm.Show();
        }

        private void reports_button_Click(object sender, EventArgs e)
        {
            ReportsForm reportsForm = new ReportsForm();
            reportsForm.Show();
        }
    }
}

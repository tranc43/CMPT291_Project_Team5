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
            Load += Dashboard_Form_Load;
        }

        private void manage_customers_Click(object sender, EventArgs e)
        {
            CustomerForm customerForm = new CustomerForm();
            customerForm.Show();
        }

        private void Dashboard_Form_Load(object sender, EventArgs e)
            /*@desc: this functions purpose is to display welcome and whos currently logged in
             * 
             */
        {
            string displayName = employee_name;

            if (!string.IsNullOrWhiteSpace(CurrentSession.EmployeeName))
            {
                displayName = CurrentSession.EmployeeName;
            }

            welcome_title.Text = "Employee Movie Rental Dashboard";
            logged_in_as_label.Text = "Logged in as: " + displayName;
        }

        private void log_out_button_Click(object sender, EventArgs e)
        {
            /*@desc: this functions purpose is to log out the user and go to login 
             * 
             */
            CurrentSession.Clear();
            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void orders_Click(object sender, EventArgs e)

        {
            /*@desc: this functions purpose is to go to the order form 
            * 
            */
            OrderForm orderForm = new OrderForm();
            orderForm.Show();
        }


        private void manage_movies_Click(object sender, EventArgs e)
        {
            /*@desc: functions purpose is to go to manage movies
            * 
            */
            MovieForm movieForm = new MovieForm();
            movieForm.Show();
        }

        private void reports_button_Click(object sender, EventArgs e)
        {
            /*@desc: functiosn purpose is to go to reports 
            * 
            */
            ReportsForm reportsForm = new ReportsForm();
            reportsForm.Show();
        }
    }
}

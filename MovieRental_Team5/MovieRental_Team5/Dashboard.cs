/* CLASS: CMPT 291
 * LAB: X02L
 * ASSIGNMENT: RENTAL DATABASE PROJECT
 * AUTHOR(S): TEAM 5 - FIN, CHRISTIAN, BRICE, PIERRE
 * DUE DATE: APRIL 10TH 2025
 */
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
            Load += dashboard_form_load;
        }

        private void manage_customers_Click(object sender, EventArgs e)
        {
            Customer_Form customer_form = new Customer_Form();
            customer_form.Show();
        }

        private void dashboard_form_load(object sender, EventArgs e)
            /*@desc: this functions purpose is to display welcome and whos currently logged in
             * 
             */
        {
            if (!Access_Control.ensure_employee_logged_in(this))
            {
                return;
            }

            string display_name = employee_name;

            if (!string.IsNullOrWhiteSpace(Current_Session.employee_name))
            {
                display_name = Current_Session.employee_name;
            }

            welcome_title.Text = "Employee Movie Rental Dashboard";
            logged_in_as_label.Text = "Logged in as: " + display_name;
        }

        private void log_out_button_Click(object sender, EventArgs e)
        {
            /*@desc: this functions purpose is to log out the user and go to login 
             * 
             */
            Current_Session.clear();
            this.Close();
            Login_Form login_form = new Login_Form();
            login_form.Show();
        }

        private void orders_Click(object sender, EventArgs e)

        {
            /*@desc: this functions purpose is to go to the order form 
            * 
            */
            Order_Form order_form = new Order_Form();
            order_form.Show();
        }


        private void manage_movies_Click(object sender, EventArgs e)
        {
            /*@desc: functions purpose is to go to manage movies
            * 
            */
            Movie_Form movie_form = new Movie_Form();
            movie_form.Show();
        }

        private void reports_button_Click(object sender, EventArgs e)
        {
            /*@desc: functiosn purpose is to go to reports 
            * 
            */
            Reports_Form reports_form = new Reports_Form();
            reports_form.Show();
        }
    }
}

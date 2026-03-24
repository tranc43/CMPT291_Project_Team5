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

        }

        private void Title_Click(object sender, EventArgs e)
        {
            welcome_title.Text = "Welcome, " + employee_name + "!";
        }
    }
}

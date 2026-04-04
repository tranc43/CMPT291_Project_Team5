using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MovieRental_Team5
{
    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();
            Load += ReportsForm_Load;
        }

        private void ReportsForm_Load(object? sender, EventArgs e)
        {
            AccessControl.EnsureEmployeeLoggedIn(this);
        }
    }
}

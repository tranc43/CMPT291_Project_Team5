
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
    public partial class Reports_Form : Form
    {
        private readonly string connection_string = Database_Connection.connection_string;

        public Reports_Form()
        {
            InitializeComponent();
            Load += reports_form_load;
        }
        // referencing the function in accescontrol.cs to ensure that an employee is logged in before accessing.
        private void reports_form_load(object? sender, EventArgs e)
        {
            if (!Access_Control.ensure_employee_logged_in(this))
            {
                return;
            }

            report_selector.SelectedIndex = 0;
            load_selected_report();
        }

        private void run_report_button_Click(object sender, EventArgs e)
        {
            load_selected_report();
        }

        private void load_selected_report()
        {
            /*@desc 
             * This functions purpose is to serve for loading the 5 reports of the database
             * the following reports are as follows:
             * 1. Monthly Revenue
             * 2. TOp 3 Most Rented Movies
             * 3. Top 3 Employees by Revenue
             * 4. Top 3 Actors
             * 5. Top 3 most active customers.
             */
            string query = report_selector.SelectedIndex switch
            {
                0 => @"SELECT MONTH(Checkout) AS [month], YEAR(Checkout) AS [year], SUM(Distribution_Fee) AS [rev]
                       FROM Order_Data AS o,
                            Movie_Data AS m
                       WHERE o.Movie_ID = m.Movie_ID
                       GROUP BY MONTH(Checkout), YEAR(Checkout)
                       ORDER BY YEAR(Checkout), MONTH(Checkout)",
                1 => @"SELECT TOP 3 Movie_Name
                       FROM (
                           SELECT Movie_Name, COUNT(o.Movie_ID) AS num
                           FROM Order_Data AS o,
                                Movie_Data AS m
                           WHERE o.Movie_ID = m.Movie_ID
                           GROUP BY Movie_Name
                       ) AS q
                       ORDER BY num DESC",
                2 => @"SELECT TOP 3 First_Name, rev
                       FROM Employee_Data AS e,
                            (
                                SELECT Employee_ID, SUM(Distribution_Fee) AS [rev]
                                FROM Order_Data AS o,
                                     Movie_Data AS m
                                WHERE o.Movie_ID = m.Movie_ID
                                GROUP BY Employee_ID
                            ) AS q
                       WHERE e.Employee_ID = q.Employee_ID
                       ORDER BY rev DESC",
                3 => @"SELECT TOP 3 Actor_Name, rating
                       FROM (
                           SELECT Actor_Name, AVG(Rating) AS [rating]
                           FROM Actor_Data AS a,
                                Rate_Actor AS r
                           WHERE a.Actor_ID = r.Actor_ID
                           GROUP BY Actor_Name
                       ) AS q
                       ORDER BY rating DESC",
                _ => @"SELECT TOP 3 First_Name
                       FROM (
                           SELECT First_Name, COUNT(o.Customer_ID) AS [num]
                           FROM Customer_Data AS c,
                                Order_Data AS o
                           WHERE c.Customer_ID = o.Customer_ID
                           GROUP BY First_Name
                       ) AS q
                       ORDER BY num DESC"
            };

            try
            {
                // Connecting to the database and executing the queries above to  fill the datagridview.
                using (SqlConnection connection = new SqlConnection(connection_string))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    report_grid.DataSource = table;
                    report_grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error loading the report: " + ex.Message);
            }
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

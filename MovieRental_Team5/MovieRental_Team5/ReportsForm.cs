using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MovieRental_Team5
{
    public partial class ReportsForm : Form
    {
        private readonly string connectionString = DatabaseConnection.ConnectionString;

        public ReportsForm()
        {
            InitializeComponent();
            Load += ReportsForm_Load;
        }

        private void ReportsForm_Load(object? sender, EventArgs e)
        {
            if (!AccessControl.EnsureEmployeeLoggedIn(this))
            {
                return;
            }

            report_selector.SelectedIndex = 0;
            LoadSelectedReport();
        }

        private void run_report_button_Click(object sender, EventArgs e)
        {
            LoadSelectedReport();
        }

        private void LoadSelectedReport()
        {
            string query = report_selector.SelectedIndex switch
            {
                0 => @"SELECT TOP (10) m.Movie_Name, m.Movie_Genre, COUNT(*) AS Total_Rentals
                       FROM Order_Data o
                       INNER JOIN Movie_Data m ON o.Movie_ID = m.Movie_ID
                       GROUP BY m.Movie_Name, m.Movie_Genre
                       ORDER BY COUNT(*) DESC, m.Movie_Name",
                1 => @"SELECT TOP (10) c.Customer_ID, c.First_Name, c.Last_Name, COUNT(*) AS Total_Orders
                       FROM Order_Data o
                       INNER JOIN Customer_Data c ON o.Customer_ID = c.Customer_ID
                       GROUP BY c.Customer_ID, c.First_Name, c.Last_Name
                       ORDER BY COUNT(*) DESC, c.Last_Name, c.First_Name",
                2 => @"SELECT m.Movie_Name, COUNT(*) AS Active_Rentals
                       FROM Order_Data o
                       INNER JOIN Movie_Data m ON o.Movie_ID = m.Movie_ID
                       WHERE DATETIMEFROMPARTS(o.Return_Year, o.Return_Month, o.Return_Day,
                           DATEPART(HOUR, o.Return_Time), DATEPART(MINUTE, o.Return_Time), DATEPART(SECOND, o.Return_Time), 0) > GETDATE()
                       GROUP BY m.Movie_Name
                       ORDER BY COUNT(*) DESC, m.Movie_Name",
                3 => @"SELECT TOP (10) a.Actor_Name, COUNT(*) AS Movie_Count, AVG(CAST(ISNULL(a.Average_Rating, 0) AS DECIMAL(4,2))) AS Average_Rating
                       FROM Appears_In ai
                       INNER JOIN Actor_Data a ON ai.Actor_ID = a.Actor_ID
                       GROUP BY a.Actor_Name
                       ORDER BY COUNT(*) DESC, a.Actor_Name",
                _ => @"SELECT c.Customer_ID, c.First_Name, c.Last_Name, COUNT(q.Movie_ID) AS Queue_Size
                       FROM Customer_Data c
                       LEFT JOIN Queue q ON c.Customer_ID = q.Customer_ID
                       GROUP BY c.Customer_ID, c.First_Name, c.Last_Name
                       ORDER BY COUNT(q.Movie_ID) DESC, c.Last_Name, c.First_Name"
            };

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
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

        private void OpenHelpTopic(string topic)
        {
            using (HelpForm helpForm = new HelpForm(topic))
            {
                helpForm.ShowDialog(this);
            }
        }

        private void helpOverviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenHelpTopic(HelpTopics.GettingStarted);
        }

        private void helpReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenHelpTopic(HelpTopics.Reports);
        }

        private void helpAboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenHelpTopic(HelpTopics.About);
        }
    }
}

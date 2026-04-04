using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MovieRental_Team5
{
    public partial class LoginForm : Form
    {
        string connectionString = DatabaseConnection.ConnectionString;

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
            string sin = EmailField.Text.Trim();
            string password = PasswordField.Text;

            if (string.IsNullOrEmpty(sin) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter your employee SIN and password.", "Login Error");
                return;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string employee_query = "SELECT Employee_ID, First_Name, Last_Name, Employee_Password FROM Employee_Data WHERE SIN = @input";
                    SqlCommand empCmd = new SqlCommand(employee_query, conn);

                    empCmd.Parameters.AddWithValue("@input", sin);
                    SqlDataReader empReader = empCmd.ExecuteReader();

                    if (empReader.HasRows)
                    {
                        empReader.Read();
                        string storedPassword = empReader["Employee_Password"].ToString();
                        bool passwordMatches = PasswordSecurity.VerifyPassword(password, storedPassword);

                        if (!passwordMatches)
                        {
                            empReader.Close();
                            MessageBox.Show("Invalid employee SIN or password.", "Login Error");
                            return;
                        }

                        int employeeId = Convert.ToInt32(empReader["Employee_ID"]);
                        string employee_name = empReader["First_Name"].ToString() + " " + empReader["Last_Name"].ToString();
                        bool passwordNeedsUpgrade = !PasswordSecurity.IsHashed(storedPassword);

                        empReader.Close();

                        if (passwordNeedsUpgrade)
                        {
                            UpgradeEmployeePassword(conn, employeeId, password);
                        }

                        CurrentSession.SetEmployee(employeeId, sin, employee_name);

                        MessageBox.Show("Login Successful! " + " Welcome Back, " + employee_name + " ! ");
                        Dashboard_Form dashboard = new Dashboard_Form(employee_name);
                        dashboard.Show();
                        this.Hide();
                        return;
                    }

                    MessageBox.Show("Invalid employee SIN or password.", "Login Error");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + "there is an error!");
            }
        }

        private void UpgradeEmployeePassword(SqlConnection conn, int employeeId, string plainTextPassword)
        {
            /*@desc 
             * this function is responsible for hashing employee passwords that are stored in the database thats plain text.
             * 
             */
            string updateQuery = "UPDATE Employee_Data SET Employee_Password = @password WHERE Employee_ID = @employeeId";
            using (SqlCommand updateCommand = new SqlCommand(updateQuery, conn))
            {
                updateCommand.Parameters.AddWithValue("@password", PasswordSecurity.HashPassword(plainTextPassword));
                updateCommand.Parameters.AddWithValue("@employeeId", employeeId);
                updateCommand.ExecuteNonQuery();
            }
        }

        private void EmailAddressInput(object sender, EventArgs e)
        {
            // Its being read in the function above
        }

        /* The following section involves 
         * the help menu and customer portal button,
         * The help menu provides a guide on how to use the application,
         * While the customer portal button allows customers to access their account and view the 
         * rental history.
         */
        private void Exit_Application_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CustomerPortalButton_Click(object sender, EventArgs e)
        {
            CustomerPortalForm customerPortalForm = new CustomerPortalForm();
            customerPortalForm.Show();
        }

        private void OpenHelpTopic(string topic)
        {
            using (HelpForm helpForm = new HelpForm(topic))
            {
                helpForm.ShowDialog(this);
            }
        }

        private void helpGettingStartedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenHelpTopic(HelpTopics.GettingStarted);
        }

        private void helpLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenHelpTopic(HelpTopics.Login);
        }

        private void helpAboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenHelpTopic(HelpTopics.About);
        }
    }
}

/* CLASS: CMPT 291
 * LAB: X02L
 * ASSIGNMENT: RENTAL DATABASE PROJECT
 * AUTHOR(S): TEAM 5 - FIN, CHRISTIAN, BRICE, PIERRE
 * DUE DATE: APRIL 10TH 2025
 */

using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MovieRental_Team5
{
    public partial class Login_Form : Form
    {
        private readonly string connection_string = Database_Connection.connection_string;

        public Login_Form()
        {
            InitializeComponent();
        }
        // this is making sure if the sql connection succeeds. If it does, it will show a message box saying "Database connection successful!" If it fails, it will show a message box with the error message.
        private void form_1_load(object sender, EventArgs e)
        {
            /*@desc 
             * this function is for testing that youve successfully connected
             * to the database.
             */
            try
            {
                using (SqlConnection connection = new SqlConnection(connection_string))
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
        private void login_button_click(object sender, EventArgs e)
        {
            /*@desc
             * this function is used for handling the logic implementation
             * there are error checks in place to assure various scenarios are handled
             * The functions also implements the hashing of employee passwords and updating them as the hash version in the DB.
             */
            string sin = email_field.Text.Trim();
            string password = password_field.Text;

            if (string.IsNullOrEmpty(sin) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter your employee SIN and password.", "Login Error");
                return;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(connection_string))
                {
                    conn.Open();
                    // this query is used to retrieve employee data based on the the provided sin 
                    string employee_query = "SELECT Employee_ID, First_Name, Last_Name, Employee_Password FROM Employee_Data WHERE SIN = @input";
                    SqlCommand emp_cmd = new SqlCommand(employee_query, conn);

                    emp_cmd.Parameters.AddWithValue("@input", sin);
                    SqlDataReader emp_reader = emp_cmd.ExecuteReader();
                    
                  // password matching using the PasswordSecurity file which handles the hashing and vericiation of passwords.
                    if (emp_reader.HasRows)
                    {
                        emp_reader.Read();
                        string stored_password = emp_reader["Employee_Password"].ToString();
                        bool password_matches = Password_Security.verify_password(password, stored_password);
                        // if the employee exists but the password is wrong, show an invalid password error.
                        if (!password_matches)
                        {
                            emp_reader.Close();
                            MessageBox.Show("Invalid password.", "Login Error");
                            return;
                        }
      
                        // we check if the passsword needs to be hashed and updated in the database.
                        int employee_id = Convert.ToInt32(emp_reader["Employee_ID"]);
                        string employee_name = emp_reader["First_Name"].ToString() + " " + emp_reader["Last_Name"].ToString();
                        bool password_needs_upgrade = !Password_Security.is_hashed(stored_password);

                        emp_reader.Close();
                        // this is just for the already existing passwords in plain text in the DB, it just hashes
                        if (password_needs_upgrade)
                        {
                            upgrade_employee_password(conn, employee_id, password);
                        }

                        Current_Session.set_employee(employee_id, sin, employee_name);
                        // success!
                        MessageBox.Show("Login Successful! " + " Welcome Back, " + employee_name + " ! ");
                        Dashboard_Form dashboard_form = new Dashboard_Form(employee_name);
                        dashboard_form.Show();
                        this.Hide();
                        return;
                    }

                    MessageBox.Show("Invalid employee SIN.", "Login Error");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + "there is an error!");
            }
        }

        private void upgrade_employee_password(SqlConnection conn, int employee_id, string plain_text_password)
        {
            /*@desc 
             * this function is responsible for hashing employee passwords that are stored in the database thats plain text.
             * 
             */
            string update_query = "UPDATE Employee_Data SET Employee_Password = @password WHERE Employee_ID = @employeeId";
            using (SqlCommand update_command = new SqlCommand(update_query, conn))
            {
                update_command.Parameters.AddWithValue("@password", Password_Security.hash_password(plain_text_password));
                update_command.Parameters.AddWithValue("@employeeId", employee_id);
                update_command.ExecuteNonQuery();
            }
        }

        private void email_address_input(object sender, EventArgs e)
        {
            // Its being read in the function above
        }
        private void exit_application_click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

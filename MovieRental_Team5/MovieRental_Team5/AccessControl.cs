using System.Windows.Forms;

namespace MovieRental_Team5
{
    /*@desc 
     * This file handles user access control for the application
     * It ensures to check whether or not the employee is logged in or not else it'll 
     * warn the user and close the form. This is used in the dashboard form to ensure that only employees can access it.
     */
    internal static class AccessControl
    {
        public static bool EnsureEmployeeLoggedIn(Form form)
        {
            if (CurrentSession.EmployeeId != -1)
            {
                return true;
            }

            MessageBox.Show(
                "Please log in as an employee to access this screen.",
                "Access Denied",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            form.Close();
            return false;
        }
    }
}

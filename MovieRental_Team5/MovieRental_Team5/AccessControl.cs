using System.Windows.Forms;

namespace MovieRental_Team5
{
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

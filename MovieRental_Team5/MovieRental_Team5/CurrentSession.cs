namespace MovieRental_Team5
{
    internal static class CurrentSession
    {
        public static int EmployeeId = -1;
        public static string EmployeeSin = "";
        public static string EmployeeName = "";

        public static void SetEmployee(int employeeId, string employeeSin, string employeeName)

        {
            /*@desc: this functions purpose is to set the current employeee session with data
            * 
            */
            EmployeeId = employeeId;
            EmployeeSin = employeeSin;
            EmployeeName = employeeName;
        }

        public static void Clear()
        {
            /*@desc: this functions purpose is to clear the employee session data. 
            * 
            */
            EmployeeId = -1;
            EmployeeSin = "";
            EmployeeName = "";
        }
    }
}

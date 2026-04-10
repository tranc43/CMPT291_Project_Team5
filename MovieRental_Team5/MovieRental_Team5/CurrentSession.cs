/* CLASS: CMPT 291
 * LAB: X02L
 * ASSIGNMENT: RENTAL DATABASE PROJECT
 * AUTHOR(S): TEAM 5 - FIN, CHRISTIAN, BRICE, PIERRE
 * DUE DATE: APRIL 10TH 2025
 */

namespace MovieRental_Team5
{
    internal static class Current_Session
    {
        /* initializing variables
         * to hold employee data fo rth ecurrent session.
         */
        public static int employee_id = -1;
        public static string employee_login_id = "";
        public static string employee_name = "";

        public static void set_employee(int employee_id_value, string employee_login_id_value, string employee_name_value)

        {
            /*@desc: this functions purpose is to set the current employeee session with data
            * 
            */
            employee_id = employee_id_value;
            employee_login_id = employee_login_id_value;
            employee_name = employee_name_value;
        }

        public static void clear()
        {
            /*@desc: this functions purpose is to clear the employee session data. 
            * 
            */
            employee_id = -1;
            employee_login_id = "";
            employee_name = "";
        }
    }
}

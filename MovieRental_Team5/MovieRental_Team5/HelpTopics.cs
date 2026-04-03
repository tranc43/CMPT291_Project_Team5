using System.Collections.Generic;

namespace MovieRental_Team5
{
    internal static class HelpTopics
    {
        public const string GettingStarted = "Getting Started";
        public const string Login = "Login";
        public const string Dashboard = "Dashboard";
        public const string Movies = "Movies";
        public const string Orders = "Orders";
        public const string CustomerManagement = "Customer Management";
        public const string Reports = "Reports";
        public const string About = "About";

        private static readonly Dictionary<string, string> TopicContent = new Dictionary<string, string>
        {
            [GettingStarted] =
                "Welcome to the CMPT291 Team 5 Movie Rental Application!.\r\n\r\n" +
                "The Help menu on each screen to jump directly to task-specific guidance. " +
                "The employee workflow usually follows these steps:\r\n" +
                "1. Sign in with your employee SIN and password.\r\n" +
                "2. Open the Dashboard.\r\n" +
                "3. Manage movies, record orders, or even open reports!.\r\n" +
                "4. Log out once you are done.\r\n\r\n" +
                "If a screen shows a database error, confirm that the SQL Server connection in App.config is valid and reachable.",

            [Login] =
                "Login Screen\r\n\r\n" +
                "Enter your employee SIN and password, then click Login.\r\n\r\n" +
                "Tips:\r\n" +
                "- Both fields are required.\r\n" +
                "- Successful login opens the employee dashboard.\r\n" +
                "- Invalid credentials will show a login error message.\r\n" +
                "- Use Exit Application to close the program safely.",

            [Dashboard] =
                "Dashboard\r\n\r\n" +
                "The dashboard is the main navigation hub for employee tasks.\r\n\r\n" +
                "Available actions:\r\n" +
                "- Manage Customers: open customer maintenance tools.\r\n" +
                "- Manage Movies: add, edit, delete, and review movie records.\r\n" +
                "- Record Order: create a rental order for a customer.\r\n" +
                "- Reports: run reporting features when available.\r\n" +
                "- Log Out: end the current employee session.",

            [Movies] =
                "Movie Management\r\n\r\n" +
                "Use this screen to maintain the movie catalog.\r\n\r\n" +
                "Common tasks:\r\n" +
                "- Load Movies refreshes the movie grid.\r\n" +
                "- Select a movie in the grid to load it into the edit fields.\r\n" +
                "- Add Movie creates a new movie record.\r\n" +
                "- Update Movie saves changes to the selected movie.\r\n" +
                "- Delete Movie removes the selected movie when it has no linked orders.\r\n" +
                "- Clear Fields resets the input controls.\r\n\r\n" +
                "Required fields include the movie name, genre, distribution fee, and number of copies.",

            [Orders] =
                "Order Entry\r\n\r\n" +
                "Use this screen to record a rental for a customer.\r\n\r\n" +
                "Steps:\r\n" +
                "1. Select a customer.\r\n" +
                "2. Select an available movie.\r\n" +
                "3. Confirm the checkout and return date/time values.\r\n" +
                "4. Click Record Order.\r\n\r\n" +
                "Notes:\r\n" +
                "- The employee must be logged in before an order can be saved.\r\n" +
                "- Return date/time must be after checkout date/time.\r\n" +
                "- Only movies with available copies should appear in the movie list.\r\n" +
                "- The order grid shows recorded order history.",

            [CustomerManagement] =
                "Customer Management\r\n\r\n" +
                "This area is intended for adding, editing, and deleting customer records.\r\n\r\n" +
                "The assignment also expects customer-related information such as account details, queue data, and rental history to be maintained here. " +
                "If customer features are still under development, use this topic as a reminder of the required functionality.",

            [Reports] =
                "Reports\r\n\r\n" +
                "The reports screen is intended for advanced business queries and summaries.\r\n\r\n" +
                "The assignment expects reporting such as:\r\n" +
                "- Monthly rental income\r\n" +
                "- Full movie listings\r\n" +
                "- Orders by movie or customer\r\n" +
                "- Most active customers\r\n" +
                "- Most rented movies\r\n" +
                "- Customer mailing lists\r\n\r\n" +
                "Reports should be designed as more complex queries, typically using grouping or nested queries.",

            [About] =
                "About This Help System\r\n\r\n" +
                "This help facility provides topic-based guidance for the employee-facing screens in the movie rental system. " +
                "Use the Help menu to open a topic that matches the screen you are currently using."
        };

        public static IEnumerable<string> AllTopics => TopicContent.Keys;

        public static string GetContent(string topic)
        {
            if (TopicContent.TryGetValue(topic, out string? content))
            {
                return content;
            }

            return "Help content for this topic is not available.";
        }
    }
}

using System;
using System.Configuration;

namespace MovieRental_Team5
{
    internal static class DatabaseConnection
    {
        public static string ConnectionString
        {
            get
            {
                ConnectionStringSettings? settings = ConfigurationManager.ConnectionStrings["MovieRentalDb"];
                if (string.IsNullOrWhiteSpace(settings?.ConnectionString))
                {
                    throw new InvalidOperationException("Connection string 'MovieRentalDb' is missing or empty in App.config.");
                }

                return settings.ConnectionString;
            }
        }
    }
}

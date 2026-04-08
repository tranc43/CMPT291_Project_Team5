/* CLASS: CMPT 291
 * LAB: X02L
 * ASSIGNMENT: RENTAL DATABASE PROJECT
 * AUTHOR(S): TEAM 5 - FIN, CHRISTIAN, BRICE, PIERRE
 * DUE DATE: APRIL 10TH 2025
 */
using System;
using System.Configuration;

namespace MovieRental_Team5
{
    internal static class Database_Connection
    {
        public static string connection_string
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

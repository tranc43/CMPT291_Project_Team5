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
    /*@desc
     * this file is used to handle the database connection string 
     * it reads the connection string from the App.config file and provides it to the rest of the system
     * as one centralized location for the connection string. 
     * 
     */
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

using System;
using System.Security.Cryptography;
using System.Text;

namespace MovieRental_Team5
{
    internal static class PasswordSecurity
    {
        /*@desc: this functions purpose is to hash and verify passwords using a fixed key 
            * 
            */
        private const string HashPrefix = "HMACSHA256$";
        private static readonly string HashKey = "MovieRentalTeam5PasswordKey";

        public static string HashPassword(string password)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(HashKey);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            using (HMACSHA256 hmac = new HMACSHA256(keyBytes))
            {
                byte[] hashBytes = hmac.ComputeHash(passwordBytes);
                return HashPrefix + Convert.ToHexString(hashBytes);
            }
        }

        public static bool VerifyPassword(string password, string storedPassword)
        {
            /*@desc: this functions purpose is to verify a password with the stored password.
            * 
            */
            if (string.IsNullOrWhiteSpace(storedPassword))
            {
                return false;
            }

            if (!storedPassword.StartsWith(HashPrefix, StringComparison.Ordinal))
            {
                return password == storedPassword;
            }

            string computedHash = HashPassword(password);
            return computedHash == storedPassword;
        }

        public static bool IsHashed(string storedPassword)
        {
            /*@desc: this functions purpose is to check if the stored password is hashed or not.
            * 
            */
            return !string.IsNullOrWhiteSpace(storedPassword) &&
                storedPassword.StartsWith(HashPrefix, StringComparison.Ordinal);
        }
    }
}

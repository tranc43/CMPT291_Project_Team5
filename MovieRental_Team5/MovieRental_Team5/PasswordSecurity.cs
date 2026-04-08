/* CLASS: CMPT 291
 * LAB: X02L
 * ASSIGNMENT: RENTAL DATABASE PROJECT
 * AUTHOR(S): TEAM 5 - FIN, CHRISTIAN, BRICE, PIERRE
 * DUE DATE: APRIL 10TH 2025
 */
using System;
using System.Security.Cryptography;
using System.Text;

namespace MovieRental_Team5
{
    internal static class Password_Security
    {
        /*@desc: this functions purpose is to hash and verify passwords using a fixed key 
            * 
            */
        private const string hash_prefix = "HMACSHA256$";
        private static readonly string hash_key = "MovieRentalTeam5PasswordKey";

        public static string hash_password(string password)
        {
            // hashing the password using the prefix
            byte[] key_bytes = Encoding.UTF8.GetBytes(hash_key);
            byte[] password_bytes = Encoding.UTF8.GetBytes(password);

            using (HMACSHA256 hmac = new HMACSHA256(key_bytes))
            {
                // computing the hash and returning the result as a hex string with its prefix.
                byte[] hash_bytes = hmac.ComputeHash(password_bytes);
                return hash_prefix + Convert.ToHexString(hash_bytes);
            }
        }

        public static bool verify_password(string password, string stored_password)
        {
            /*@desc: this functions purpose is to verify a password with the stored password.
            * 
            */
            if (string.IsNullOrWhiteSpace(stored_password))
            {
                return false;
            }
            if (!stored_password.StartsWith(hash_prefix, StringComparison.Ordinal))
            {
                return password == stored_password;
            }
            // Compute the hash of provided password to stored 
            string computed_hash = hash_password(password);
            return computed_hash == stored_password;
        }

        public static bool is_hashed(string stored_password)
        {
            /*@desc: this functions purpose is to check if the stored password is hashed or not.
            * 
            */
            return !string.IsNullOrWhiteSpace(stored_password) &&
                stored_password.StartsWith(hash_prefix, StringComparison.Ordinal);
        }
    }
}

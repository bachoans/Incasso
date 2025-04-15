using System.Security.Cryptography;
using System.Text;
namespace VME.incasso.Business.Helpers
{
    public static class PasswordHelper
    {
        /// <summary>
        /// Generates a cryptographically secure random salt.
        /// </summary>
        /// <returns>A base64-encoded salt string.</returns>
        public static string GenerateSalt()
        {
            byte[] saltBytes = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        /// <summary>
        /// Hashes the password using SHA256 and the provided salt.
        /// </summary>
        /// <param name="password">The password to hash.</param>
        /// <param name="salt">The salt to use.</param>
        /// <returns>The base64-encoded hash string.</returns>
        public static string HashPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var combined = Encoding.UTF8.GetBytes(password + salt);
                var hash = sha256.ComputeHash(combined);
                return Convert.ToBase64String(hash);
            }
        }

        /// <summary>
        /// Verifies if a password matches the stored hash using the provided salt.
        /// </summary>
        /// <param name="password">The plaintext password to verify.</param>
        /// <param name="salt">The salt used to hash the password.</param>
        /// <param name="hash">The stored hashed password.</param>
        /// <returns>True if the password matches; otherwise, false.</returns>
        public static bool VerifyPassword(string password, string salt, string hash)
        {
            string computedHash = HashPassword(password, salt);
            return computedHash == hash;
        }
    }
}

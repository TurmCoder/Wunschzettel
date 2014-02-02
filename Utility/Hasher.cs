using System.Security.Cryptography;
using System.Text;

namespace Utility
{
    public static class Hasher
    {
        private static readonly SHA512CryptoServiceProvider Provider = new SHA512CryptoServiceProvider();

        public static string GetSha512(string phrase)
        {
            var passwordStream = Encoding.UTF8.GetBytes(phrase);

            var hashStream = Provider.ComputeHash(passwordStream);

            return Encoding.UTF8.GetString(hashStream);
        }
    }
}
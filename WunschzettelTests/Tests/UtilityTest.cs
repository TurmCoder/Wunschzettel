using System.Security.Cryptography;
using System.Text;
using NUnit.Framework;
using Utility;

namespace Wunschzettel.Tests
{
    [TestFixture]
    public class UtilityTest
    {
        [Test]
        public void Hasher_Test()
        {
            const string phrase = "Phrase";

            var hash = Hasher.GetSha512(phrase);

            var calculatedHash = CalculateHash(phrase);

            Assert.That(hash, Is.EqualTo(calculatedHash));
        }

        private string CalculateHash(string phrase)
        {
             var Provider = new SHA512CryptoServiceProvider();
        
            var passwordStream = Encoding.UTF8.GetBytes(phrase);

            var hashStream = Provider.ComputeHash(passwordStream);

            return Encoding.UTF8.GetString(hashStream);
        }
    }
}
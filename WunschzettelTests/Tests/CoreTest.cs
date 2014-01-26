using NUnit.Framework;
using Wunschzettel.Core;

namespace Wunschzettel.Tests
{
    [TestFixture]
    public class CoreTest
    {
        [Test]
        public void Person_Should_Have_A_Wunschzettel()
        {
            var person = new Person(true);

            Assert.That(person.Wishlist, Is.Not.Null);
        }
    }
}
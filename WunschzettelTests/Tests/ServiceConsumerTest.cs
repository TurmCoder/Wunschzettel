using NUnit.Framework;
using Rhino.Mocks;

namespace Wunschzettel.Tests
{
    [TestFixture]
    public class ServiceConsumerTest
    {
        private IDatabaseAccessLayer database;
        private Server server;

        [SetUp]
        public void SetUp()
        {
            this.database = MockRepository.GenerateStub<IDatabaseAccessLayer>();

            this.server = new Server(this.database);

            server.Run();
        }

        [TearDown]
        public void TearDown()
        {
            this.server.ShutDown();
        }

        [Test]
        public void Login()
        {
            var consumer = new ClientServiceConsumer();

            var isLoggedIn = consumer.Login();

            Assert.That(isLoggedIn, Is.EqualTo(true));
        }
    }
}
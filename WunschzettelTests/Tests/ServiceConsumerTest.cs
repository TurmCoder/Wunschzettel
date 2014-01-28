using NUnit.Framework;
using Rhino.Mocks;
using Wunschzettel.Core;

namespace Wunschzettel.Tests
{
    [TestFixture]
    public class ServiceConsumerTest
    {
        private IDatabaseAccessLayer database;
        private Server server;
        private IWunschzettelService service;
        private WunschzettelSerializer serializer;

        [SetUp]
        public void SetUp()
        {
            this.database = MockRepository.GenerateStub<IDatabaseAccessLayer>();
            this.database.Stub(s => s.GetPerson(Arg<int>.Is.Equal(1))).Return(new Person() { Id = 1 });

            this.service = MockRepository.GenerateStub<IWunschzettelService>();
            this.service.Stub(s => s.GetPerson(Arg<int>.Is.Equal(1))).Return(new Person() { Id = 1 });

            this.serializer = MockRepository.GenerateStub<WunschzettelSerializer>();

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
            var consumer = new ClientServiceConsumer(this.serializer);

            var isLoggedIn = consumer.Login();

            Assert.That(isLoggedIn, Is.EqualTo(true));
        }

        [Test]
        public void Get_Person()
        {
            var consumer = new ClientServiceConsumer(this.serializer);

            var person = consumer.GetPerson(1);
            
            Assert.That(person.Id, Is.EqualTo(1));
        }

        [Test]
        public void Deserialize_Response()
        {
            var response = "{\"Id\":1,\"Nachname\":null,\"Vorname\":null}";

            var serializer = new WunschzettelSerializer();

            var result = serializer.Deserialize<Person>(response);

            Assert.That(result.GetType(), Is.EqualTo(typeof(Person)));
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(1));
        }
    }
}
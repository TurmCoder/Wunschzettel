using System;
using NUnit.Framework;
using Rhino.Mocks;
using Utility;
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
            this.database.Stub(s => s.GetPerson(Arg<int>.Is.Equal(1))).Return(new Person { Id = 1 });
            this.database.Stub(s => s.Login(Arg<LoginData>.Is.Equal(new LoginData("Login","Login")))).Return(new User("Login", "Login"));

            this.service = MockRepository.GenerateStub<IWunschzettelService>();
            this.service.Stub(s => s.GetPerson(Arg<int>.Is.Equal(1))).Return(new Person { Id = 1 });

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

            var data = new LoginData("Login", "Login");

            var user = consumer.Login(data);

            Assert.That(user, Is.Not.Null);
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
            const string response = "{\"Id\":1,\"Nachname\":null,\"Vorname\":null}";

            this.serializer = new WunschzettelSerializer();

            var result = this.serializer.Deserialize<Person>(response);

            Assert.That(result.GetType(), Is.EqualTo(typeof(Person)));
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(1));
        }

        [Test]
        public void Serialize_Request()
        {
            var loginData = new LoginData("Foo", "Bar");
            this.serializer = new WunschzettelSerializer();

            var serialized = this.serializer.Serialize(loginData);
            var deserialized =  this.serializer.Deserialize<LoginData>(serialized);

            Assert.That(loginData.Username, Is.EqualTo(deserialized.Username));
            Assert.That(loginData.Password, Is.EqualTo(deserialized.Password));

           
        }
    }
}
using NHibernate;
using NUnit.Framework;
using Rhino.Mocks;
using Utility;
using Wunschzettel.Core;

namespace Wunschzettel.Tests
{
    [TestFixture]
    public class DatabaseTest
    {
        private ISessionFactoryBuilder sessionFactoryBuilder;
        private ISessionFactory sessionFactory;
        private IDatabaseAccessLayer database;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            this.CreateDatabase();

            this.database.SavePerson(DatabaseData.Person);
            this.database.SaveUser(DatabaseData.User);
        }

        [SetUp]
        public void SetUp()
        {
            this.sessionFactory = MockRepository.GenerateStub<ISessionFactory>();
            this.sessionFactoryBuilder = MockRepository.GenerateStub<ISessionFactoryBuilder>();
            this.sessionFactoryBuilder.Stub(b => b.CreateSessionFactory(Arg<Schema>.Is.Anything)).Return(this.sessionFactory);

            this.database.Transaction.Begin();
        }

        [TearDown]
        public void TearDown()
        {
            this.database.Transaction.Rollback();
        }

        [Test]
        public void Create_Database_Schema()
        {
            this.sessionFactoryBuilder = MockRepository.GenerateMock<ISessionFactoryBuilder>();
            this.sessionFactoryBuilder.Expect(b => b.CreateSessionFactory(Arg<Schema>.Is.Equal(Schema.Rebuild))).Return(this.sessionFactory);

            var database = new DatabaseAccessLayer(this.sessionFactoryBuilder);
            
            database.Initalize(Schema.Rebuild);

            this.sessionFactoryBuilder.VerifyAllExpectations();
        }

        [Test]
        public void Add_Person()
        {
            var person = new Person
                {
                    Vorname = "Vorname",
                    Nachname = "Nachname"
                };
            
            database.SavePerson(person);

            Assert.That(person.Id, Is.EqualTo(2));
        }

        [Test]
        public void Get_Person()
        {
            var person = this.database.GetPerson(1);

            Assert.That(person.Id, Is.EqualTo(1));
            Assert.That(person.Vorname, Is.EqualTo("Vorname"));
            Assert.That(person.Nachname, Is.EqualTo("Nachname"));
            
            CollectionAssert.IsNotEmpty(person.Wishlist);
            Assert.That(person.Wishlist[0].Name, Is.EqualTo("Pony"));
        }

        [Test]
        public void Create_User()
        {
            var user = new User("Login", "Login");

            this.database.SaveUser(user);

            Assert.That(user.Id == 2);
        }

        [Test]
        public void Update_User()
        {
            var user = this.database.Login(new LoginData("Login", "Login"));
            
            user.Username = "Login2";
            user.Password = Hasher.GetSha512("Login2");

            this.database.SaveUser(user);

            Assert.That(user.Id, Is.EqualTo(1));

            var userProof = this.database.Login(new LoginData("Login2", "Login2"));

            Assert.That(userProof.Id, Is.EqualTo(1));
            Assert.That(userProof, Is.Not.Null);
        }

        [Test]
        public void Login()
        {
            var loginData = new LoginData("Login", "Login");

            var user = this.database.Login(loginData);

            Assert.That(user, Is.Not.Null);
        }

        [Test]
        public void InvalidLogin()
        {
            var loginData = new LoginData("Login", "WrongPassword");

            var user = this.database.Login(loginData);

            Assert.That(user, Is.Null);
        }
        
        public void RebuildDatabase()
        {
            var builder = new SessionFactoryBuilder();

            this.database = new DatabaseAccessLayer(builder);

            this.database.Initalize(Schema.Rebuild);
        }

        private void CreateDatabase()
        {
            var builder = new SessionFactoryBuilder();

            this.database = new DatabaseAccessLayer(builder);
            
            this.database.Initalize(Schema.Rebuild);
        }
    }
}
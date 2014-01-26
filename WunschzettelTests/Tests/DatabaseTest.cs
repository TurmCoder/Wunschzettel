using NHibernate;
using NUnit.Framework;
using Rhino.Mocks;
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

            this.database = new DatabaseAccessLayer(this.sessionFactoryBuilder);
            
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
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;

namespace Wunschzettel.Tests
{
    [TestFixture]
    public class ServerTest
    {
        private IDatabaseAccessLayer database;

        [SetUp]
        public void SetUp()
        {
            this.database = MockRepository.GenerateStub<IDatabaseAccessLayer>();
        }

        [Test]
        public void Run_Host()
        {
            var server = new Server(this.database);

            server.Run();
        }

        [Test]
        public void Shut_Down()
        {
            var server = new Server(this.database);

            server.Run();

            server.ShutDown();
        }

        [Test]
        public void Add_Wish()
        {
            this.database = MockRepository.GenerateMock<IDatabaseAccessLayer>();

            var server = new Server(this.database);

            var wish = new Wish();

            server.AddWish(wish);

            this.database.AssertWasCalled(d => d.AddWish(Arg<Wish>.Is.Equal(wish)));
        }

        [Test]
        public void Add_Wishes()
        {
            this.database = MockRepository.GenerateMock<IDatabaseAccessLayer>();

            var server = new Server(this.database);

            var wishes = new[] { new Wish(), new Wish() };

            server.AddWishes(wishes);

            this.database.AssertWasCalled(d => d.AddWishes(Arg<IEnumerable<Wish>>.Is.Equal(wishes)));
        }

        [Test]
        public void Get_Wish()
        {
            this.database = MockRepository.GenerateMock<IDatabaseAccessLayer>();

            var server = new Server(this.database);

            const int id = 0;

            server.GetWish(id);

            this.database.AssertWasCalled(d => d.GetWish(Arg<int>.Is.Equal(id)));
        }

        [Test]
        public void Get_Wishes()
        {
            this.database = MockRepository.GenerateMock<IDatabaseAccessLayer>();

            var server = new Server(this.database);

            const int personId = 0;

            server.GetWishes(personId);

            this.database.AssertWasCalled(d => d.GetWishes(Arg<int>.Is.Equal(personId)));
        }
    }
}
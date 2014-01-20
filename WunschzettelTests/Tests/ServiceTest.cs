using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;

namespace Wunschzettel.Tests
{
    [TestFixture]
    public class ServiceTest
    {
        private IDatabaseAccessLayer database;

        [SetUp]
        public void SetUp()
        {
            this.database = MockRepository.GenerateStub<IDatabaseAccessLayer>();
        }

        [Test]
        public void Add_Wish()
        {
            this.database = MockRepository.GenerateMock<IDatabaseAccessLayer>();

            var serivce = new WunschzettelService(this.database);

            var wish = new Wish();

            serivce.AddWish(wish);

            database.AssertWasCalled(s => s.AddWish(Arg<Wish>.Is.Equal(wish)));
        }

        [Test]
        public void Add_Wishes()
        {
            this.database = MockRepository.GenerateMock<IDatabaseAccessLayer>();

            var serivce = new WunschzettelService(this.database);

            var wishes = new [] { new Wish(), new Wish()};

            serivce.AddWishes(wishes);

            database.AssertWasCalled(s => s.AddWishes(Arg<IEnumerable<Wish>>.Is.Equal(wishes)));
        }

        [Test]
        public void Get_Wish()
        {
            this.database = MockRepository.GenerateMock<IDatabaseAccessLayer>();

            var serivce = new WunschzettelService(this.database);

            const int id = 0;

            serivce.GetWish(0);

            database.AssertWasCalled(s => s.GetWish(Arg<int>.Is.Equal(id)));
        }

        [Test]
        public void Get_Wishes()
        {
            this.database = MockRepository.GenerateMock<IDatabaseAccessLayer>();

            var serivce = new WunschzettelService(this.database);

            const int personId = 0;

            serivce.GetWishes(0);

            database.AssertWasCalled(s => s.GetWishes(Arg<int>.Is.Equal(personId)));
        }

        [Test]
        public void Get_Person()
        {
            this.database = MockRepository.GenerateMock<IDatabaseAccessLayer>();

            var serivce = new WunschzettelService(this.database);

            const int personId = 0;

            serivce.GetPerson(personId);

            database.AssertWasCalled(s => s.GetPerson(Arg<int>.Is.Equal(personId)));
        }

        [Test]
        public void Save_Person()
        {
            this.database = MockRepository.GenerateMock<IDatabaseAccessLayer>();

            var serivce = new WunschzettelService(this.database);

            var person = new Person();

            serivce.SavePerson(person);

            database.AssertWasCalled(s => s.SavePerson(Arg<Person>.Is.Equal(person)));
        }
    }
}
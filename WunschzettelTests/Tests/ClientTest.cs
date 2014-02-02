using System;
using System.Windows;
using NUnit.Framework;
using Rhino.Mocks;
using Utility;
using Wunschzettel.Core;
using Wunschzettel.Dialoge.Login;

namespace Wunschzettel.Tests
{
    [TestFixture]
    public class ClientTest
    {
        private IClientServiceConsumer service;

        [SetUp]
        public void SetUp()
        {
            this.service = MockRepository.GenerateStub<IClientServiceConsumer>();
        }

        [Test, Ignore]
        [STAThread]
        public void RunApp()
        {
            var app = new App();

            app.Run();

            app.Shutdown();
        }

        [Test]
        public void LogIn()
        {
            var data = new LoginData("Foo", "Bar");

            this.service = MockRepository.GenerateMock<IClientServiceConsumer>();
            this.service.Expect(s => s.Login(Arg<LoginData>.Is.Equal(data)));

            var loginHelper = new LoginHelper(this.service);
            loginHelper.Login(data);

            this.service.VerifyAllExpectations();
        }

        [Test]
        public void Is_Password_Hashed()
        {
            var data = new LoginData("Foo", "Bar");
            var hash = Hasher.GetSha512("Bar");
            Assert.That(data.Password, Is.Not.EqualTo("Bar"));
            Assert.That(data.Password, Is.EqualTo(hash));
        }
    }
}
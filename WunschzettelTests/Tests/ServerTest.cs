using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using Wunschzettel.Core;

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
        public void Run_Starts_Host()
        {
            using (var server = this.GetServer())
            {
                server.Run();

                Assert.That(server.HostIsUp, Is.True);
            }
        }

        private Server GetServer()
        {
            return new Server(this.database);
        }

        [Test]
        public void Run_Initalizes_Database()
        {
            using (var server = this.GetServer())
            {
                server.Run();

                database.Expect(d => d.Initalize(Schema.Keep));

                database.VerifyAllExpectations();
            }
        }

        [Test]
        public void Shut_Down()
        {
            var server = this.GetServer();

            server.Run();

            Assert.That(server.HostIsUp, Is.True);

            server.ShutDown();

            Assert.That(server.HostIsUp, Is.False);
        }
    }
}
using StructureMap.Configuration.DSL;

namespace Wunschzettel
{
    public class ServerRegistry:Registry
    {
        public ServerRegistry()
        {
            For<IServer>().Use<Server>();
            For<IWunschzettelService>().Use<WunschzettelService>();
            For<IDatabaseAccessLayer>().Use<DatabaseAccessLayer>();
        }
    }
}
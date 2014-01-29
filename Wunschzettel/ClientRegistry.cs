using StructureMap.Configuration.DSL;

namespace Wunschzettel
{
    public class ClientRegistry:Registry
    {
        public ClientRegistry()
        {
            For<IClientServiceConsumer>().Use<ClientServiceConsumer>();
        }
    }
}
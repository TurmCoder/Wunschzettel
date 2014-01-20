using StructureMap;

namespace Wunschzettel
{
    class Program
    {
        static void Main(string[] args)
        {
            InitializeStructeMap();

            StartServer();
        }

        private static void StartServer()
        {
            var server = ObjectFactory.GetInstance<IServer>();

            server.Run();
        }

        private static void InitializeStructeMap()
        {
            ObjectFactory.Initialize( o => o.AddRegistry(new ServerRegistry()));
        }
    }
}

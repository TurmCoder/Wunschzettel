using System.Collections.Generic;

namespace Wunschzettel
{
    public interface IServer
    {
        void Run();
        void ShutDown();
    }
}
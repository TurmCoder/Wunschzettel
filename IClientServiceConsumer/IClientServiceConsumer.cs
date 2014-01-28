using Wunschzettel.Core;

namespace Wunschzettel
{
    public interface IClientServiceConsumer
    {
        bool Login();
        Person GetPerson(int personId);
    }
}

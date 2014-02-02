using Wunschzettel.Core;

namespace Wunschzettel
{
    public interface IClientServiceConsumer
    {
        User Login(LoginData data);

        Person GetPerson(int personId);
    }
}

using Wunschzettel.Core;

namespace Wunschzettel.Dialoge.Login
{
    public class LoginHelper:ILoginHelper
    {
        private readonly IClientServiceConsumer service;

        public LoginHelper(IClientServiceConsumer service)
        {
            this.service = service;
        }

        public void Login(LoginData data)
        {
            this.service.Login(data);
        }
    }
}
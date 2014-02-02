using System.Runtime.Serialization;
using Utility;

namespace Wunschzettel.Core
{
    [DataContract]
    public class LoginData
    {
        public LoginData(string username, string password)
        {
            Username = username;
            Password = this.Hash(password);
        }

        private string Hash(string password)
        {
            return Hasher.GetSha512(password);
        }

        [DataMember]
        public string Username { get; private set; }

        [DataMember]
        public string Password { get; private set; }
    }
}
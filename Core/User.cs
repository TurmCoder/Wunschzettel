using System.Runtime.Serialization;

namespace Wunschzettel.Core
{
    [DataContract]
    public class User : BaseEntity
    {
        [DataMember]
        public virtual string Username { get; set; }

        [DataMember]
        public virtual string Password { get; set; }

        public User()
        {
        }

        public User(string user, string password)
        {
            this.Username = user;
            this.Password = password;
        }
    }
}
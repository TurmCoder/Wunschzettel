using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Wunschzettel;

namespace Service2
{
    [ServiceContract]
    public interface IWunschzettelService2
    {
        [OperationContract]
        [WebGet]
        string Login();

        [OperationContract]
        [WebInvoke]
        void AddWish(Wish wish);

        [OperationContract]
        [WebInvoke]
        void AddWishes(IEnumerable<Wish> wishes);

        [OperationContract]
        [WebInvoke]
        Wish GetWish(int id);

        [OperationContract]
        [WebInvoke]
        IEnumerable<Wish> GetWishes(int personId);

        [OperationContract]
        [WebInvoke]
        Person GetPerson(int personId);

        [OperationContract]
        [WebInvoke]
        void SavePerson(Person person);
    }
}

using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Wunschzettel.Core;

namespace Wunschzettel
{
    [ServiceContract]
    public interface IWunschzettelService
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
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        Person GetPerson(int personId);

        [OperationContract]
        [WebInvoke]
        void SavePerson(Person person);
    }
}
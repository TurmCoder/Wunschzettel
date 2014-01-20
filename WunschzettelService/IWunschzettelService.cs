using System.ServiceModel;
using System.ServiceModel.Web;

namespace WunschzettelService
{
    [ServiceContract]
    public interface IWunschzettelService
    {
        [OperationContract]
        string Login();
    }
}

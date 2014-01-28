using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace Wunschzettel
{
    public class WunschzettelInstanceProvider : IInstanceProvider
    {
        readonly Func<WunschzettelService> serviceCreator;

        public WunschzettelInstanceProvider(Func<WunschzettelService> serviceCreator)
        {
            this.serviceCreator = serviceCreator;
        }

        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return this.serviceCreator();
        }

        public object GetInstance(InstanceContext instanceContext)
        {
            return this.serviceCreator();
        }

        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
        }
    }
}
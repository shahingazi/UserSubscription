using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using VoiceoverIP.Services.Model;

namespace VoiceoverIP.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISubscriptionService" in both code and config file together.
    [ServiceContract]
    public interface ISubscriptionService
    {
        [OperationContract]
        void Create(Subscription subscription);

        [OperationContract]
        void Put(Subscription subscription);

        [OperationContract]
        void Delete(int id);

        [OperationContract]
        List<Subscription> Get();

        [OperationContract]
        Subscription Get(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using VoiceoverIP.Services.Model;

namespace VoiceoverIP.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserService" in both code and config file together.
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        List<User> GetList();

        [OperationContract]
        User GetById(int userId);

        [OperationContract]
        int Create(User user);

        [OperationContract]
        void Delete(int userId);

        [OperationContract]
        void Addsubscription(UserSubscription subscription);




    }
}

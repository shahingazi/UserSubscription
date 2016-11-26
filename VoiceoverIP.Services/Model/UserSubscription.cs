using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace VoiceoverIP.Services.Model
{
    public class UserSubscription
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int SubscriptionId { get; set; }
        [DataMember]
        public int UserId { get; set; }
    }
}
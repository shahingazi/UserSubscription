using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace VoiceoverIP.Services.Model
{
    public class Subscription
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Identifier { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public decimal PriceIncVatAmount { get; set; }
        [DataMember]
        public int CallMinutes { get; set; }
    }
}
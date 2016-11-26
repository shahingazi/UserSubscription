using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VoiceoverIP.Models
{
    public class User: UserSubmission
    {
        public int Id { get; set; }
        public List<Subscription> Subscriptions { get; set; }
        public decimal Totalpriceincvatamount { get; set; }
        public decimal Totalcallminutes { get; set; }
    }

    public class UserSubmission
    {
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }


    public class UserSubscription
    {
        public int Subscriptionid { get; set; }
        public int Userid { get; set; }
    }


    public class Subscription
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Priceincvatamount { get; set; }
        public int Callminutes { get; set; }
    }
}
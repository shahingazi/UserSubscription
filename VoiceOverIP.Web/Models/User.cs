using System.Collections.Generic;

namespace VoiceOverIP.Web.Models
{
    public class User : UserSubmission
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


    public class Subscription : SubscriptionSubmission
    {
        public string Id { get; set; }
    }


    public class SubscriptionSubmission
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Priceincvatamount { get; set; }
        public int Callminutes { get; set; }
    }


}
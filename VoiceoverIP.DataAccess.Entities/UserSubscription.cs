namespace VoiceoverIP.DataAccess.Entities
{
   public class UserSubscription
    {
        public int Id { get; set; }
        public int SubscriptionId { get; set; }
        public int UserId { get; set; }
        public virtual Subscription Subscription { get; set; }
       
    }
}

namespace VoiceoverIP.DataAccess.Entities
{
   public class Subscription
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal PriceIncVatAmount { get; set; }
        public int CallMinutes { get; set; }
    }
}

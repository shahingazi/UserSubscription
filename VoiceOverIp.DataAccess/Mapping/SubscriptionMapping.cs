using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using VoiceoverIP.DataAccess.Entities;

namespace VoiceOverIp.DataAccess.Mapping
{
    public class SubscriptionMapping: EntityTypeConfiguration<Subscription>
    {
        public SubscriptionMapping()
        {
            ToTable("Subscription");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(
              DatabaseGeneratedOption.Identity);
            Property(x => x.Name).HasMaxLength(50).IsRequired();
            Property(x => x.CallMinutes).IsRequired();
            Property(x => x.Price).IsRequired();
            Property(x => x.PriceIncVatAmount).IsRequired();
            Property(x => x.Identifier).IsRequired();
        }
    }
}
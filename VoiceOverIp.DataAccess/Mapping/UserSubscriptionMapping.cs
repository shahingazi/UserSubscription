using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using VoiceoverIP.DataAccess.Entities;

namespace VoiceOverIp.DataAccess.Mapping
{
    public class UserSubscriptionMapping: EntityTypeConfiguration<UserSubscription>
    {
        public UserSubscriptionMapping()
        {
            ToTable("UserSubscription");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(
              DatabaseGeneratedOption.Identity);
            Property(x => x.SubscriptionId).IsRequired();
            Property(x => x.UserId).IsRequired();
            HasRequired(x => x.Subscription).WithMany().HasForeignKey(x => x.SubscriptionId);
            
            
        }
    }
}
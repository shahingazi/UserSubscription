using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoiceoverIP.DataAccess.Entities;
using VoiceOverIp.DataAccess.Mapping;

namespace VoiceOverIp.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext() :
            base("Name=VoiceOverIp")
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserSubscription> UserSubscriptions { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }

        protected override void OnModelCreating(DbModelBuilder b)
        {
            b.Configurations.Add(new UserMapping());
            b.Configurations.Add(new UserSubscriptionMapping());
            b.Configurations.Add(new SubscriptionMapping());
        }

    }
}

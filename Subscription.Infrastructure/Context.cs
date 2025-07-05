using KeepTrack.Common;
using Microsoft.EntityFrameworkCore;
using Subscription.Domain.OwnerAggregate;
using Subscription.Domain.PricePlanAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionAndPlan.Infrastructure
{
    public class SubscriptionContext : DbContext
    {
        public SubscriptionContext(DbContextOptions<SubscriptionContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<PricePlan> PricePlans { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubscriptionType>().HasData(new List<SubscriptionType>
            {
                new SubscriptionType("Standart"),
                new SubscriptionType("Normal"),
                new SubscriptionType("Premium")
            } );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<EntityBase>();

            modelBuilder.Entity<User>(x =>
            {
                x.Ignore(c => c.Events);
                x.HasOne(c => c.SubscriptionItem).WithOne().HasForeignKey<SubscriptionItem>(c => c.UserId);
            });

            modelBuilder.Entity<SubscriptionItem>(x =>
            {
                x.Ignore(c => c.Events);
                //x.HasIndex(c => c.Type);
                x.HasOne<SubscriptionType>().WithOne().HasForeignKey<SubscriptionItem>(c => c.Type);
            });
            
            modelBuilder.Entity<SubscriptionType>(x =>
            {
                x.Ignore(c => c.Events);
                x.Ignore(c => c.Id);
                x.HasKey(c => c.Type);
                //x.HasOne<SubscriptionItem>().WithMany().HasForeignKey(c => c.Type);
            });

            //SeedData(modelBuilder);
        }
    }
}

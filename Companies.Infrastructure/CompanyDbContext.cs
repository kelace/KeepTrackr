using Companies.Domain;
using KeepTrack.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companies.Infrastructure
{
    public class CompanyDbContext : DbContext
    {
        public DbSet<SubscriptionType> SubscriptionTypes { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("companies");

            modelBuilder.Ignore<EntityBase>();

            modelBuilder.Entity<Owner>(x =>
            {
                x.Ignore(x => x.Events);
                x.HasOne(x => x.Subscription).WithOne().HasForeignKey<Subscription>(x => x.OwnerId);
                x.HasMany(x => x.Companies).WithOne().HasForeignKey(x => x.OwnerId);
            });

            modelBuilder.Entity<Subscription>(x =>
            {
                x.Ignore(x => x.Events);
            });

            modelBuilder.Entity<SubscriptionType>(x =>
            {
            x.HasKey(x => x.Type);
            x.HasData(new List<SubscriptionType>
                {
                    new SubscriptionType("Normal", 10),
                    new SubscriptionType("Silver", 25),
                    new SubscriptionType("Gold", 50),
                });
            });

            modelBuilder.Entity<Company>(x =>
            {
                x.Ignore(x =>x.Events);
                x.Ignore(x =>x.Id);
                x.HasKey(x => new { x.Name , x.OwnerId});
            });

            modelBuilder.Entity<SubscriptionType>(x =>
            {
                x.Ignore(x => x.Events);
            });


        }
    }
}

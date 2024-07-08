using Companies.Domain;
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
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SubscriptionType>().HasKey(x => x.Type);
            modelBuilder.Entity<SubscriptionType>().HasData(new List<SubscriptionType>
            {
                new SubscriptionType("Normal", 10),
                new SubscriptionType("Silver", 20),
                new SubscriptionType("Gold", 50),
            });

            modelBuilder.Entity<Company>().HasKey(x => x.Name);
        }
    }
}

using Authorization.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Authorization.Infastructure
{
    public class AuthContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Mail> Mails { get; set; }
        public AuthContext(DbContextOptions<AuthContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            var defaultRoles = Enum.GetValues(typeof(WorkerType)).Cast<WorkerType>().Select(x => new IdentityRole<Guid>
            {
                Id = Guid.NewGuid(),
                Name = x.ToString(),
                NormalizedName = x.ToString().ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            });

            modelBuilder.Entity<IdentityRole<Guid>>().HasData(defaultRoles);

        }
    }
}

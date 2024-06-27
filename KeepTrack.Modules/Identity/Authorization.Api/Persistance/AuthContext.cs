using Authorization.Api.Models;
using Authorization.Api.Services.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Authtorization.Persistance
{
    public class AuthContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
	{
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Mail> Mails { get; set; }
		public AuthContext(DbContextOptions<AuthContext> options) : base(options)
		{
			//Database.Migrate();
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

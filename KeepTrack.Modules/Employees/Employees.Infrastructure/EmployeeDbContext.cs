using Employees.Domain.InvitingEmployee;
using Microsoft.EntityFrameworkCore;

namespace Employees.Infrastructure
{
    public class EmployeeDbContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("emp");

            modelBuilder.Entity<Company>(x =>
            {
                x.ToTable("Companies");
                //x.HasMany<CompanyItem>().WithOne().HasForeignKey(x => new { x.OwnerId, x.CompanyName });
            });

            modelBuilder.Entity<Owner>(x =>
            {
                x.HasMany(x => x.Employees).WithOne().HasForeignKey(x => x.OwnerId);
                x.Property(x => x.Id).ValueGeneratedNever();
                x.Ignore(x => x.Events);
            });

            modelBuilder.Entity<Invitation>(x =>
            {
                x.Property( x=> x.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Employee>(x =>
            {
                x.Property(x => x.Id).ValueGeneratedNever();
                x.HasMany(x => x.Companies).WithOne().HasForeignKey(x => x.EmployeeId);
            });

            modelBuilder.Entity<CompanyItem>(x =>
            {
                x.Ignore(x => x.Events);
                x.ToTable("Employee_Company");
            });
            //modelBuilder.Entity<Employee>().HasOne<Owner>().WithMany(x => x.Employees).HasForeignKey(x => x.OwnerId);
            //modelBuilder.Entity<Employee>().ToTable("Employees");

        }
    }
}

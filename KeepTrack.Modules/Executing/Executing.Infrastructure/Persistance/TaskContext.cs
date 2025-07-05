using KeepTrack.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Executing.Domain;

using Executing.Domain.DeskAggregate;
using Executing.Domain.ColumnAggregate;
using Executing.Domain.CardAggregate;

namespace Executing.Infrastructure.Persistance
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Column> Columns { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Desk> Companies { get; set; }
        public DbSet<Job> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("task");

            modelBuilder.Ignore<EntityBase>();

            modelBuilder.Entity<Desk>(x =>
            {
                x.Ignore(x => x.Events);
                x.Ignore(x => x.Id);
                x.HasKey(x => new { x.CompanyName, x.OwnerId });
            });

            //modelBuilder.Entity<Executor>(x =>
            //{
            //    x.Ignore(x => x.Events);
            //    x.Property(x => x.ExecutorType).HasConversion<int>();
            //    x.HasMany<Company>(x => x.Companies).WithOne().HasForeignKey(x => x.UserAssignedId);
            //});

            //modelBuilder.Entity<Executor>().OwnsMany(x => x.OwnerIds);

            modelBuilder.Entity<Desk>().OwnsMany(x => x.Users, x =>
            {
                x.WithOwner().HasForeignKey("DeskId");
                x.ToTable("DeskUser");
            });


            modelBuilder.Entity<Desk>(x =>
            {
                x.HasMany<Column>().WithOne().HasForeignKey("DeskId");
            });

            //modelBuilder.Entity<Company>(x =>
            //{
            //    x.Ignore(x => x.Events);
            //    x.HasKey(x => new { x.OwnerId, x.Name });
            //    x.ToTable("Executors_Company");
            //});

            //modelBuilder.Entity<Column>(x =>
            //{
            //    x.Ignore(x => x.Events);
            //    x.OwnsOne(x => x.CompanyId);

            //});

            modelBuilder.Entity<Card>(x =>
            {
                x.Ignore(x => x.Events);
                x.OwnsOne(x => x.CompanyId);
                x.HasMany<Label>(x => x.Labels).WithOne().HasForeignKey(x => x.CardId);
                x.HasMany<Job>(x => x.Tasks).WithOne().HasForeignKey(x => x.CardId);
            });

            modelBuilder.Entity<Domain.Job>(x =>
            {
                x.Ignore(x => x.Events);
                //x.HasOne<Executor>().WithOne().HasForeignKey<Domain.CardTask>(x => x.AssignedTo);
            });

            modelBuilder.Entity<Label>(x =>
            {
                x.Ignore(x => x.Events);
            });

        }
    }
}

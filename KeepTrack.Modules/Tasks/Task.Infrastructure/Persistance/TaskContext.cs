using KeepTrack.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagment.Domain;
using TaskManagment.Domain.Boards;
using TaskManagment.Domain.Cards;
using TaskManagment.Domain.Companies;
using TaskManagment.Domain.Executors;

namespace TaskManagment.Infrastructure.Persistance
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Column> Boards { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Executor> Executors { get; set; }
        public DbSet<Desk> Companies { get; set; }
        public DbSet<Domain.CardTask> Tasks { get; set; }

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

            modelBuilder.Entity<Executor>(x =>
            {
                x.Ignore(x => x.Events);
                x.Property(x => x.ExecutorType).HasConversion<int>();
                x.HasMany<Company>(x => x.Companies).WithOne().HasForeignKey(x => x.UserAssignedId);
               
            });

            modelBuilder.Entity<Company>(x =>
            {
                x.Ignore(x => x.Events);
                x.HasKey(x => new { x.OwnerId, x.Name });
                x.ToTable("Executors_Company");
            });

            modelBuilder.Entity<Column>(x =>
            {
                x.Ignore(x => x.Events);
                x.OwnsOne(x => x.CompanyId);
            });

            modelBuilder.Entity<Card>(x =>
            {
                x.Ignore(x => x.Events);
                x.OwnsOne(x => x.CompanyId);
                x.HasMany<Label>(x => x.Labels).WithOne().HasForeignKey(x => x.CardId);
                x.HasMany<CardTask>(x => x.Tasks).WithOne().HasForeignKey(x => x.CardId);
            });

            modelBuilder.Entity<Domain.CardTask>(x =>
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

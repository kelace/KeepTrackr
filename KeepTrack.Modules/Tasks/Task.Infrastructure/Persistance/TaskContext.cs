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
using TaskManagment.Domain.Labels;

namespace TaskManagment.Infrastructure.Persistance
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Board> Boards { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Executor> Executors { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Domain.Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("task");

            modelBuilder.Ignore<EntityBase>();

            modelBuilder.Entity<Company>(x =>
            {
                x.Ignore(x => x.Events);
                x.Ignore(x => x.Id);
                x.HasKey(x => new { x.CompanyName, x.OwnerId });
            });

            modelBuilder.Entity<Executor>(x =>
            {
                x.Ignore(x => x.Events);
                x.Property(x => x.ExecutorType).HasConversion<int>();
            });

            modelBuilder.Entity<Board>(x =>
            {
                x.Ignore(x => x.Events);
                x.OwnsOne(x => x.CompanyId);
            });

            modelBuilder.Entity<Card>(x =>
            {
                x.Ignore(x => x.Events);
                x.OwnsOne(x => x.CompanyId);
            });

            modelBuilder.Entity<Domain.Task>(x =>
            {
                x.Ignore(x => x.Events);
                x.HasOne<Executor>().WithOne().HasForeignKey<Domain.Task>(x => x.AssignedTo);
                x.HasMany(x => x.Labels).WithOne().HasForeignKey(x => x.TaskId);
            });

            modelBuilder.Entity<Label>(x =>
            {
                x.Ignore(x => x.Events);
                x.HasOne<LabelLineItem>().WithOne().HasForeignKey<LabelLineItem>(x => x.LabelId);
            });

            modelBuilder.Entity<LabelLineItem>(x =>
            {
                x.Ignore(x => x.Events);
            });
        }
    }
}

using KeepTrack.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagment.Domain;

namespace TaskManagment.Infrastructure.Persistance
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Executor> Executors { get; set; }
        public DbSet<Domain.Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("task");

            modelBuilder.Ignore<EntityBase>();

            modelBuilder.Entity<Executor>().Ignore(x => x.Events);

            modelBuilder.Entity<Domain.Task>().OwnsOne(x => x.CompanyId);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using TaskManagment.Domain;
using TaskManagment.Domain.Boards;
using TaskManagment.Domain.Cards;
using TaskManagment.Domain.Companies;
using TaskManagment.Domain.Executors;
using TaskManagment.Infrastructure.Persistance;
using TaskManagment.Infrastructure.Persistance.Repositories;

namespace TaskManagment.Api.Extension
{
    public static class TaskModuleExtension
    {
        public static IMvcBuilder AddTaskModule(this IMvcBuilder builder, string connection)
        {
            builder.AddApplicationPart(typeof(Program).Assembly);
            builder.Services.AddDbContext<TaskContext>(x => x.UseSqlServer(connection, x => x.MigrationsAssembly("KeepTrackr.Api")));
            builder.Services.AddTransient<IExecutorRepository, ExecutorRepository>();
            builder.Services.AddTransient<ITaskRepository, TaskRepository>();
            builder.Services.AddTransient<IColumnRepository, ColumnRepository>();
            builder.Services.AddTransient<IDeskRepository, DeskRepository>();
            builder.Services.AddTransient<ICardRepository, CardRepository>();
            return builder;
        }
    }
}

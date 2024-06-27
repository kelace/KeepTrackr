using Employees.Application;
using Employees.Domain;
using Employees.Domain.InvitingEmployee;
using Employees.Infrastructure;
using Employees.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Employees.Api.Extensions
{
    public static class AddEmployeePart
    {
        public static IMvcBuilder AddEmployeeModule(this IMvcBuilder mvcBuilder, string connectionString)
        {
            mvcBuilder.AddApplicationPart(typeof(Program).Assembly);
            mvcBuilder.Services.AddDbContext<EmployeeDbContext>(options => options.UseSqlServer(connectionString, x => x.MigrationsAssembly("KeepTrackr.Api")));

            mvcBuilder.Services.AddTransient<IOwnerRepository, OwnerRepository>();
            mvcBuilder.Services.AddTransient<IUserContext, UserContext>();
            mvcBuilder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
            return mvcBuilder;
        } 
    }
}

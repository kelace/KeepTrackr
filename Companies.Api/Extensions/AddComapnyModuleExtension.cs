using Companies.Domain;
using Companies.Infrastructure;
using Companies.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Companies.Api.Extensions
{
    public static class AddComapnyModuleExtension
    {
        public static IMvcBuilder AddCompanyModule(this IMvcBuilder builder, string connectionString)
        {
            builder.AddApplicationPart(typeof(Program).Assembly);

            builder.Services.AddDbContext<CompanyDbContext>(x => x.UseSqlServer(connectionString, x => x.MigrationsAssembly("KeepTrackr.Api")));

            builder.Services.AddTransient<IOwnerRepository, OwnerRepository>();
            builder.Services.AddTransient<ISubscriptionTypeRepository, SubscriptionTypeRepository>();

            return builder;
        }
    }
}

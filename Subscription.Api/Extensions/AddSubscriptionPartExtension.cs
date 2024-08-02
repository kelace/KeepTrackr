using Microsoft.EntityFrameworkCore;
using Subscription.Domain.Users;
using Subscription.Infrastructure;
using Subscription.Infrastructure.Repositories;

namespace Subscription.Api.Extensions
{
    public static class AddSubscriptionPartExtension
    {
        public static IMvcBuilder AddSubscriptionPart(this IMvcBuilder builder, string connectionString)
        {
            builder.AddApplicationPart(typeof(Program).Assembly);
            builder.Services.AddTransient<IUserRepository, UserRepository>();
            builder.Services.AddDbContext<SubscriptionContext>(x => x.UseSqlServer(connectionString, x => x.MigrationsAssembly("KeepTrackr.Api")));
            return builder;
        }
    }
}

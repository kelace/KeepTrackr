using Microsoft.EntityFrameworkCore;
using Subscription.Infrastructure;

namespace Subscription.Api.Extensions
{
    public static class AddSubscriptionPartExtension
    {
        public static IMvcBuilder AddSubscriptionPart(this IMvcBuilder builder, string connectionString)
        {
            builder.AddApplicationPart(typeof(Program).Assembly);
            builder.Services.AddDbContext<SubscriptionContext>(x => x.UseSqlServer(connectionString, x => x.MigrationsAssembly("KeepTrackr.Api")));
            return builder;
        }
    }
}

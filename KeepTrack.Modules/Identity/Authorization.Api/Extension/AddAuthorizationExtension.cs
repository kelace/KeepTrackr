using Authorization.Api.Services.Authentication;
using Authtorization.Persistance;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace Authorization.Api.Extension
{
	public static class AddAuthorizationExtension
	{
		public static IMvcBuilder AddAuthorizationPart(this IMvcBuilder builder, string connectionString)
		{
            builder.AddApplicationPart(typeof(Program).Assembly);

            var persistanceAssemblyName = typeof(AuthContext).Assembly.GetName().Name;

            builder.Services.AddDbContext<AuthContext>(options => options.UseSqlServer(connectionString, x => x.MigrationsAssembly("KeepTrackr.Api")));

            builder.Services.AddTransient<IAuthenticationService, AuthenticationService>();
            builder.Services.AddIdentity<ApplicationUser, IdentityRole<Guid>>(options =>
            {
                options.Lockout.AllowedForNewUsers = true;
            })
    .AddEntityFrameworkStores<AuthContext>()
    .AddDefaultTokenProviders();

            builder.Services.AddAutoMapper(typeof(Program).Assembly);

            return builder;
        }
	}
}

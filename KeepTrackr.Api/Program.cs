using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Net;
using System.Text;
using Employees.Api.Extensions;
using Employees.Application.Queries.GetAllEmployees;
using KeepTrackr.Api;
using KeepTrack.Common;
using Employees.Infrastructure;
using KeepTrackr.Behavior;
using MediatR;
using Authorization.Api.Extension;
using ApplicationIdentity.Application.Commands.SignUpUser;
using Companies.Api.Extensions;
using Companies.Application.InternalEventHandlers;
using Subscription.Api.Extensions;
using Subscription.Application.Commands.SubscribeUser;

var builder = WebApplication.CreateBuilder(args);

var mvcBuilder = builder.Services.AddControllers();

var connectionString = builder.Configuration.GetSection("ConnectionStrings")["Default"];

mvcBuilder.AddAuthorizationPart(connectionString);
mvcBuilder.AddEmployeeModule(connectionString);
mvcBuilder.AddCompanyModule(connectionString);
mvcBuilder.AddSubscriptionPart(connectionString);

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>) );

builder.Services.Configure<ConnectionOptions>(options => options.DefaultConnection = connectionString);

builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

builder.Services.AddTransient<IUserContext, UserContext>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();


builder.Services.AddFluentValidation();
builder.Services.AddHttpContextAccessor();
mvcBuilder.Services.AddMediatR((cfg) =>
{
    cfg.RegisterServicesFromAssembly(typeof(SignUpUserCommand).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(AddEmployeePart).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(GetAllEmployeesQuery).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(OwnerHasBeenSignedUpHandler).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(SubscribeUserCommand).Assembly);
});
var ReactOrigin = "ReactOrigin";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: ReactOrigin,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000");
                          policy.AllowAnyHeader();
                          policy.AllowAnyMethod();
                          policy.AllowCredentials();
                      });
});

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 1;
    options.Password.RequiredUniqueChars = 0;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 0;
    options.Lockout.AllowedForNewUsers = false;

    // User settings.
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = false;
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = false,
        //ValidIssuer = jwtIssuer,
        //ValidAudience = jwtIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("f189f1nf0i13n09g13ngf013ngf01n01212sad321c3a"))
    };
});

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.
app.UseRouting();

app.UseCors(ReactOrigin);
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

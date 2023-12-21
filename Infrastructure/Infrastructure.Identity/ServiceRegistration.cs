using Application.Interfaces.Services;
using Domain.Entities;
using Domain.Settings;
using Infrastructure.Identity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Identity
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AuthenticationOptions>(configuration.GetSection("Authentication:Configuration"));
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IPasswordHasher<AppUser>, PasswordHasher<AppUser>>();
        }
    }
}

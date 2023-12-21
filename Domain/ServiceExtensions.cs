using Domain.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Domain
{
    public static class ServiceExtensions
    {
        public static void AddDomainLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RouletteOptions>(options => configuration.GetSection("Roulette:Configuration").Bind(options));
        }
    }
}

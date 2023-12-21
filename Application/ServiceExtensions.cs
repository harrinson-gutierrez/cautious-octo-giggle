using Application.Behaviours;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using System.Reflection;
using Application.Resolvers;
using Application.Interfaces.Services;
using Application.Interfaces.Mapping;
using Application.Mapping;

namespace Application
{
    public static class ServiceExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddSingleton<IUserContextResolverService<int>, UserContextResolverService>();

            services.AddTransient<IRouletteMapper, RouletteMapper>();
            services.AddTransient<IBetRouletteMapper, BetRouletteMapper>();
        }
    }
}

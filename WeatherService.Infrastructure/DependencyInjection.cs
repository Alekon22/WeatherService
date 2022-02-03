using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherService.Application.Common.Interfaces;
using WeatherService.Infrastructure.Configurations;
using WeatherService.Infrastructure.Services;

namespace WeatherService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMemoryCache();

            services.Configure<OpenWeatherMapConfiguration>(configuration.GetSection("Services:OpenWeatherMap"));
            services.AddSingleton<IWeatherService, OpenWeatherMapService>();

            return services;
        }
    }
}

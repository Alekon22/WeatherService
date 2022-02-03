using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using RestSharp;
using System;
using System.Threading.Tasks;
using WeatherService.Application.Common.Enums;
using WeatherService.Application.Common.Interfaces;
using WeatherService.Domain.Models;
using WeatherService.Infrastructure.Common;
using WeatherService.Infrastructure.Configurations;

namespace WeatherService.Infrastructure.Services
{
    public class OpenWeatherMapService : IWeatherService
    {
        private RestClient _client;
        private IMemoryCache _memoryCache;

        public OpenWeatherMapService(IMemoryCache memoryCache, IOptions<OpenWeatherMapConfiguration> options)
        {
            _client = new RestClient(options.Value.BaseUrl);
            _client.AddDefaultQueryParameter("appid", options.Value.ApiKey);
            _memoryCache = memoryCache;
        }

        public async Task<ForecastResponse> GetForecast(long locationId, TemperatureUnit unit = TemperatureUnit.Kelvin)
        {
            var key = $"{locationId}_{unit}";
            if (!_memoryCache.TryGetValue(key, out ForecastResponse cacheValue))
            {
                System.Diagnostics.Debug.WriteLine("Inside Cache");
                var request = new RestRequest("forecast", Method.Get);
                request.AddQueryParameter("id", locationId);
                request.AddQueryParameter("units", unit.ToOpenWeatherMapUnits());

                var response = await _client.ExecuteAsync<ForecastResponse>(request);

                cacheValue = response.Data;

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromHours(1));

                _memoryCache.Set(key, cacheValue, cacheEntryOptions);
            }
            System.Diagnostics.Debug.WriteLine("Outside Cache");

            return cacheValue;
        }
    }
}

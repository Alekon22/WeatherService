using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WeatherService.Application.Common.Interfaces;

namespace WeatherService.Application.Weather.Queries.GetWeatherForecast
{
    public class GetWeatherForecastQuery : IRequest<WeatherForecastViewModel>
    {
        public int LocationId { get; set; }

        public class GetWeatherForecastQueryHandler : IRequestHandler<GetWeatherForecastQuery, WeatherForecastViewModel>
        {
            private readonly IWeatherService _weatherService;

            public GetWeatherForecastQueryHandler(IWeatherService weatherService)
            {
                _weatherService = weatherService;
            }

            public async Task<WeatherForecastViewModel> Handle(GetWeatherForecastQuery request, CancellationToken cancellationToken)
            {
                var forecast = await _weatherService.GetForecast(request.LocationId);

                var forecasts = new List<WeatherForecastDto>();

                foreach (var item in forecast.list)
                {
                    var temp = new WeatherForecastDto()
                    {
                        Temperature = item.main.temp,
                        TemperatureMax = item.main.temp_max,
                        TemperatureMin = item.main.temp_min,
                        TimeStamp = DateTimeOffset.FromUnixTimeSeconds(item.dt)
                    };

                    forecasts.Add(temp);
                }

                var retval = new WeatherForecastViewModel
                {
                    Id = request.LocationId,
                    Name = forecast.city.name,
                    Forecasts = forecasts
                };

                return retval;
            }
        }
    }
}

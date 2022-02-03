using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WeatherService.Application.Common.Enums;
using WeatherService.Application.Common.Interfaces;

namespace WeatherService.Application.Weather.Queries.GetWeatherSummary
{
    public class GetWeatherSummaryQuery : IRequest<WeatherSummaryViewModel>
    {
        public string Locations { get; set; }
        public TemperatureUnit Unit { get; set; }
        public double Temperature { get; set; }

        public class GetWeatherSummaryQueryHandler : IRequestHandler<GetWeatherSummaryQuery, WeatherSummaryViewModel>
        {
            private readonly IWeatherService _weatherService;

            public GetWeatherSummaryQueryHandler(IWeatherService weatherService)
            {
                _weatherService = weatherService;
            }

            public async Task<WeatherSummaryViewModel> Handle(GetWeatherSummaryQuery request, CancellationToken cancellationToken)
            {
                var locationIds = request.Locations.Split(',').Select(x => int.Parse(x));

                var retval = new WeatherSummaryViewModel()
                {
                    Locations = new List<WeatherLocationSummaryDto>()
                };

                var tommorowEnd = DateTimeOffset.Now.AddDays(1);
                
                foreach (var locationId in locationIds)
                {
                    var forecastResponse = await _weatherService.GetForecast(locationId, request.Unit);

                    // Get all weather forecasts from now until tommorow at the same time
                    var nextDaysWeather = forecastResponse.list.Where(x => DateTimeOffset.FromUnixTimeSeconds(x.dt) < tommorowEnd);

                    // Check if the day contains any temperatures above the desired temperature
                    if (nextDaysWeather.Any(x => x.main.temp_max > request.Temperature))
                    {
                        var summaryDto = new WeatherLocationSummaryDto
                        {
                            Id = locationId,
                            Name = forecastResponse.city.name,
                            TemperatureMax = nextDaysWeather.Max(x => x.main.temp_max),
                            TemperatureMin = nextDaysWeather.Min(x => x.main.temp_min),
                        };

                        retval.Locations.Add(summaryDto);
                    }                  
                }

                return retval;

            }
        }
    }
}

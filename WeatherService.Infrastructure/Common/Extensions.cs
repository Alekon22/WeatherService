using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherService.Application.Common.Enums;

namespace WeatherService.Infrastructure.Common
{
    public static class TemperatureExtensions
    {
        public static string ToOpenWeatherMapUnits(this TemperatureUnit unit)
        {
            return unit switch
            {
                TemperatureUnit.Kelvin => "standard",
                TemperatureUnit.Celsius => "metric",
                TemperatureUnit.Fahrenheit => "imperial",
                _ => throw new ArgumentOutOfRangeException(nameof(unit)),
            };
        }
    }
}

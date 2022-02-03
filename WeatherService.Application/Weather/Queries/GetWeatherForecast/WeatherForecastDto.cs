using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherService.Application.Weather.Queries.GetWeatherForecast
{
    public class WeatherForecastDto
    {
        public DateTimeOffset TimeStamp { get; set; }
        public double Temperature { get; set; }
        public double TemperatureMax { get; set; }
        public double TemperatureMin { get; set; }

    }
}

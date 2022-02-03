using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherService.Application.Weather.Queries.GetWeatherSummary
{
    public class WeatherLocationSummaryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double TemperatureMax { get; set; }
        public double TemperatureMin { get; set; }
    }
}

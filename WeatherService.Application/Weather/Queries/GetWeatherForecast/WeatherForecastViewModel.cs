using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherService.Application.Weather.Queries.GetWeatherForecast
{
    public class WeatherForecastViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<WeatherForecastDto> Forecasts { get; set; }
    }
}

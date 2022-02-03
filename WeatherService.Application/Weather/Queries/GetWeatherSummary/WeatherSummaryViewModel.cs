using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherService.Application.Weather.Queries.GetWeatherSummary
{
    public class WeatherSummaryViewModel
    {
        public List<WeatherLocationSummaryDto> Locations { get; set; }
    }
}

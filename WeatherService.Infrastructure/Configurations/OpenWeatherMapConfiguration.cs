using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherService.Infrastructure.Configurations
{
    public class OpenWeatherMapConfiguration
    {
        public string ApiKey { get; set; }
        public string BaseUrl { get; set; }
    }
}

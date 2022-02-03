using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherService.Application.Common.Enums;
using WeatherService.Domain.Models;

namespace WeatherService.Application.Common.Interfaces
{
    public interface IWeatherService
    {
        Task<ForecastResponse> GetForecast(long locationId, TemperatureUnit unit = TemperatureUnit.Kelvin);
    }
}

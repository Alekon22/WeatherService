using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherService.Application.Common.Enums;
using WeatherService.Application.Weather.Queries.GetWeatherForecast;
using WeatherService.Application.Weather.Queries.GetWeatherSummary;
using WeatherService.ModelBinders;

namespace WeatherService.Controllers
{

    public class WeatherController : BaseController
    {
        
        [HttpGet]
        public async Task<IActionResult> Locations([FromQuery] GetWeatherForecastQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Summary([FromQuery] GetWeatherSummaryQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }
    }
}

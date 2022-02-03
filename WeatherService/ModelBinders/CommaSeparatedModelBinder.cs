using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherService.Application.Common.Enums;
using WeatherService.Application.Weather.Queries.GetWeatherSummary;

namespace WeatherService.ModelBinders
{
    public class LocationIdModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var locationIds = bindingContext.ValueProvider.GetValue("locations");


            if (locationIds.Length == 0)
            {
                return Task.CompletedTask;
            }

            var splitData = locationIds.FirstValue.Split(',');

            var locationIdList = new List<int>();

            foreach (var id in splitData)
            {
                locationIdList.Add(int.Parse(id));
            }

            bindingContext.Result = ModelBindingResult.Success(locationIdList);
            return Task.CompletedTask;
        }
    }
}

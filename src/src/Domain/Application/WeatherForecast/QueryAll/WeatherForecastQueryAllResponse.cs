using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Infraestructure.ModelEntity;

namespace Domain.Application.WeatherForecast.QueryAll
{
    public class WeatherForecastQueryAllResponse
    {
        public List<WeatherForecastModelEntity> AllWeatherForecast { get; set; }
    }
}

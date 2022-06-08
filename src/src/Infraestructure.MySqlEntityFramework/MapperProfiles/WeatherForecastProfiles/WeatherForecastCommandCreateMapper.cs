using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Application.WeatherForecast.ComandCreate;
using Infraestructure.MySqlEntityFramework.DatabaseEntities;

namespace Infraestructure.MySqlEntityFramework.MapperProfiles.WeatherForecastProfiles
{
    public class WeatherForecastCommandCreateMapper : Profile
    {
        public WeatherForecastCommandCreateMapper()
        {
            CreateMap<WeatherForecastCommandCreateRequest, WeatherForecast>();
        }
    }
}

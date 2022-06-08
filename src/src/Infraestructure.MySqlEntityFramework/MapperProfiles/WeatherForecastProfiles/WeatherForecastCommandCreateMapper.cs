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

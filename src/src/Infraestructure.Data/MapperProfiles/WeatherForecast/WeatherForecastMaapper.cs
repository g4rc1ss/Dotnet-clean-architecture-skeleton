using AutoMapper;
using Domain.Database.ModelEntity;
using Infraestructure.Data.Entities;

namespace Infraestructure.Data.MapperProfiles.WeatherForecast
{
    public class WeatherForecastMaapper : Profile
    {
        public WeatherForecastMaapper()
        {
            CreateMap<WeatherForecastEntity, WeatherForecastModelEntity>();
        }
    }
}

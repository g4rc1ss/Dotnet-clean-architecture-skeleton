using AutoMapper;
using Domain.Database.ModelEntity;
using Infraestructure.MySqlEntityFramework.Entities;

namespace Infraestructure.MySqlEntityFramework.MapperProfiles.WeatherForecast
{
    public class WeatherForecastMaapper : Profile
    {
        public WeatherForecastMaapper()
        {
            CreateMap<WeatherForecastEntity, WeatherForecastModelEntity>();
        }
    }
}

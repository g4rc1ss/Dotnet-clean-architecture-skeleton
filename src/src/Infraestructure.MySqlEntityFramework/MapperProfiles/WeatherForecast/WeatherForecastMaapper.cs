using AutoMapper;
using Domain.Database.ModelEntity;

namespace Infraestructure.MySqlEntityFramework.MapperProfiles.WeatherForecast
{
    public class WeatherForecastMaapper : Profile
    {
        public WeatherForecastMaapper()
        {
            CreateMap<Entities.WeatherForecast, WeatherForecastModelEntity>();
        }
    }
}

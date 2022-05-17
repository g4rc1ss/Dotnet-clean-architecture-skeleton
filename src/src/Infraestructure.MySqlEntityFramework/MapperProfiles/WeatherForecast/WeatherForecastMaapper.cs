using AutoMapper;
using Domain.Database.ModelEntity;

namespace Infraestructure.MySqlEntityFramework.MapperProfiles.WeatherForecast
{
    public class WeatherForecastMaapper : Profile
    {
        public WeatherForecastMaapper()
        {
            //CreateMap<Entities.WeatherForecast, WeatherForecastModelEntity>();
            CreateProjection<Entities.WeatherForecast, WeatherForecastModelEntity>()
                .ForMember(x => x.Date, y => y.MapFrom(x => x.Date))
                .ForMember(x => x.Summary, y => y.Ignore())
                .ForMember(x => x.TemperatureC, y => y.Ignore())
                .ForMember(x => x.TemperatureF, y => y.Ignore());
        }
    }
}

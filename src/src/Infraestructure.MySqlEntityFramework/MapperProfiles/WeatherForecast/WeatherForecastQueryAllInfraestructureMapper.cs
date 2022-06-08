using AutoMapper;
using Domain.Application.WeatherForecast.ComandCreate;
using Domain.Application.WeatherForecast.QueryAll;

namespace Infraestructure.MySqlEntityFramework.MapperProfiles.WeatherForecast
{
    public class WeatherForecastQueryAllInfraestructureMapper : Profile
    {
        public WeatherForecastQueryAllInfraestructureMapper()
        {
            CreateProjection<Entities.WeatherForecast, WeatherForecastQueryAllResponse>()
                .ForMember(x => x.Date, y => y.MapFrom(x => x.Date))
                .ForMember(x => x.Summary, y => y.Ignore())
                .ForMember(x => x.TemperatureC, y => y.Ignore())
                .ForMember(x => x.TemperatureF, y => y.Ignore());
        }
    }
}

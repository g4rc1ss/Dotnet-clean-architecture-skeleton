using AutoMapper;
using Domain.Application.WeatherForecast.QueryAll;
using Infraestructure.MySqlEntityFramework.DatabaseEntities;

namespace Infraestructure.MySqlEntityFramework.MapperProfiles.WeatherForecastProfiles
{
    public class WeatherForecastQueryAllMapper : Profile
    {
        public WeatherForecastQueryAllMapper()
        {
            CreateProjection<WeatherForecast, WeatherForecastQueryAllResponse>()
                .ForMember(x => x.Date, y => y.MapFrom(x => x.Date))
                .ForMember(x => x.Summary, y => y.Ignore())
                .ForMember(x => x.TemperatureC, y => y.Ignore())
                .ForMember(x => x.TemperatureF, y => y.Ignore());
        }
    }
}

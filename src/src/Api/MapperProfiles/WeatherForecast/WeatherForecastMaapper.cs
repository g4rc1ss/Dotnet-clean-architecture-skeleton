using AutoMapper;
using Domain.Database.ModelEntity;
using Shared.Peticiones.Responses.WeatherForecast;

namespace Api.MapperProfiles.WeatherForecast
{
    public class WeatherForecastMaapper : Profile
    {
        public WeatherForecastMaapper()
        {
            CreateMap<WeatherForecastModelEntity, WeatherForecastResponse>();
            //.ForMember(x => x.TemperatureF, y => y.MapFrom(x => x.TemperatureF))
            //.ForMember(x => x.TemperatureC, y => y.MapFrom(x => x.TemperatureC))
            //.ForMember(x => x.Date, y => y.MapFrom(x => x.Date))
            //.ForMember(x => x.Summary, y => y.MapFrom(x => x.Summary))
            //.BeforeMap((weatherModelEntity, weatherResponse) =>
            //{
            //    weatherModelEntity.TemperatureF /= weatherResponse.TemperatureC;
            //});
        }
    }
}

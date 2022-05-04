using Application.Interfaces.Core;
using Application.Interfaces.Data;
using Domain.Database.ModelEntity;

namespace Application.Core.WeatherForecast
{
    internal class WeatherForecastNegocio : IWeatherForecastNegocio
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository;

        public WeatherForecastNegocio(IWeatherForecastRepository weatherForecastRepository)
        {
            _weatherForecastRepository = weatherForecastRepository;
        }

        public Task<IEnumerable<WeatherForecastModelEntity>> GetWeatherForecastAsync()
        {
            return _weatherForecastRepository.GetWeatherForecastAsync();
        }
    }
}

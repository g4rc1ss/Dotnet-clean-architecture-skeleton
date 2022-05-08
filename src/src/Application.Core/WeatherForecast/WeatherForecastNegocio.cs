using Application.Interfaces.Core;
using Application.Interfaces.Data;
using Domain.Database.ModelEntity;
using Microsoft.AspNetCore.DataProtection;

namespace Application.Core.WeatherForecast
{
    internal class WeatherForecastNegocio : IWeatherForecastNegocio
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository;
        private readonly IDataProtector _protector;

        public WeatherForecastNegocio(IWeatherForecastRepository weatherForecastRepository, IDataProtectionProvider dataProtectionProvider)
        {
            _weatherForecastRepository = weatherForecastRepository;
            _protector = dataProtectionProvider.CreateProtector("Application.Core.WeatherForecast.WeatherForecastNegocio");
        }

        public Task<IEnumerable<WeatherForecastModelEntity>> GetWeatherForecastAsync()
        {
            return _weatherForecastRepository.GetWeatherForecastAsync();
        }
    }
}

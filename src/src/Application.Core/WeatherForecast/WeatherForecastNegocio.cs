using Application.Interfaces.Core;
using Application.Interfaces.Infraestructure.Query.WeatherForecastQueryContracts;
using Domain.Database.ModelEntity;
using Microsoft.AspNetCore.DataProtection;

namespace Application.Core.WeatherForecast
{
    internal class WeatherForecastNegocio : IWeatherForecastNegocio
    {
        private readonly IWeatherForecastQueryAllContract _weatherForecastRepository;
        private readonly IDataProtector _protector;

        public WeatherForecastNegocio(IWeatherForecastQueryAllContract weatherForecastRepository, IDataProtectionProvider dataProtectionProvider)
        {
            _weatherForecastRepository = weatherForecastRepository;
            _protector = dataProtectionProvider.CreateProtector("Application.Core.WeatherForecast.WeatherForecastNegocio");
        }

        public Task<List<WeatherForecastModelEntity>> GetWeatherForecastAsync()
        {
            _protector.Protect("Hola");
            return _weatherForecastRepository.GetWeatherForecastAsync();
        }
    }
}

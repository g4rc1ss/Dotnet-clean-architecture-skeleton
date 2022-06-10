using Application.Interfaces.Infraestructure.Command.WeatherForecastCommandContracts;
using AutoMapper;
using Domain.Application.WeatherForecast.ComandCreate;
using Infraestructure.MySqlEntityFramework.Contexts;
using Infraestructure.MySqlEntityFramework.DatabaseEntities;
using Microsoft.AspNetCore.DataProtection;

namespace Infraestructure.MySqlEntityFramework.Repositories.Command.WeatherForecastCommand
{
    public class WeatherForecastCommandCreate : IWeatherForecastCommandCreateContract
    {
        private readonly CleanArchitectureSkeletonContext _cleanArchitectureContext;
        private readonly IDataProtector _dataProtector;
        private readonly IMapper _mapper;

        public WeatherForecastCommandCreate(CleanArchitectureSkeletonContext cleanArchitectureContext, IMapper mapper, IDataProtectionProvider dataProtection)
        {
            _cleanArchitectureContext = cleanArchitectureContext;
            _mapper = mapper;
            _dataProtector = dataProtection.CreateProtector("purpose.de.creacion.Weather.Forecast");
        }

        public async Task<int> ExecuteAsync(WeatherForecastCommandCreateRequest weather, CancellationToken cancellationToken = default)
        {
            var weatherForecast = _mapper.Map<WeatherForecast>(weather);

            weatherForecast.Date = DateTime.Now;
            ProtectFieldsToSave(ref weatherForecast);

            await _cleanArchitectureContext.AddAsync(weatherForecast, cancellationToken);
            return await _cleanArchitectureContext.SaveChangesAsync(cancellationToken);
        }

        private void ProtectFieldsToSave(ref WeatherForecast weatherForecast)
        {
            weatherForecast.Summary = _dataProtector.Protect(weatherForecast.Summary!);
        }
    }
}

using System.Text.Json;
using Application.Interfaces.Infraestructure.Query.WeatherForecastQueryContracts;
using AutoMapper;
using Domain.Application.WeatherForecast.QueryAll;
using Infraestructure.MySqlEntityFramework.Contexts;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

namespace Infraestructure.MySqlEntityFramework.Repositories.Query.WeatherForecastQueries
{
    internal class WeatherForecastQueryAll : IWeatherForecastQueryAllContract
    {
        private readonly CleanArchitectureSkeletonContext _cleanArchitectureContext;
        private readonly IDistributedCache _distributedCache;
        private readonly IMapper _mapper;
        private readonly IDataProtector _dataPotector;

        public WeatherForecastQueryAll(IMapper mapper, CleanArchitectureSkeletonContext cleanArchitectureContext,
            IDistributedCache distributedCache, IDataProtectionProvider dataProtectionProvider)
        {
            _mapper = mapper;
            _cleanArchitectureContext = cleanArchitectureContext;
            _distributedCache = distributedCache;
            _dataPotector = dataProtectionProvider.CreateProtector("purpose.de.creacion.Weather.Forecast");
        }

        public async Task<List<WeatherForecastQueryAllResponse>> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            var weatherList = new List<WeatherForecastQueryAllResponse>();
            var cacheWeatherList = await _distributedCache.GetStringAsync(nameof(WeatherForecastQueryAll), cancellationToken);

            if (string.IsNullOrEmpty(cacheWeatherList))
            {
                var query = _cleanArchitectureContext.WeatherForecasts;
                weatherList = await _mapper.ProjectTo<WeatherForecastQueryAllResponse>(query).ToListAsync(cancellationToken);

                await _distributedCache.SetStringAsync(nameof(WeatherForecastQueryAll), JsonSerializer.Serialize(weatherList), cancellationToken);
            }
            else
            {
                weatherList = JsonSerializer.Deserialize<List<WeatherForecastQueryAllResponse>>(cacheWeatherList);
            }
            return UnProtectData(ref weatherList!);
        }

        private List<WeatherForecastQueryAllResponse> UnProtectData(ref List<WeatherForecastQueryAllResponse> weatherForecasts)
        {
            return weatherForecasts.Select(x => new WeatherForecastQueryAllResponse
            {
                Date = x.Date,
                Summary = _dataPotector.Unprotect(x.Summary!),
                TemperatureC = x.TemperatureC,
                TemperatureF = x.TemperatureF,
            }).ToList();
        }
    }
}

using System.Text.Json;
using Application.Interfaces.Infraestructure.Query.WeatherForecastQueryContracts;
using AutoMapper;
using Domain.Database.ModelEntity;
using Infraestructure.MySqlEntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

namespace Infraestructure.MySqlEntityFramework.Repositories.Query.WeatherForecastQueries
{
    internal class WeatherForecastQueryAll : IWeatherForecastQueryAllContract
    {
        private readonly CleanArchitectureSkeletonContext _cleanArchitectureContext;
        private readonly IDistributedCache _distributedCache;
        private readonly IMapper _mapper;

        public WeatherForecastQueryAll(IMapper mapper, CleanArchitectureSkeletonContext cleanArchitectureContext, IDistributedCache distributedCache)
        {
            _mapper = mapper;
            _cleanArchitectureContext = cleanArchitectureContext;
            _distributedCache = distributedCache;
        }

        public async Task<List<WeatherForecastModelEntity>> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            var weatherList = default(List<WeatherForecastModelEntity>);
            var cacheWeatherList = await _distributedCache.GetStringAsync(nameof(WeatherForecastQueryAll), cancellationToken);
            weatherList = JsonSerializer.Deserialize<List<WeatherForecastModelEntity>>(cacheWeatherList);

            if (weatherList is null || weatherList.Count < 1)
            {
                var query = _cleanArchitectureContext.WeatherForecasts;
                weatherList = await _mapper.ProjectTo<WeatherForecastModelEntity>(query).ToListAsync(cancellationToken);

                await _distributedCache.SetStringAsync(nameof(WeatherForecastQueryAll), JsonSerializer.Serialize(weatherList), cancellationToken);
            }
            return weatherList;
        }
    }
}

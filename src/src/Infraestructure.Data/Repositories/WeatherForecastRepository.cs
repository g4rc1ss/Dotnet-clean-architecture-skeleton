using Application.Interfaces.Data;
using AutoMapper;
using Domain.Database.ModelEntity;
using Infraestructure.Data.Entities;

namespace Infraestructure.Data.Repositories
{
    internal class WeatherForecastRepository : IWeatherForecastRepository
    {
        private readonly IMapper _mapper;

        public WeatherForecastRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        private static readonly string[] Summaries = new[]
        { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

        public async Task<IEnumerable<WeatherForecastModelEntity>> GetWeatherForecastAsync()
        {
            var consultaBaseDeDatos = await Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecastEntity
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }));

            return _mapper.Map<IEnumerable<WeatherForecastModelEntity>>(consultaBaseDeDatos);
        }
    }
}

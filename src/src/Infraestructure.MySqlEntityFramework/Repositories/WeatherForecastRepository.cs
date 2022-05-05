using Application.Interfaces.Data;
using AutoMapper;
using Domain.Database.ModelEntity;
using Domain.Utilities.LoggingMediatr;
using Infraestructure.MySqlEntityFramework.Contexts;
using Infraestructure.MySqlEntityFramework.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.MySqlEntityFramework.Repositories
{
    internal class WeatherForecastRepository : IWeatherForecastRepository
    {
        private readonly CleanArchitectureSkeletonContext cleanArchitectureContext;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public WeatherForecastRepository(IMapper mapper, CleanArchitectureSkeletonContext cleanArchitectureContext, IMediator mediator)
        {
            _mapper = mapper;
            this.cleanArchitectureContext = cleanArchitectureContext;
            _mediator = mediator;
        }

        private static readonly string[] Summaries = new[]
        { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

        public async Task<IEnumerable<WeatherForecastModelEntity>> GetWeatherForecastAsync()
        {            
            var consultaBaseDeDatos = await cleanArchitectureContext.WeatherForecasts.ToListAsync();
            return _mapper.Map<IEnumerable<WeatherForecastModelEntity>>(consultaBaseDeDatos);
        }
    }
}

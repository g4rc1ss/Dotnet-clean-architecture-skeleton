using Application.Interfaces.Data;
using AutoMapper;
using Domain.Database.ModelEntity;
using Infraestructure.MySqlEntityFramework.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.MySqlEntityFramework.Repositories
{
    internal class WeatherForecastRepository : IWeatherForecastRepository
    {
        private readonly CleanArchitectureSkeletonContext _cleanArchitectureContext;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public WeatherForecastRepository(IMapper mapper, CleanArchitectureSkeletonContext cleanArchitectureContext, IMediator mediator)
        {
            _mapper = mapper;
            _cleanArchitectureContext = cleanArchitectureContext;
            _mediator = mediator;
        }

        public async Task<IEnumerable<WeatherForecastModelEntity>> GetWeatherForecastAsync()
        {
            var consultaBaseDeDatos = await _cleanArchitectureContext.WeatherForecasts.ToListAsync();
            return _mapper.Map<IEnumerable<WeatherForecastModelEntity>>(consultaBaseDeDatos);
        }
    }
}

using Application.Interfaces.Core;
using AutoMapper;
using Domain.Utilities.LoggingMediatr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Peticiones.Request;
using Shared.Peticiones.Responses.WeatherForecast;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : Controller
    {
        private readonly IWeatherForecastNegocio _weatherForecastContract;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public WeatherForecastController(IWeatherForecastNegocio weatherForecastContract, IMapper mapper, IMediator mediator)
        {
            _weatherForecastContract = weatherForecastContract;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet("GetWeatherForecast")]
        public async Task<IActionResult> GetAsync()
        {
            var weatherForecast = await _weatherForecastContract.GetWeatherForecastAsync();
            await _mediator.Publish(new LoggingRequest(weatherForecast, LogType.Info));
            return Json(_mapper.Map<IEnumerable<WeatherForecastResponse>>(weatherForecast));
        }

        [HttpPost()]
        public IActionResult Hola(Class1 hola)
        {
            throw new Exception("Exception de prueba");
            return Ok(hola);
        }
    }
}

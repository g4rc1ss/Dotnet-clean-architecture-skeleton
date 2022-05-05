using Application.Interfaces.Core;
using AutoMapper;
using Domain.Utilities.LoggingMediatr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Peticiones.Responses.WeatherForecast;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : Controller
    {
        private readonly IWeatherForecastNegocio _weatherForecastContract;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public WeatherForecastController(IWeatherForecastNegocio weatherForecastContract, IMapper mapper, IMediator mediator, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            _weatherForecastContract = weatherForecastContract;
            _mapper = mapper;
            _mediator = mediator;
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("GetWeatherForecast")]
        public async Task<IActionResult> GetAsync()
        {
            var entorno = _webHostEnvironment.EnvironmentName;
            var prueba = _configuration.GetValue<string>("PruebaAppSettings");
            var weatherForecast = await _weatherForecastContract.GetWeatherForecastAsync();
            await _mediator.Publish(new LoggingRequest(weatherForecast, LogType.Info));
            return Json(_mapper.Map<IEnumerable<WeatherForecastResponse>>(weatherForecast));
        }
    }
}

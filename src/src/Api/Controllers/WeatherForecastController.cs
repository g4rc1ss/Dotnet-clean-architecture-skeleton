using AutoMapper;
using Domain.Application.WeatherForecast.QueryAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Peticiones.Responses.WeatherForecast;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public WeatherForecastController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet("allWeatherForecast")]
        public async Task<IActionResult> GetWeatherForecast()
        {
            var weatherForecast = await _mediator.Send(new WeatherForecastQueryAllRequest());
            return Json(_mapper.Map<IEnumerable<WeatherForecastResponse>>(weatherForecast));
        }
    }
}

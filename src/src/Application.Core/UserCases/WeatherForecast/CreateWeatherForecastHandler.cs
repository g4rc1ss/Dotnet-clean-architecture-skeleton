using Application.Interfaces.Infraestructure.Command.WeatherForecastCommandContracts;
using Domain.Application.WeatherForecast.ComandCreate;
using MediatR;

namespace Application.Core.UserCases.WeatherForecast
{
    internal class CreateWeatherForecastHandler : IRequestHandler<WeatherForecastCommandCreateRequest, WeatherForecastCommandCreateResponse>
    {
        private readonly IWeatherForecastCommandCreateContract _weatherForecastCommandCreate;

        public CreateWeatherForecastHandler(IWeatherForecastCommandCreateContract weatherForecastCommandCreate)
        {
            _weatherForecastCommandCreate = weatherForecastCommandCreate;
        }

        public async Task<WeatherForecastCommandCreateResponse> Handle(WeatherForecastCommandCreateRequest request, CancellationToken cancellationToken)
        {
            var createWeatherForecast = await _weatherForecastCommandCreate.ExecuteAsync(request, cancellationToken);
            return new WeatherForecastCommandCreateResponse
            {
                Success = createWeatherForecast > 0,
            };
        }
    }
}

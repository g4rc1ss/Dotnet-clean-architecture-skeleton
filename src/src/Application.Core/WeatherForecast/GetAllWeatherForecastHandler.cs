using Application.Interfaces.Infraestructure.Query.WeatherForecastQueryContracts;
using Domain.Application.WeatherForecast.QueryAll;
using MediatR;

namespace Application.Core.WeatherForecast
{
    internal class GetAllWeatherForecastHandler : IRequestHandler<WeatherForecastQueryAllRequest, WeatherForecastQueryAllResponse>
    {
        private readonly IWeatherForecastQueryAllContract _weatherForecastQueryAll;

        public GetAllWeatherForecastHandler(IWeatherForecastQueryAllContract weatherForecastQueryAll)
        {
            _weatherForecastQueryAll = weatherForecastQueryAll;
        }

        public async Task<WeatherForecastQueryAllResponse> Handle(WeatherForecastQueryAllRequest request, CancellationToken cancellationToken)
        {
            var listWeatherForecast = await _weatherForecastQueryAll.ExecuteAsync(cancellationToken);

            return new WeatherForecastQueryAllResponse
            {
                AllWeatherForecast = listWeatherForecast,
            };
        }
    }
}

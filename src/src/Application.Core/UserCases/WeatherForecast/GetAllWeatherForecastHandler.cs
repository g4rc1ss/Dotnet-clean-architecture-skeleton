using Application.Interfaces.Infraestructure.Query.WeatherForecastQueryContracts;
using Domain.Application.WeatherForecast.QueryAll;
using MediatR;

namespace Application.Core.UserCases.WeatherForecast
{
    internal class GetAllWeatherForecastHandler : IRequestHandler<WeatherForecastQueryAllRequest, List<WeatherForecastQueryAllResponse>>
    {
        private readonly IWeatherForecastQueryAllContract _weatherForecastQueryAll;

        public GetAllWeatherForecastHandler(IWeatherForecastQueryAllContract weatherForecastQueryAll)
        {
            _weatherForecastQueryAll = weatherForecastQueryAll;
        }

        public Task<List<WeatherForecastQueryAllResponse>> Handle(WeatherForecastQueryAllRequest request, CancellationToken cancellationToken)
        {
            return _weatherForecastQueryAll.ExecuteAsync(cancellationToken);
        }
    }
}

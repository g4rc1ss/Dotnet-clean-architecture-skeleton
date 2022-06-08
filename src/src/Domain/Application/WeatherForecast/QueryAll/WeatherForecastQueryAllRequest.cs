using MediatR;

namespace Domain.Application.WeatherForecast.QueryAll
{
    public class WeatherForecastQueryAllRequest : IRequest<List<WeatherForecastQueryAllResponse>>
    {
    }
}

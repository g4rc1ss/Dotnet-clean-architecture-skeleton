using Domain.Application.WeatherForecast.ComandCreate;

namespace Application.Interfaces.Infraestructure.Command.WeatherForecastCommandContracts
{
    public interface IWeatherForecastCommandCreateContract
    {
        Task<int> ExecuteAsync(CreateWeatherForecastRequest weather, CancellationToken cancellationToken = default);
    }
}

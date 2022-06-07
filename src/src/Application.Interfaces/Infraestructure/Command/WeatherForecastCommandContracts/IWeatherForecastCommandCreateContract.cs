using Domain.Database.ModelEntity;

namespace Application.Interfaces.Infraestructure.Command.WeatherForecastCommandContracts
{
    public interface IWeatherForecastCommandCreateContract
    {
        Task<bool> ExecuteAsync(WeatherForecastModelEntity weather, CancellationToken cancellationToken = default);
    }
}

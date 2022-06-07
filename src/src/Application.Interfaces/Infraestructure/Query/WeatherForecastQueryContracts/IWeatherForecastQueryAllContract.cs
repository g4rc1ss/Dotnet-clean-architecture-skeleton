using Domain.Database.ModelEntity;

namespace Application.Interfaces.Infraestructure.Query.WeatherForecastQueryContracts
{
    public interface IWeatherForecastQueryAllContract
    {
        Task<List<WeatherForecastModelEntity>> ExecuteAsync(CancellationToken cancellationToken = default);
    }
}

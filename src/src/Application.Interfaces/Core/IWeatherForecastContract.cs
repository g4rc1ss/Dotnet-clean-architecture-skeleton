using Domain.Database.ModelEntity;

namespace Application.Interfaces.Core
{
    public interface IWeatherForecastNegocio
    {
        Task<List<WeatherForecastModelEntity>> GetWeatherForecastAsync();
    }
}

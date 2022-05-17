using Domain.Database.ModelEntity;

namespace Application.Interfaces.Data
{
    public interface IWeatherForecastRepository
    {
        Task<List<WeatherForecastModelEntity>> GetWeatherForecastAsync();
    }
}

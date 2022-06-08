using MediatR;

namespace Domain.Application.WeatherForecast.ComandCreate
{
    public class CreateWeatherForecastRequest : IRequest<CreateWeatherForecastResponse>
    {
        public DateTime? Date { get; set; }
        public int? TemperatureC { get; set; }
        public int? TemperatureF { get; set; }
        public string? Summary { get; set; }
    }
}

using MediatR;

namespace Domain.Application.WeatherForecast.ComandCreate
{
    public class WeatherForecastCommandCreateRequest : IRequest<WeatherForecastCommandCreateResponse>
    {
        public DateTime? Date { get; set; }
        public int? TemperatureC { get; set; }
        public int? TemperatureF { get; set; }
        public string? Summary { get; set; }
    }
}

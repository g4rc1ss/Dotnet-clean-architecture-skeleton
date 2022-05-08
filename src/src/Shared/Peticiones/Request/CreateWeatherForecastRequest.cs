using System.ComponentModel.DataAnnotations;

namespace Shared.Peticiones.Request;

public class CreateWeatherForecastRequest
{
    [Required]
    public int Celsius { get; set; }

    [Required]
    public int Fahrenheit { get; set; }

    [StringLength(100)]
    public string? Descripcion { get; set; }
}

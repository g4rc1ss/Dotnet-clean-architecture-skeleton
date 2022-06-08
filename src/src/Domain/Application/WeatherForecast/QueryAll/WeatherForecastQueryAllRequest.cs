using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Domain.Application.WeatherForecast.QueryAll
{
    public class WeatherForecastQueryAllRequest : IRequest<WeatherForecastQueryAllResponse>
    {
    }
}

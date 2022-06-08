using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Application.WeatherForecast.ComandCreate;
using MediatR;

namespace Application.Core.WeatherForecast
{
    internal class CreateWeatherForecastHandler : IRequestHandler<CreateWeatherForecastRequest, CreateWeatherForecastResponse>
    {
        public Task<CreateWeatherForecastResponse> Handle(CreateWeatherForecastRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

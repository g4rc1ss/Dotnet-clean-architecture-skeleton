﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Domain.Application.WeatherForecast.ComandCreate
{
    public class CreateWeatherForecastRequest : IRequest<CreateWeatherForecastResponse>
    {
    }
}

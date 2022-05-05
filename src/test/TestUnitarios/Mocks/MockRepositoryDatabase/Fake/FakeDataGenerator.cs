﻿using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Database.ModelEntity;

namespace TestUnitarios.Mocks.MockRepositoryDatabase.Fake
{
    internal static class FakeDataGenerator
    {
        public static IEnumerable<WeatherForecastModelEntity> GetFakeWeather => Enumerable.Range(0, 10).Select(x => new WeatherForecastModelEntity
        {
            Date = DateTime.Now,
            Summary = "Sumario",
            TemperatureC = new Random().Next(0, 100),
            TemperatureF = new Random().Next(0, 100),
        });
    }
}
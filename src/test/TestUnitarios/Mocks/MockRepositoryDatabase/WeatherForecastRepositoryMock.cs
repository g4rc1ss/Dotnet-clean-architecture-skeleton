using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Data;
using Moq;
using TestUnitarios.Mocks.MockRepositoryDatabase.Fake;

namespace TestUnitarios.Mocks.MockRepositoryDatabase
{
    internal class WeatherForecastRepositoryMock
    {
        public Mock<IWeatherForecastRepository> MockingWeatherForecastRepository { get; set; }

        public WeatherForecastRepositoryMock()
        {
            MockingWeatherForecastRepository = new Mock<IWeatherForecastRepository>();
            Initialize();
        }

        private void Initialize()
        {
            MockingWeatherForecastRepository.Setup(x => x.GetWeatherForecastAsync()).ReturnsAsync(FakeDataGenerator.GetFakeWeather);
        }
    }
}

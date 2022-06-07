using Application.Interfaces.Infraestructure.Query.WeatherForecastQueryContracts;
using Moq;
using TestUnitarios.Mocks.MockRepositoryDatabase.Fake;

namespace TestUnitarios.Mocks.MockRepositoryDatabase
{
    internal class WeatherForecastRepositoryMock
    {
        public Mock<IWeatherForecastQueryAllContract> MockingWeatherForecastRepository { get; set; }

        public WeatherForecastRepositoryMock()
        {
            MockingWeatherForecastRepository = new Mock<IWeatherForecastQueryAllContract>();
            Initialize();
        }

        private void Initialize()
        {
            MockingWeatherForecastRepository.Setup(x => x.GetWeatherForecastAsync()).ReturnsAsync(FakeDataGenerator.GetFakeWeather);
        }
    }
}

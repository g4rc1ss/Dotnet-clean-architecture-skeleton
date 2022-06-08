using System.Threading.Tasks;
using Domain.Application.WeatherForecast.ComandCreate;
using Domain.Application.WeatherForecast.QueryAll;
using FluentAssertions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestUnitarios.Mocks.MockingInfraestructure.MoqWeatherForecast.MoqCommands;

namespace TestUnitarios.Testing.WeatherForecastTesting.CommandCreateTest;

[TestClass]
public class WeatherForecastCommandCreateTest
{

    [ClassInitialize]
    public static void OnInitializeTest(TestContext testContext)
    {
    }

    [TestMethod]
    public async Task CreateWeatherForecast_Then_ResponseWithSuccessTrue()
    {
        var mediator = CasesWeatherForecastCreateMediatorFactory.GetTrueCaseWithCommandCreateMock;

        var response = await mediator.Send(new WeatherForecastCommandCreateRequest
        {
            Summary = "Prueba de envio de test",
            TemperatureC = 1,
            TemperatureF = 2
        });

        response.Should().NotBeNull();
        response.Success.Should().Be(true);
    }

    [TestMethod]
    public async Task CreateWeatherForecast_Then_ResponseWithSuccessFalse()
    {
        var mediator = CasesWeatherForecastCreateMediatorFactory.GetFalseCaseWithCommandCreateMock;

        var response = await mediator.Send(new WeatherForecastCommandCreateRequest
        {
            Summary = "Prueba de envio de test",
            TemperatureC = 1,
            TemperatureF = 2
        });

        response.Should().NotBeNull();
        response.Success.Should().Be(false);
    }
}

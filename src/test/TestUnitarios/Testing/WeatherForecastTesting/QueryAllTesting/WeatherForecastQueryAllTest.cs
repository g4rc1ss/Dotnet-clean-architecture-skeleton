using System.Threading.Tasks;
using Domain.Application.WeatherForecast.QueryAll;
using FluentAssertions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestUnitarios.Testing.WeatherForecastTesting.QueryAllTesting;

[TestClass]
public class WeatherForecastQueryAllTest
{

    [ClassInitialize]
    public static void OnInitializeTest(TestContext testContext)
    {
    }

    [TestMethod]
    public async Task GetWeatherForecast_Then_ResponseWithOneOrMoreResults()
    {
        var mediator = CasesWeatherForecastQueryAllMediatorFactory.GetTrueCaseWithCommandCreateMock;

        var response = await mediator.Send(new WeatherForecastQueryAllRequest());

        response.Should().HaveCount(10);
        foreach (var item in response)
        {
            item.Should().NotBeNull();
            item.TemperatureC.Should().BeOfType(typeof(int));
        }
    }

    [TestMethod]
    public async Task GetWeatherForecast_Then_ResponseWithNullValue()
    {
        var mediator = CasesWeatherForecastQueryAllMediatorFactory.GetFalseCaseWithCommandCreateMock;

        var response = await mediator.Send(new WeatherForecastQueryAllRequest());

        response.Should().BeNull();
    }
}

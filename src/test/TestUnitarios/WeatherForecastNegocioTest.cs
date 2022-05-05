using System.Threading.Tasks;
using Application.Interfaces.Core;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestUnitarios;

[TestClass]
public class WeatherForecastNegocioTest
{
    public static IHost DependencyInjection { get; set; }

    [ClassInitialize]
    public static void OnInitializeTest(TestContext testContext)
    {
        DependencyInjection = HelperTesting.CreateDependencyInjection();
    }

    [TestMethod]
    public async Task GetWeatherForecast_Then_ResponseWithOneOrMoreResults()
    {
        var weatherService = DependencyInjection.Services.GetRequiredService<IWeatherForecastNegocio>();
        var response = await weatherService.GetWeatherForecastAsync();

        response.Should().HaveCount(10);
        foreach (var item in response)
        {
            item.Should().NotBeNull();
            item.TemperatureC.Should().BeOfType(typeof(int));
        }
    }
}

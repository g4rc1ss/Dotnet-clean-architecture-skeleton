using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TestUnitarios.Mocks.MockingInfraestructure.MoqWeatherForecast.MoqCommands.MoqCreate.CommandCreateValidatingFalseData;
using TestUnitarios.Mocks.MockingInfraestructure.MoqWeatherForecast.MoqCommands.MoqCreate.CommandCreateValidatingTrueData;

namespace TestUnitarios.Testing.WeatherForecastTesting.CommandCreateTest
{
    internal class CasesWeatherForecastCreateMediatorFactory
    {
        internal static IMediator GetTrueCaseWithCommandCreateMock => HelperTesting.CreateServiceProvider(services =>
        {
            services.AddTransient(serviceProvider => new WFCommandCreateTrueData().Mock.Object);
        }).GetRequiredService<IMediator>();

        internal static IMediator GetFalseCaseWithCommandCreateMock => HelperTesting.CreateServiceProvider(services =>
        {
            services.AddTransient(serviceProvider => new WFCommandCreateFalseData().Mock.Object);
        }).GetRequiredService<IMediator>();
    }
}

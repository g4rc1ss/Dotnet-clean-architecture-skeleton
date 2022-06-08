using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TestUnitarios.Mocks.MockingInfraestructure.MoqWeatherForecast.MoqQueries.QueryAll.QueryAllValidatingFalseData;
using TestUnitarios.Mocks.MockingInfraestructure.MoqWeatherForecast.MoqQueries.QueryAll.QueryAllValidatingTrueData;

namespace TestUnitarios.Testing.WeatherForecastTesting.QueryAllTesting
{
    internal class CasesWeatherForecastQueryAllMediatorFactory
    {
        internal static IMediator GetTrueCaseWithCommandCreateMock => HelperTesting.CreateServiceProvider(services =>
        {
            services.AddTransient(serviceProvider => new WFQueryAllTrueData().Mock.Object);
        }).GetRequiredService<IMediator>();

        internal static IMediator GetFalseCaseWithCommandCreateMock => HelperTesting.CreateServiceProvider(services =>
        {
            services.AddTransient(serviceProvider => new WFQueryAllFalseData().Mock.Object);
        }).GetRequiredService<IMediator>();
    }
}

using Microsoft.Extensions.DependencyInjection;
using Model;

namespace CourierService.Tests;

public class TestBase : IntegrationTestBase<Program>
{
    protected override IServiceCollection ClientServices(IServiceCollection services) => base.ClientServices(services)
        .AddSingleton<Api>()
        .AddSingleton<Orders>()
        .AddSingleton<Delivery>();

    protected override IServiceCollection ServerServices(IServiceCollection services) => base.ServerServices(services)
        .AddSingleton<PostalCode, PostalCodeFake>();

    protected Api Api
        => Client<Api>();
}

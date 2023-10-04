using Data.Memory;
using Logic;
using Model;

namespace CourierService;

public class Startup
{
    public void ConfigureServices(IServiceCollection services) => services
        .AddSingleton<Orders>()
        .AddSingleton<OrderRepository, MemoryOrderRepository>()
        .AddSingleton<ItemRepository, MemoryItemRepository>()
        .AddSingleton<Delivery>()
        .AddControllers();

    public void Configure(IApplicationBuilder app, IWebHostEnvironment _)
    {
        app.UseMiddleware<RateLimitingMiddleware>();
        app.UseRouting();
        app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
}

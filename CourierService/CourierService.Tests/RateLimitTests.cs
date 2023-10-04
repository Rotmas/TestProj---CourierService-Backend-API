using System.Net;

namespace CourierService.Tests;

public class RateLimitTests : TestBase
{
    [Fact]
    public async Task RateLimitingMiddleware_LimitsRequests()
    {
        foreach (var _ in Enumerable.Range(0, 10))
        {
            await Api.Orders.List();
        }
        var exception = await Assert.ThrowsAsync<HttpRequestException>(Api.Orders.List);
        Assert.Equal(HttpStatusCode.TooManyRequests, exception.StatusCode);
    }
}

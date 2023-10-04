using System.Collections.Concurrent;
using System.Net;

namespace CourierService
{
    public class RateLimitingMiddleware
    {
        readonly RequestDelegate Next;
        readonly ConcurrentDictionary<string, (DateTime, int)> RequestCounts = new();
        const int MaxRequestsAllowed = 10;
        const int Minutes = 1;

        public RateLimitingMiddleware(RequestDelegate next)
            => Next = next;

        public async Task Invoke(HttpContext context)
        {
            var ip = $"{context.Connection.RemoteIpAddress!}";
            var (lastRequestTime, requestsCount) = RequestCounts.GetOrAdd(ip, _ => (DateTime.UtcNow, 0));

            if (NoRequestsInLastMinute(lastRequestTime))
            {
                requestsCount = 0;
                lastRequestTime = DateTime.UtcNow;
            }

            requestsCount++;

            if (requestsCount > MaxRequestsAllowed)
            {
                context.Response.StatusCode = (int)HttpStatusCode.TooManyRequests;
                await context.Response.WriteAsync($"Rate limit exceeded. Try again in {lastRequestTime.AddMinutes(Minutes) - DateTime.UtcNow}.");
                return;
            }

            RequestCounts[ip] = (lastRequestTime, requestsCount);

            await Next(context);
        }

        static bool NoRequestsInLastMinute(DateTime lastRequestTime)
            => lastRequestTime.AddMinutes(Minutes) < DateTime.UtcNow;
    }
}

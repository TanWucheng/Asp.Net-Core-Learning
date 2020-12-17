using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace AspNetCoreApp.Domain
{
    public class RequestIpMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public RequestIpMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<RequestIpMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            _logger.LogInformation($"客户端请求IP: {context.Connection.RemoteIpAddress}");
            await _next.Invoke(context);
        }
    }
}

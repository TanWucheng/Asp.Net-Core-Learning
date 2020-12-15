using AspNetCoreApp.Domain;
using Microsoft.AspNetCore.Builder;

namespace AspNetCoreApp.Extension
{
    public static class RequestIpExtensions
    {
        public static IApplicationBuilder UseRequestIp(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestIpMiddleware>();
        }
    }
}

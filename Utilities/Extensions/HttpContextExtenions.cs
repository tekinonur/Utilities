using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;

namespace Utilities.Extensions;

public static class HttpContextExtenions
{
    public static string GetAccessToken(this HttpRequest request)
    {
        return request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
    }

    public static string GetUserAgent(this HttpRequest request)
    {
        return request.Headers[HeaderNames.UserAgent].ToString();
    }

    public static string GetUserAgent(this HttpContext context)
    {
        return context.Request.Headers[HeaderNames.UserAgent].ToString();
    }

    public static string GetIPAddress(this HttpContext context)
    {
        return context.Connection.RemoteIpAddress.ToString();
    }

    public static string GetReferrer(this HttpContext context)
    {
        return context.Request.Headers[HeaderNames.Referer].ToString();
    }
}
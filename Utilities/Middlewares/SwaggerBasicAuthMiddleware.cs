using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text;
using Utilities.Middlewares.Base;

namespace Utilities.Middlewares;

public class SwaggerBasicAuthMiddleware
{
    private readonly RequestDelegate next;

    public SwaggerBasicAuthMiddleware(RequestDelegate next) => this.next = next;

    public async Task InvokeAsync(HttpContext context, ISwaggerUserService swaggerUserService)
    {
        if (context.Request.Path.StartsWithSegments("/swagger"))
        {
            string authHeader = context.Request.Headers["Authorization"];
            if (authHeader != null && authHeader.StartsWith("Basic "))
            {
                var encodedUsernamePassword = authHeader.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries)[1]?.Trim();

                var decodedUsernamePassword = Encoding.UTF8.GetString(Convert.FromBase64String(encodedUsernamePassword));

                var username = decodedUsernamePassword.Split(':', 2)[0];
                var password = decodedUsernamePassword.Split(':', 2)[1];

                if (await IsAuthorized(username, password, swaggerUserService))
                {
                    await next.Invoke(context);
                    return;
                }
            }

            context.Response.Headers["WWW-Authenticate"] = "Basic";

            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        }
        else
        {
            await next.Invoke(context);
        }
    }

    public async Task<bool> IsAuthorized(string username, string password, ISwaggerUserService swaggerUserService)
    {
        return await swaggerUserService.IsAuthorized(username, password);
    }
}
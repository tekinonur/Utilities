using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using Utilities.Models;

namespace Utilities.Middlewares;

public class PerformanceMiddleware
{
    private readonly ILogger<PerformanceMiddleware> _logger;
    private readonly RequestDelegate _next;
    private readonly PerformanceSetting _performanceSetting;
    string[] Exclude = { "/TODO:Exclude enpoints" };

    public PerformanceMiddleware(
        RequestDelegate next,
        ILogger<PerformanceMiddleware> logger,
        IOptions<PerformanceSetting> performanceSetting)
    {
        _next = next;
        _logger = logger;
        _performanceSetting = performanceSetting.Value;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var sw = new Stopwatch();

        sw.Start();

        await _next(context);

        sw.Stop();

        if (_performanceSetting.LogMillisecond < sw.ElapsedMilliseconds && !Exclude.Contains(context.Request?.Method))
            _logger.LogWarning("[PerformanceError] Request {method} {path} it took about {elapsed} ms",
                context.Request?.Method,
                context.Request?.Path.Value,
                sw.ElapsedMilliseconds);
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Utilities.Models;

namespace Utilities.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;
    private readonly IHostEnvironment _env;
    private readonly IStringLocalizer<ExceptionMiddleware> _localizer;

    public ExceptionMiddleware(
        RequestDelegate next,
        ILogger<ExceptionMiddleware> logger,
        IHostEnvironment env,
        IStringLocalizer<ExceptionMiddleware> localizer)
    {
        _env = env;
        _logger = logger;
        _next = next;
        _localizer = localizer;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleException(context, ex);
        }
    }

    private Task HandleException(HttpContext context, Exception ex)
    {
        string err = ex.InnerException?.Message ?? ex.Message;
        _logger.LogError(ex, err);

        var response = context.Response;
        response.ContentType = "application/json";
        response.StatusCode = StatusCodes.Status500InternalServerError;

        err = _localizer[err] ?? err;
        var baseResponse = new ApiResponse<string>(err);
        return context.Response.WriteAsync(JsonSerializer.Serialize(baseResponse));
    }
}
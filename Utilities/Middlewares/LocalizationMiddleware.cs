using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Globalization;
using Utilities.Extensions;

namespace Utilities.Middlewares;

public class LocalizationMiddleware : IMiddleware
{
    private readonly string _defaultLanguageCode = "tr-TR";

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        CultureInfo culture = new CultureInfo(_defaultLanguageCode);

        var cultureKey = context.Request.GetTypedHeaders().AcceptLanguage.FirstOrDefault()?.Value.Value;
        if (cultureKey.IsNotNullOrEmpty() && DoesCultureExist(cultureKey))
            culture = new CultureInfo(cultureKey);

        Thread.CurrentThread.CurrentCulture = culture;
        Thread.CurrentThread.CurrentUICulture = culture;

        await next(context);
    }

    private static bool DoesCultureExist(string cultureName)
    {
        return CultureInfo.GetCultures(CultureTypes.AllCultures).Any(culture => string.Equals(culture.Name, cultureName,
            StringComparison.CurrentCultureIgnoreCase));
    }
}
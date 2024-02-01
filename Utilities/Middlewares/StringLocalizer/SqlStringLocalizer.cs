using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Localization;
using Utilities.Enums;
using Utilities.Extensions;
using Utilities.Models;

namespace Utilities.Middlewares.StringLocalizer;

public class SqlStringLocalizer : IStringLocalizer
{
    private readonly IMemoryCache _cache;
    private readonly IServiceProvider _serviceProvider;

    public SqlStringLocalizer(
        IMemoryCache cache,
        IServiceProvider serviceProvider)
    {
        _cache = cache;
        _serviceProvider = serviceProvider;
    }

    public LocalizedString this[string name]
    {
        get
        {
            string value = GetString(name);
            return new LocalizedString(name, value ?? name, value == null);
        }
    }

    public LocalizedString this[string name, params object[] arguments]
    {
        get
        {
            var actualValue = this[name];
            return !actualValue.ResourceNotFound
                ? new LocalizedString(name, string.Format(actualValue.Value, arguments), false)
                : actualValue;
        }
    }

    public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
    {
        //Çoklu dil gelince SQL ya da inmemory cacheten çekilecek
        SupportedLanguages supportedLanguages = Thread.CurrentThread.CurrentUICulture.Name.GetEnumByDescription<SupportedLanguages>();

        var stringLookups = new List<StringLookup>(); //context.GetByLanguageID(supportedLanguages.ToInt()).Result;

        foreach (var item in stringLookups)
        {
            yield return new LocalizedString(item.stringid, item.value, false);
        }
    }

    private string GetString(string key)
    {
        SupportedLanguages supportedLanguage = Thread.CurrentThread.CurrentUICulture.Name.GetEnumByDescription<SupportedLanguages>();

        string cacheKey = $"locale_{Thread.CurrentThread.CurrentUICulture.Name}_{key}";
        string cacheValue;
        if (_cache.TryGetValue(cacheKey, out cacheValue))
            return cacheValue;
        string result = GetValueFromSql(key, supportedLanguage);
        if (result.IsNotNullOrEmpty()) _cache.Set(cacheKey, result);
        return result;
    }

    private string GetValueFromSql(string propertyName, SupportedLanguages supportedLanguage)
    {
        //Çoklu dil gelince SQL ya da inmemory cacheten çekilecek
        var stringLookup = new StringLookup(); // context.GetByKeyAndLanguageID(propertyName, supportedLanguage.ToInt()).Result;
        if (stringLookup == null) return default;
        return stringLookup.value;
    }
}
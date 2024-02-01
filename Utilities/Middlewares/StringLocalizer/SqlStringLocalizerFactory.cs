using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Localization;

namespace Utilities.Middlewares.StringLocalizer;

public class SqlStringLocalizerFactory : IStringLocalizerFactory
{
    private readonly IMemoryCache _cache;
    private readonly IServiceProvider _serviceProvider;

    public SqlStringLocalizerFactory(
        IMemoryCache cache,
        IServiceProvider serviceProvider)
    {
        _cache = cache;
        _serviceProvider = serviceProvider;
    }

    public IStringLocalizer Create(Type resourceSource) =>
        new SqlStringLocalizer(_cache, _serviceProvider);
    public IStringLocalizer Create(string baseName, string location) =>
        new SqlStringLocalizer(_cache, _serviceProvider);
}
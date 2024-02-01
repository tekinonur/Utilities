using Microsoft.Extensions.DependencyInjection;

namespace Utilities.Extensions;

public static class ServiceProviderExtensions
{
    public static T GetRequiredServiceWithScope<T>(this IServiceProvider serviceProvider)
    {
        return serviceProvider.CreateScope().ServiceProvider.GetRequiredService<T>();
    }
}
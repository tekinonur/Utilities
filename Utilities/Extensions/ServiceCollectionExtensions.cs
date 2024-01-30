using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Utilities.Extensions;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Belirli bir isim şablonuna uyan sınıfları ve bu sınıfları ilgili interface ile eşleştirip IoC konteynerine ekler.
    /// </summary>
    /// <param name="services">IServiceCollection nesnesi</param>
    /// <param name="assembly">Implementasyonların bulunduğu assembly</param>
    /// <param name="typeNameSuffix">Implementasyon isimlerinin sonuna eklenecek şablon</param>
    public static void AddImplementations(this IServiceCollection services, Assembly assembly, string typeNameSuffix)
    {
        var implementationTypes = assembly.GetTypes()
            .Where(type => type.IsClass && !type.IsAbstract && type.Name.EndsWith(typeNameSuffix));

        foreach (var implementationType in implementationTypes)
        {
            var interfaceType = implementationType.GetInterfaces().FirstOrDefault();

            if (interfaceType != null)
            {
                services.AddTransient(interfaceType, implementationType);
            }
        }
    }

    public static void AddImplementations<T>(this IServiceCollection services, Assembly assembly, string typeNameSuffix)
    {
        var implementationTypes = assembly.GetTypes()
            .Where(type => type.IsClass && !type.IsAbstract && type.Name.EndsWith(typeNameSuffix));

        foreach (var implementationType in implementationTypes)
        {
            var interfaceType = implementationType.GetInterfaces().FirstOrDefault();

            if (interfaceType != null && typeof(T).IsAssignableFrom(interfaceType))
            {
                services.AddTransient(interfaceType, implementationType);
            }
        }
    }
}
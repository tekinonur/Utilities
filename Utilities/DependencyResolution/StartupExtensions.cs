using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Utilities.Extensions;
using Utilities.Helpers;

namespace Utilities.DependencyResolution;

public static class StartupExtensions
{
    /// <summary>
    /// Registers the items included in the Utilities project for Dependency Injection
    /// </summary>
    /// <param name="services">Your existing services collection</param>
    /// <param name="configuration">The configuration instance to load settings</param>
    public static void RegisterUtilities(this IServiceCollection services, IConfiguration configuration)
    {
        /* TODO:Tüm servisler burada register edilecek Utilities içindeki */
        // Assuming IHelper and IFileHelper are within the Utilities.Helpers namespace
        //services.AddImplementations<IHelper>(typeof(Utilities.Helpers).Assembly, "Helper");
        //services.AddImplementations<IHelper>(Assembly.GetExecutingAssembly(), "Helper");


        //services.AddImplementations(typeof(Utilities).Assembly, "Helper");
        //Bind additional services
        // services.AddTransient<IUrlSlugGenerator, UrlSlugGenerator>();
        // services.AddTransient<ITimeProvider, TimeProvider>();
        // services.AddTransient<ITimeSpanProvider, TimeSpanProvider>();
        // services.AddTransient<IPathProvider, PathProvider>();
        // services.AddTransient<IGuidProvider, GuidProvider>();
        // services.AddTransient<IDatabaseEnvironmentModelFactory, DatabaseEnvironmentModelFactory>();
        // services.AddTransient<IFileProvider, FileProvider>();
        // services.AddTransient<IDirectoryProvider, DirectoryProvider>();
        // services.AddTransient<IAesEncryptionService, AesEncryptionService>();
        // services.AddTransient<IAesDerivedKeyEncryptionService, AesDerivedKeyEncryptionService>();
        // services.Configure<AesEncryptionServiceOptions>(
        //     configuration.GetSection(nameof(AesEncryptionServiceOptions)));
        // services.Configure<AesDerivedKeyEncryptionServiceOptions>(configuration.GetSection(nameof(AesDerivedKeyEncryptionServiceOptions)));
    }
}
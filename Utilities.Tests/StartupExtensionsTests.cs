using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Utilities.DependencyResolution;
using Xunit;

namespace Utilities.Tests;

public class StartupExtensionsTests
{
    /* TODO Test edilecek*/
    [Fact]
    public void RegisterUtilities_Should_Register_IHelper()
    {
        // Arrange
        var services = new ServiceCollection();
        var configuration = new ConfigurationBuilder().Build(); // You may need to set up a configuration

        // Act
        services.RegisterUtilities(configuration);

        // Assert
        var serviceProvider = services.BuildServiceProvider();
        var helper = serviceProvider.GetService<IHelper>();
        Assert.NotNull(helper);
        // Add additional assertions as needed
    }
}

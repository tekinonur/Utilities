using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Utilities.Services.SmsService
{
    public static class SmsServiceCollectionExtensions
    {
        public static IServiceCollection AddSmsService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ISmsService, SmsService>();

            return services;
        }
    }
}
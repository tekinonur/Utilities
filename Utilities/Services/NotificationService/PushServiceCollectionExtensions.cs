using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Services.NotificationService
{
    public static class PushServiceCollectionExtensions
    {
        public static IServiceCollection AddPushNotificationService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IPushNotificationService, PushNotificationService>();

            return services;
        }
    }
}

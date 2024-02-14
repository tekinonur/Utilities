using Utilities.Services.NotificationService.Models;

namespace Utilities.Services.NotificationService;

public interface IPushNotificationService
{
    Task<bool> SendNotification(PushMessage request);
}
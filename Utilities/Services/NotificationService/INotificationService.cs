using Utilities.Services.NotificationService.Models;

namespace Utilities.Services.NotificationService;

public interface INotificationService
{
    Task<bool> SendNotification(SendNotificationRequest request);
}
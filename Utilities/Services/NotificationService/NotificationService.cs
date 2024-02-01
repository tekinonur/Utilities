using System.Net.Mail;
using System.Net;
using FirebaseAdmin.Messaging;
using Microsoft.Extensions.Logging;
using Utilities.Services.NotificationService.Models;

namespace Utilities.Services.NotificationService;

public class NotificationService : INotificationService
{
    private readonly ILogger<NotificationService> _logger;

    public NotificationService(
        ILogger<NotificationService> logger)
    {
        _logger = logger;
    }

    public async Task<bool> SendNotification(SendNotificationRequest request)
    {
        if (string.IsNullOrEmpty(request.DeviceToken))
            return false;

        try
        {
            var message = new Message
            {
                Notification = new Notification
                {
                    Title = request.Title,
                    Body = request.Body
                },
                Token = request.DeviceToken,
                Data = request.Data
            };

            var messaging = FirebaseMessaging.DefaultInstance;
            string res = await messaging.SendAsync(message);
            _logger.LogWarning($"SendNotification Res : {res}");
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return false;
        }
    }
}
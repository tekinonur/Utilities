using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Services.NotificationService.Models;

namespace Utilities.Services.NotificationService
{
    public interface IPushNotificationRepository
    {
        Task<IEnumerable<UserNotification>> GetUserNotification(Guid userid);
        Task<IEnumerable<UserNotification>> GetUserNotificationByIDs(List<Guid> ids);
        Task<int> GetUnReadNotificationCount(Guid userid);
    }
}

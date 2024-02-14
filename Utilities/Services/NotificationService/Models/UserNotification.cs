using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Services.NotificationService.Models
{
    public class UserNotification
    {
        public int Id { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Content { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ActionTag { get; set; } = string.Empty;
        public string ActionParameter { get; set; } = string.Empty;
        public bool SentPushNotification { get; set; } = false;
        public bool Read { get; set; } = false;
        public string? Url { get; set; }
        public int UserId { get; set; }
    }
}

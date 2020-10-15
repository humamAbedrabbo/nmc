using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NMC.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public NotificationType NotificationType { get; set; }
        public string Message { get; set; }
        public bool Unread { get; set; }
        public ModuleName Module { get; set; }
        public string RelatedId { get; set; }
        public bool Active { get; set; }
        public IEnumerable<UserNotification> UserNotifications { get; set; }

        public string GetFriendlyTime() => $"{(DateTime.Now - Date).TotalMinutes} mins ago";
    }
}

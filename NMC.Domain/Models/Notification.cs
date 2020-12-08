using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NMC.Domain.Models
{
    public class Notification
    {
        public int Id { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Date { get; set; }

        [Display(Name = "Notification Type")]
        public NotificationType NotificationType { get; set; }

        [Display(Name = "Message")]
        public string Message { get; set; }

        [Display(Name = "Unread")]
        public bool Unread { get; set; }

        [Display(Name = "Module")]
        public ModuleName Module { get; set; }

        [Display(Name = "Related to")]
        public string RelatedId { get; set; }

        [Display(Name = "Active")]
        public bool Active { get; set; }

        public IEnumerable<UserNotification> UserNotifications { get; set; }

        public string GetFriendlyTime() => $"{(DateTime.Now - Date).TotalMinutes} mins ago";
    }
}

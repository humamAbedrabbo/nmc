using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    public class UserNotification
    {
        public int Id { get; set; }

        [Display(Name = "Notification")]
        public int NotificationId { get; set; }

        [Display(Name = "Notification")]
        public Notification Notification { get; set; }

        [Display(Name = "Username")]
        public string Username { get; set; }

        [Display(Name = "Unread")]
        public bool Unread { get; set; }

        [Display(Name = "Active")]
        public bool Active { get; set; }
    }
}

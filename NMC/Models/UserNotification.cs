namespace NMC.Models
{
    public class UserNotification
    {
        public int Id { get; set; }
        public int NotificationId { get; set; }
        public Notification Notification { get; set; }
        public string Username { get; set; }
        public bool Unread { get; set; }
        public bool Active { get; set; }
    }
}

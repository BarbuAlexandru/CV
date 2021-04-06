using System;

namespace LiveShow.Dal.Models
{
    public class UserNotification
    {
        public Guid UserId { get; private set; }

        public Guid NotificationId { get; private set; }

        public User User { get; private set; }

        public Notification Notification { get; private set; }

        public bool IsRead { get; private set; }

    }

}

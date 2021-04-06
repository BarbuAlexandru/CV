using System;
using System.ComponentModel.DataAnnotations;

namespace LiveShow.Dal.Models
{
    public class Notification
    {
        public Guid Id { get; private set; }

        public DateTime DateTime { get; private set; }

        public NotificationType Type { get; private set; }

        public DateTime? OriginalDateTime { get; private set; }

        public string OriginalVenue { get; private set; }

        [Required]
        public Show Show { get; private set; }
    }
}

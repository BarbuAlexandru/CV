using System;

namespace ProMonitor.Models
{
    public partial class UserTaskCon
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
        public string UserId { get; set; }
        public Guid TaskId { get; set; }

        public virtual Task Task { get; set; }
        public virtual User User { get; set; }
    }
}

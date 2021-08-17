using System;

namespace ProMonitor.Models
{
    public partial class UserProjectCon
    {
        public Guid Id { get; set; }
        public string Role { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string UserId { get; set; }
        public Guid ProjectId { get; set; }

        public virtual Project Project { get; set; }
        public virtual User User { get; set; }
    }
}

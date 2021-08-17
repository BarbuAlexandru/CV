using System;
using System.Collections.Generic;

namespace ProMonitor.Models
{
    public partial class Task
    {
        public Task()
        {
            UserTaskCon = new HashSet<UserTaskCon>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Cost { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EstimatedEndDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }
        public Guid ProjectId { get; set; }

        public virtual Project Project { get; set; }
        public virtual ICollection<UserTaskCon> UserTaskCon { get; set; }
    }
}

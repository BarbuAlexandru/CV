using System;
using System.Collections.Generic;

namespace ProMonitor.Models
{
    public partial class Project
    {
        public Project()
        {
            Task = new HashSet<Task>();
            UserProjectCon = new HashSet<UserProjectCon>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Budget { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EstimatedEndDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }
        public string OwnerId { get; set; }

        public virtual User Owner { get; set; }
        public virtual ICollection<Task> Task { get; set; }
        public virtual ICollection<UserProjectCon> UserProjectCon { get; set; }
    }
}

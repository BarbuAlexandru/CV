using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ProMonitor.Models
{
    public partial class User : IdentityUser
    {
        public User()
        {
            Project = new HashSet<Project>();
            UserProjectCon = new HashSet<UserProjectCon>();
            UserTaskCon = new HashSet<UserTaskCon>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Project> Project { get; set; }
        public virtual ICollection<UserProjectCon> UserProjectCon { get; set; }
        public virtual ICollection<UserTaskCon> UserTaskCon { get; set; }
    }
}

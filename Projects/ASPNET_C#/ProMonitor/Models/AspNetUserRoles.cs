using System;
using System.Collections.Generic;

namespace ProMonitor.Models
{
    public partial class AspNetUserRoles
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }

        public virtual AspNetRoles Role { get; set; }
        public virtual User User { get; set; }
    }
}

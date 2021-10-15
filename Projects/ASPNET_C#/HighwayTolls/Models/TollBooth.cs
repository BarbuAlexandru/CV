using System;
using System.Collections.Generic;

#nullable disable

namespace HighwayTolls.Models
{
    public partial class TollBooth
    {
        public TollBooth()
        {
            Employees = new HashSet<Employee>();
        }

        public Guid Id { get; set; }
        public Guid TollLocationId { get; set; }

        public virtual TollLocation TollLocation { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}

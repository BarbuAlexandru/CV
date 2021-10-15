using System;
using System.Collections.Generic;

#nullable disable

namespace HighwayTolls.Models
{
    public partial class Trip
    {
        public Trip()
        {
            TripPayments = new HashSet<TripPayment>();
        }

        public Guid Id { get; set; }
        public Guid StartCityId { get; set; }
        public Guid? EndCityId { get; set; }
        public string Vehicle { get; set; }
        public string EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual TollLocation EndCity { get; set; }
        public virtual TollLocation StartCity { get; set; }
        public virtual ICollection<TripPayment> TripPayments { get; set; }
    }
}

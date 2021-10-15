using System;
using System.Collections.Generic;

#nullable disable

namespace HighwayTolls.Models
{
    public partial class TripPayment
    {
        public Guid Id { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public Guid LocationId { get; set; }
        public Guid TripId { get; set; }

        public virtual Trip Trip { get; set; }
    }
}

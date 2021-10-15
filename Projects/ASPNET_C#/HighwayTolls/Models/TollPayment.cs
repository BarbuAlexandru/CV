using System;
using System.Collections.Generic;

#nullable disable

namespace HighwayTolls.Models
{
    public partial class TollPayment
    {
        public Guid Id { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public Guid LocationId { get; set; }
        public string EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
    }
}

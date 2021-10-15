using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

#nullable disable

namespace HighwayTolls.Models
{
    public partial class Employee : IdentityUser
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public Guid? TollBoothId { get; set; }

        public virtual TollBooth TollBooth { get; set; }

        public virtual ICollection<TollPayment> TollPayments { get; set; }
        public virtual ICollection<Trip> Trips { get; set; }
    }
}

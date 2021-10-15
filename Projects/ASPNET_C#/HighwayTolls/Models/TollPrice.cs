using System;
using System.Collections.Generic;

#nullable disable

namespace HighwayTolls.Models
{
    public partial class TollPrice
    {
        public Guid Id { get; set; }
        public string Vehicle { get; set; }
        public int Price { get; set; }
        public Guid TollLocationId { get; set; }

        public virtual TollLocation TollLocation { get; set; }
    }
}

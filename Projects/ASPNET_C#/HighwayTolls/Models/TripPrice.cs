using System;
using System.Collections.Generic;

#nullable disable

namespace HighwayTolls.Models
{
    public partial class TripPrice
    {
        public Guid Id { get; set; }
        public Guid StartCityId { get; set; }
        public Guid EndCityId { get; set; }
        public int Price { get; set; }
        public string Vehicle { get; set; }

        public virtual TollLocation EndCity { get; set; }
        public virtual TollLocation StartCity { get; set; }
    }
}

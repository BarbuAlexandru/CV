using System;
using System.Collections.Generic;

#nullable disable

namespace HighwayTolls.Models
{
    public partial class TollLocation
    {
        public TollLocation()
        {
            TollBooths = new HashSet<TollBooth>();
            TollPrices = new HashSet<TollPrice>();
            TripEndCities = new HashSet<Trip>();
            TripPriceEndCities = new HashSet<TripPrice>();
            TripPriceStartCities = new HashSet<TripPrice>();
            TripStartCities = new HashSet<Trip>();
        }

        public Guid Id { get; set; }
        public string City { get; set; }

        public virtual ICollection<TollBooth> TollBooths { get; set; }
        public virtual ICollection<TollPrice> TollPrices { get; set; }
        public virtual ICollection<Trip> TripEndCities { get; set; }
        public virtual ICollection<TripPrice> TripPriceEndCities { get; set; }
        public virtual ICollection<TripPrice> TripPriceStartCities { get; set; }
        public virtual ICollection<Trip> TripStartCities { get; set; }
    }
}

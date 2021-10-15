using HighwayTolls.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HighwayTolls.ViewModel
{
    public class EndTripViewModel
    {
        public List<Trip> UnfinishedTrips { get; set; }
        public TollLocation TollLocation { get; set; }

        public EndTripViewModel(List<Trip> UnfinishedTrips, TollLocation TollLocation)
        {
            this.UnfinishedTrips = UnfinishedTrips;
            this.TollLocation = TollLocation;
        }
    }
}

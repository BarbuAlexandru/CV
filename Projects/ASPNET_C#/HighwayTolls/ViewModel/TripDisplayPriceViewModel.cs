using HighwayTolls.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HighwayTolls.ViewModel
{
    public class TripDisplayPriceViewModel
    {

        public TollLocation StartCity { get; set; }
        public TollLocation EndCity { get; set; }

        public Trip Trip { get; set; }
        public int Price { get; set; }

        public TripDisplayPriceViewModel(TollLocation StartCity, TollLocation EndCity, Trip Trip, int Price)
        {
            this.StartCity = StartCity;
            this.EndCity = EndCity;
            this.Trip = Trip;
            this.Price = Price;
        }

    }
}

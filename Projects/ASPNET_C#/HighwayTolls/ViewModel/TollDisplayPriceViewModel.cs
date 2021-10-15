using HighwayTolls.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HighwayTolls.ViewModel
{
    public class TollDisplayPriceViewModel
    {
        public TollLocation Location { get; set; }
        public string VehicleType { get; set; }
        public int Price { get; set; }

        public TollDisplayPriceViewModel(TollLocation location, string vehicleType, int price)
        {
            this.Location = location;
            this.VehicleType = vehicleType;
            this.Price = price;
        }
    }
}

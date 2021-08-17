using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketPlane.ApplicationLogic.DataModel
{
    public class PlaneType
    {
        public Guid Id { set; get; }
        public string Model { set; get; }
        public string Manufacturer { set; get; }
        public int CapacityBusiness { set; get; }
        public int CapacityEconomy { set; get; }
        public ICollection<Flight>? Flight { get; set; }

    }
}
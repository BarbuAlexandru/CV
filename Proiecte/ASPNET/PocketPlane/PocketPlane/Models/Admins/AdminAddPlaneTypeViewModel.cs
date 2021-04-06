using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketPlane.Models.Admins
{
    public class AdminAddPlaneTypeViewModel
    {
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public int CapacityBusiness { get; set; }
        public int CapacityEconomy { get; set; }

    }
}

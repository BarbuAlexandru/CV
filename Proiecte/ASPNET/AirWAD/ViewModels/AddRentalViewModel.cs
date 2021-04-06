using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirWAD.ViewModels
{
    public class AddRentalViewModel
    {
        public string City { get; set; }
        public string Address { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

    }
}

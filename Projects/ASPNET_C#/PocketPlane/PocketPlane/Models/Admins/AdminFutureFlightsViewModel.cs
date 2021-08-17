using PocketPlane.ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketPlane.Models.Admins
{
    public class AdminFutureFlightsViewModel
    {
        public IEnumerable<Flight> FutureFlights { get; set; }
    }
}

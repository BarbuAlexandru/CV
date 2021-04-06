using PocketPlane.ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketPlane.Models.Admins
{
    public class AdminPastFlightsViewModel
    {
        public IEnumerable<Flight> PastFlights { get; set; }
    }
}

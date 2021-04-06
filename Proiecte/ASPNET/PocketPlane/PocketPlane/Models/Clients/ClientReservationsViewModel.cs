using PocketPlane.ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketPlane.Models.Clients
{
    public class ClientReservationsViewModel
    {
        public IEnumerable<Reservation> Reservations { get; set; }
    }
}

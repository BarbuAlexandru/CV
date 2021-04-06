using AirWAD.Models.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirWAD.ViewModels
{
    public class BoughtRentalsViewModel
    {
        public IEnumerable<Reservation> Reservations { get; set; }
    }
}

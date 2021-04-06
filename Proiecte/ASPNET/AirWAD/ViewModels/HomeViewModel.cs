using AirWAD.Models.DataBase;
using AirWAD.Repository.Abstraction;
using AirWAD.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirWAD.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<News> News { get; set; }

        public IEnumerable<Reservation> Reservations { get; set; }

        public IEnumerable<Listing> Listings { get; set; }
    }
}

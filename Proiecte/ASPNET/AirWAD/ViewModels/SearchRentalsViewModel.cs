using AirWAD.Models.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirWAD.ViewModels
{
    public class SearchRentalsViewModel
    {
        public IEnumerable<Listing> Listings { get; set; }

    }
}

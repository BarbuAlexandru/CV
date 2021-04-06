﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketPlane.Models.Admins
{
    public class AdminEditFlightViewModel
    {
        public Guid FlightId { get; set; }
        public string FlightNo { get; set; }
        public decimal BusinessPrice { get; set; }
        public decimal EconomyPrice { get; set; }
        public DateTime DepartureDate { get; set; }
        public string DepartureCity { get; set; }
        public string DepartureAirport { get; set; }
        public string DepartureHour { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string ArrivalAirport { get; set; }
        public string ArrivalCity { get; set; }
        public string ArrivalHour { get; set; }
    }
}
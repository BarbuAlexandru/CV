using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PocketPlane.ApplicationLogic.DataModel
{
    public class FlightSchedule
    {
        public Guid Id { set; get; }
        public DateTime DepartureDate { set; get; }
        public string DepartureCity { set; get; }
        public string DepartureAirport { set; get; }
        public string DepartureHour { set; get; }

        public DateTime ArrivalDate { set; get; }
        public string ArrivalCity { set; get; }
        public string ArrivalAirport { set; get; }
        public string ArrivalHour { set; get; }
    }
}
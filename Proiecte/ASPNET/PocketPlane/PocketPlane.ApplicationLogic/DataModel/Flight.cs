using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PocketPlane.ApplicationLogic.DataModel
{
    public class Flight
    {
        [Key]
        public Guid Id { set; get; }   
        
        public string FlightNo { set; get; }
        public Admin? Admin { set; get; }    
        public FlightSchedule? FlightSchedule { set; get; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal BusinessPrice { set; get; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal EconomyPrice { set; get; }

        public ICollection<Reservation>? Reservations { get; set; }
    }
}
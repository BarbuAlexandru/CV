using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AirWAD.Models.DataBase
{
    public class Rental
    {
        [Key]
        public Guid Id { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public byte Image { get; set; }

        public ICollection<Listing>? Listings { get; set; }
        public ICollection<Reservation>? Reservations { get; set; }
    }
}

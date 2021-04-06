using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AirWAD.Models.DataBase
{
    public class Listing
    {
        [Key]
        public Guid Id { get; set; }
        [Column(TypeName = "Date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "Date")]
        public DateTime EndDate { get; set; }
        public int Price { get; set; }

        public ListingStatistics? ListingStatistics { get; set; }
        public User? User { get; set; }
        public Guid RentalID { get; set; }
        public Rental Rental { get; set; }
    }
}

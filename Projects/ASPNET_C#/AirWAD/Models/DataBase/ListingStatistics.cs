using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AirWAD.Models.DataBase
{
    public class ListingStatistics
    {
        [Key]
        public Guid Id { get; set; }
        public int DayRented { get; set; }
        public int DaysUnRented { get; set; }
        public int MoneyMade { get; set; }

        public Guid? ListingID { get; set; }
        public Listing? Listing { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AirWAD.Models.DataBase
{
    public class UserStatistics
    {
        [Key]
        public Guid Id { get; set; }
        public int RentalsAdded { get; set; }
        public int RentalsBought { get; set; }
        public int MoneyMade { get; set; }
        public int MoneySpent { get; set; }

        public User? User { get; set; }
    }
}

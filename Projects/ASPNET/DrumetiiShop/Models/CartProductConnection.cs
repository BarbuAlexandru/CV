using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DrumetiiShop.Models
{
    public class CartProductConnection
    {
        [Key]
        public Guid Id { get; set; }
        public int NrOfProducts { get; set; }

        //foreign key
        public int ProductId { get; set; }
        public Guid CartId { get; set; }
    }
}

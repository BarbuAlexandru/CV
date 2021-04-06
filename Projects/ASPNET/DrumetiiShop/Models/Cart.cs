using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DrumetiiShop.Models
{
    public class Cart
    {
        [Key]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
    }
}

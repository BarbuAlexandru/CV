using System;
using System.ComponentModel.DataAnnotations;

namespace LiveShow.Dal.Models
{
    public class Genre
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}
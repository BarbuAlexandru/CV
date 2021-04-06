using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace LiveShow.Dal.Models
{
    public class Show
    {
        public Guid Id { get; set; }

        public bool IsCanceled { get; set; }

        public User Artist { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Venue { get; set; }

        public Genre Genre { get; set; }

        [Required]
        public Guid GenreId { get; set; }

        public ICollection<Attendance> Attendances { get; set; }

        public Show()
        {
            Attendances = new Collection<Attendance>();
        }
    }
}
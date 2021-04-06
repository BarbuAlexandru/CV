using LiveShow.Services.Models.User;
using System;

namespace LiveShow.Services.Models.Show
{
    public class ShowDto
    {
        public Guid Id { get; set; }

        public bool IsCanceled { get; set; }

        public UserDto Artist { get; set; }

        public DateTime DateTime { get; set; }

        public string Venue { get; set; }

        public GenreDto Genre { get; set; }

        public Guid GenreId { get; set; }
    }
}

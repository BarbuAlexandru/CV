using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UnblockMe_App.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            Car = new HashSet<Car>();
            UserRatingUserRated = new HashSet<UserRating>();
            UserRatingUserRatingNavigation = new HashSet<UserRating>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AdditionalInfo { get; set; }
        public double? AverageRating { get; set; }

        public virtual ICollection<Car> Car { get; set; }
        public virtual ICollection<UserRating> UserRatingUserRated { get; set; }
        public virtual ICollection<UserRating> UserRatingUserRatingNavigation { get; set; }
    }
}

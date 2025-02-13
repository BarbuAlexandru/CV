﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UnblockMe_App.Models
{
    public partial class UserRating
    {
        public Guid Id { get; set; }
        public string UserRatedId { get; set; }
        public string UserRatingId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }

        public virtual User UserRated { get; set; }
        public virtual User UserRatingNavigation { get; set; }
    }
}

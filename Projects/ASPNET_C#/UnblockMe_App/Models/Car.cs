using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UnblockMe_App.Models
{
    public partial class Car
    {
        public string LicencePlate { get; set; }
        public string OwnerId { get; set; }
        public string Maker { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string AdditionalInfo { get; set; }
        public string BlockedLicencePlate { get; set; }
        public string BlockedByLicencePlate { get; set; }

        public virtual User Owner { get; set; }
    }
}

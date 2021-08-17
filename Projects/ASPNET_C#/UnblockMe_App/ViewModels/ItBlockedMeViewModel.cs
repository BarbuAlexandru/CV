using System.Collections.Generic;
using UnblockMe_App.Models;

namespace UnblockMe_App.ViewModels
{
    public class ItBlockedMeViewModel
    {
        public Car CarBlocking { get; set; }
        public List<Car> UserCars { get; set; }

        public ItBlockedMeViewModel(Car carBlocking, List<Car> userCars)
        {
            this.UserCars = userCars;
            this.CarBlocking = carBlocking;
        }
    }
}

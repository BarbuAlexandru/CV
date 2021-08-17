using System.Collections.Generic;
using UnblockMe_App.Models;

namespace UnblockMe_App.ViewModels
{
    public class IBlockedItViewModel
    {
        public Car CarBlocked { get; set; }
        public List<Car> UserCars { get; set; }

        public IBlockedItViewModel(Car carBlocked, List<Car> userCars)
        {
            this.UserCars = userCars;
            this.CarBlocked = carBlocked;
        }
    }
}

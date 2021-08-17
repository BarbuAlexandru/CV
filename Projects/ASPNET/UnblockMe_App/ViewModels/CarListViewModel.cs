using System.Collections.Generic;
using UnblockMe_App.Models;

namespace UnblockMe_App.ViewModels
{
    public class CarListViewModel
    {
        public List<Car> UserCars { get; set; }

        public CarListViewModel(List<Car> userCars)
        {
            this.UserCars = userCars;
        }
    }
}

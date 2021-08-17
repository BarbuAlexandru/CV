using System.Collections.Generic;
using UnblockMe_App.Models;

namespace UnblockMe_App.ViewModels
{
    public class BlockingIndexViewModel
    {
        public List<Car> UserCars { get; set; }
        public List<Car> BlockedCars { get; set; }
        public List<Car> BlockedByCars { get; set; }

        public BlockingIndexViewModel(List<Car> userCars, List<Car> blockedCars, List<Car> blockedByCars)
        {
            this.UserCars = userCars;
            this.BlockedCars = blockedCars;
            this.BlockedByCars = blockedByCars;
        }
    }
}

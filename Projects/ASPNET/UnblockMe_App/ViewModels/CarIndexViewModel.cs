using UnblockMe_App.Models;

namespace UnblockMe_App.ViewModels
{
    public class CarIndexViewModel
    {
        public Car CurrentCar { get; set; }
        public User CurrentUser { get; set; }

        public CarIndexViewModel(Car currentCar, User currentUser)
        {
            this.CurrentCar = currentCar;
            this.CurrentUser = currentUser;
        }
    }
}

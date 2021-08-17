using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UnblockMe_App.Models;
using UnblockMe_App.Services;
using UnblockMe_App.ViewModels;

namespace UnblockMe_App.Controllers
{
    [Authorize]
    public class CarController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly CarService carService;
        private readonly UserService userService;

        public CarController(UserManager<User> userManager, CarService carService, UserService userService)
        {
            this.userManager = userManager;
            this.carService = carService;
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> List(string licencePlate, string maker, string model, string color, string additionalInformation)
        {
            var currentUser = await userManager.GetUserAsync(User);
            if (licencePlate != null)
            {
                carService.AddNewCar(currentUser, licencePlate, maker, model, color, additionalInformation);
            }
            return View(new CarListViewModel(
                    userService.GetUserCarsByUserId(currentUser.Id)
                ));
        }

        [HttpGet]
        public IActionResult Delete(string Id)
        {
            carService.DeleteCarById(Id);
            return Redirect(Url.Action("List", "Car"));
        }

        [HttpGet]
        public async Task<IActionResult> Index(string Id)
        {
            var currentUser = await userManager.GetUserAsync(User);
            var currentCar = carService.GetCarById(Id);
            return View( new CarIndexViewModel(
                    currentCar,
                    currentUser
                ));
        }

        [HttpGet]
        public async Task<IActionResult> Update(string Id, string maker, string model, string color, string additionalInformation)
        {
            var currentUser = await userManager.GetUserAsync(User);
            var currentCar = carService.GetCarById(Id);

            if(currentCar.OwnerId == currentUser.Id)
            {
                carService.UpdateCar(currentCar, maker, model, color, additionalInformation);
            }

            return Redirect(Url.Action("Index", "Car", new { Id = currentCar.LicencePlate }));
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnblockMe_App.Models;
using UnblockMe_App.Services;
using UnblockMe_App.ViewModels;

namespace UnblockMe_App.Controllers
{
    [Authorize]
    public class BlockingController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly UserService userService;
        private readonly CarService carService;

        public BlockingController(UserManager<User> userManager, UserService userService, CarService carService)
        {
            this.userManager = userManager;
            this.userService = userService;
            this.carService = carService;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await userManager.GetUserAsync(User);
            var userCars = userService.GetUserCarsByUserId(currentUser.Id);
            List<Car> blockedCars = new List<Car>();
            List<Car> blockedByCars = new List<Car>();
            foreach (var car in userCars)
            {
                if (car.BlockedLicencePlate != null)
                {
                    blockedCars.Add(carService.GetCarById(car.BlockedLicencePlate));
                }
                if (car.BlockedByLicencePlate != null)
                {
                    blockedByCars.Add(carService.GetCarById(car.BlockedByLicencePlate));
                }
            }
            return View(new BlockingIndexViewModel(
                    userCars,
                    blockedCars,
                    blockedByCars
                ));
        }

        public IActionResult DeleteBlockedBy(string Id, string BlockedById)
        {
            carService.DeleteBlockedByInteraction(Id, BlockedById);
            return Redirect(Url.Action("Index", "Blocking"));
        }

        public IActionResult DeleteBlocked(string Id, string BlockedById)
        {
            carService.DeleteBlockedInteraction(Id, BlockedById);
            return Redirect(Url.Action("Index", "Blocking"));
        }

        public async Task<IActionResult> SelectCarIBlockedIt(string Id, string SelectedCarId)
        {
            if (SelectedCarId != null)
            {
                carService.AddInteraction(SelectedCarId, Id);
                return Redirect(Url.Action("Index", "Home"));
            }

            var carBlocking = carService.GetCarById(Id);
            var currentUser = await userManager.GetUserAsync(User);
            var userCars = userService.GetUserCarsByUserId(currentUser.Id);
            return View(new IBlockedItViewModel(
                carBlocking,
                userCars
                ));
        }

        public async Task<IActionResult> SelectCarItBlockedMe(string Id, string SelectedCarId)
        {
            if(SelectedCarId != null)
            {
                carService.AddInteraction(Id, SelectedCarId);
                return Redirect(Url.Action("Index", "Home"));
            }

            var carBlocking = carService.GetCarById(Id);
            var currentUser = await userManager.GetUserAsync(User);
            var userCars = userService.GetUserCarsByUserId(currentUser.Id);
            return View(new ItBlockedMeViewModel(
                carBlocking,
                userCars
                ));
        }

        public IActionResult Cancel()
        {
            return Redirect(Url.Action("Index", "Home"));
        }
    }
}

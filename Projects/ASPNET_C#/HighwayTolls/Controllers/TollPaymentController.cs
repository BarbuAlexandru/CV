using HighwayTolls.Models;
using HighwayTolls.Services;
using HighwayTolls.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HighwayTolls.Controllers
{
    [Authorize]
    public class TollPaymentController : Controller
    {
        private readonly UserService _userService;
        private readonly TollLocationService _tollLocationService;
        private readonly UserManager<Employee> _userManager;
        private readonly PaymentService _paymentService;


        public TollPaymentController(UserService userService, TollLocationService tollLocationService, UserManager<Employee> userManager, PaymentService paymentService)
        {
            _userService = userService;
            _tollLocationService = tollLocationService;
            _userManager = userManager;
            _paymentService = paymentService;
        }


        public async Task<IActionResult> SelectVehicle(string vehicle)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            var location = _tollLocationService.GetTollLocationByBoothId(currentUser.TollBoothId.Value);
            var price = _paymentService.GetTollPrice(location.Id, vehicle);

            return Redirect(Url.Action("DisplayPrice", "TollPayment", new { locationId = location.Id, vehicle = vehicle, price = price}));
        }

        public IActionResult DisplayPrice(string locationId, string vehicle, int price)
        {
            var location = _tollLocationService.GetTollLocationById(Guid.Parse(locationId));

            return View(new TollDisplayPriceViewModel(
                    location,
                    vehicle,
                    price
                ));
        }

        public async Task<IActionResult> ExecutePayment(string location, int price)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            _paymentService.ExecuteTollPayment(currentUser,Guid.Parse(location), price);
            return Redirect(Url.Action("Index", "Home"));
        }

    }
}

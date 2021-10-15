using HighwayTolls.Models;
using HighwayTolls.Services;
using HighwayTolls.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HighwayTolls.Controllers
{
    [Authorize]
    public class TripPayment : Controller
    {
        private readonly UserService _userService;
        private readonly TollLocationService _tollLocationService;
        private readonly UserManager<Employee> _userManager;
        private readonly PaymentService _paymentService;
        private readonly TripService _tripService;


        public TripPayment(UserService userService, TollLocationService tollLocationService, UserManager<Employee> userManager, PaymentService paymentService, TripService tripService)
        {
            _userService = userService;
            _tollLocationService = tollLocationService;
            _userManager = userManager;
            _paymentService = paymentService;
            _tripService = tripService;
        }

        public IActionResult StartTrip()
        {
            return View();
        }


        public async Task<IActionResult> EndTrip()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var unfinishedTrips = _tripService.GetUnfinishedTrips();
            var location = _tollLocationService.GetTollLocationByBoothId(currentUser.TollBoothId.Value);
            return View(new EndTripViewModel(
                    unfinishedTrips,
                    location
                ));
        }

        public async Task<IActionResult> SelectVehicle(string vehicle)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var location = _tollLocationService.GetTollLocationByBoothId(currentUser.TollBoothId.Value);
            _tripService.CreateTrip(currentUser, location, vehicle);

            return Redirect(Url.Action("Index", "Home"));
        }

        public async Task<IActionResult> DisplayPrice(string TripId)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var trip = _tripService.GetTripById(Guid.Parse(TripId));

            var startCity = _tollLocationService.GetTollLocationById(trip.StartCityId);
            if(currentUser.TollBoothId == null)
            {
                throw new ArgumentNullException("currentUser.TollBoothId");
            }

            var endCity = _tollLocationService.GetTollLocationByBoothId(currentUser.TollBoothId.Value);

            var price = _paymentService.GetTripPrice(startCity.Id, endCity.Id, trip.Vehicle);

            return View(new TripDisplayPriceViewModel(
                    startCity,
                    endCity,
                    trip,
                    price
                ));
        }

        public async Task<IActionResult> ExecutePayment(Guid tripId, int price)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            _paymentService.ExecuteTripPayment(currentUser, tripId, price);
            return Redirect(Url.Action("Index", "Home"));
        }
    }
}

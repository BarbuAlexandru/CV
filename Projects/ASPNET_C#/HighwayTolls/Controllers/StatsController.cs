using HighwayTolls.Models;
using HighwayTolls.Services;
using HighwayTolls.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HighwayTolls.Controllers
{
    [Authorize]
    public class StatsController : Controller
    {
        private readonly UserService _userService;
        private readonly TollLocationService _tollLocationService;
        private readonly PaymentService _paymentService;
        private readonly StatsService _statsService;
        private readonly UserManager<Employee> _userManager;


        public StatsController(UserService userService, TollLocationService tollLocationService, UserManager<Employee> userManager, PaymentService paymentService, StatsService statsService)
        {
            _userService = userService;
            _tollLocationService = tollLocationService;
            _userManager = userManager;
            _paymentService = paymentService;
            _statsService = statsService;
        }


        public IActionResult Index(string locationId)
        {
            TollLocation selectedLocation = null;
            int selectedLocationBoothNr = 0;
            List<MonthInfo> monthInfo = null;
            if (locationId != null)
            {
                selectedLocation = _tollLocationService.GetTollLocationById_Complete(Guid.Parse(locationId));
                selectedLocationBoothNr = _tollLocationService.GetAllTollBoothsOfLocation(selectedLocation.Id).Count();

                var tollPayments = _paymentService.GetAllTollPaymentsInLocation(selectedLocation.Id);
                var tripPayments = _paymentService.GetAllTripPaymentsInLocation(selectedLocation.Id);

                monthInfo = _statsService.GetAllMonthInfoOfLocation(monthInfo, tollPayments, tripPayments);
            }

            return View(new StatsViewModel(
                    _tollLocationService.GetAllTollLocations_Complete(),
                    selectedLocation,
                    selectedLocationBoothNr,
                    monthInfo
                ));
        }
    }
}

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
    public class HomeController : Controller
    {
        private readonly UserService _userService;
        private readonly TollLocationService _tollLocationService;
        private readonly UserManager<Employee> _userManager;


        public HomeController(UserService userService, TollLocationService tollLocationService, UserManager<Employee> userManager)
        {
            _userService = userService;
            _tollLocationService = tollLocationService;
            _userManager = userManager;
        }


        public async Task<IActionResult> Index(string LocationId, string BoothId)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if(LocationId!=null && BoothId != null)
            {
                _userService.UpdateLocation(currentUser, LocationId, BoothId);
            }

            if (!_userService.CheckIfEmployeeHasBooth(currentUser))
            {
                return Redirect(Url.Action("SelectBooth", "Home"));
            }

            return View();
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public JsonResult GetBooths(string location)
        {
            if (location != null)
            {
                var booths = _tollLocationService.GetBoothsOfLocations(Guid.Parse(location));
                List<String> boothsId = new List<String>();
                foreach (var b in booths)
                {
                    boothsId.Add(b.Id.ToString());
                }
                return Json(boothsId);
            }
            return Json(null);
        }

        public IActionResult SelectBooth()
        {
            var Locations = _tollLocationService.GetAllTollLocations();
            return View(new SelectBoothViewModel(
                    Locations
                ));
        }

    }
}

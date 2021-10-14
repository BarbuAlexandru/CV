using AjaxExample.Models;
using AjaxExample.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;

namespace AjaxExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private List<string> Locations = new List<string>();
        private List<string> BoothsCraiova = new List<string>();
        private List<string> BoothsTimisoara = new List<string>();
        private List<string> BoothsBucuresti = new List<string>();

        public HomeController(ILogger<HomeController> logger)
        {
            Locations.Add("Craiova");
            Locations.Add("Bucuresti");
            Locations.Add("Timisoara");

            BoothsCraiova.Add("Craiova Booth 1");
            BoothsCraiova.Add("Craiova Booth 2");
            BoothsCraiova.Add("Craiova Booth 3");

            BoothsBucuresti.Add("Bucuresti Booth 1");
            BoothsBucuresti.Add("Bucuresti Booth 2");

            BoothsTimisoara.Add("Timisoara Booth 1");
        }

        [HttpGet]
        public JsonResult GetBooths(string location)
        {
            var booths = BoothsCraiova;
            if (location == "Bucuresti")
            {
                booths = BoothsBucuresti;
            }
            if (location == "Timisoara")
            {
                booths = BoothsTimisoara;
            }
            return Json(booths);
        }

        public IActionResult Index()
        {
            return View(new IndexViewModel(
                    Locations
                ));
        }

        public IActionResult Home(string LocationId, string BoothId)
        {
            return View(new HomeViewModel(
                    LocationId,
                    BoothId
                ));
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
    }
}

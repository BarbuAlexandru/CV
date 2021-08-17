using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UnblockMe_App.Models;

namespace UnblockMe_App.Controllers
{
    public class WelcomeController : Controller
    {

        public WelcomeController()
        {
        }

        public IActionResult Index()
        {
            if(User?.Identity.IsAuthenticated == true)
            {
                return Redirect(Url.Action("Index", "Home"));
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

    }
}

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
    public class HomeController : Controller
    {
        private readonly UserManager<User> userManager;

        //Services
        private readonly HomeService homeService;

        public HomeController(HomeService homeService, UserManager<User> userManager)
        {
            this.homeService = homeService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var currentUser = await userManager.GetUserAsync(User);
            return View(new HomeIndexViewModel(
                    searchString,
                    homeService.SearchCarLicence(searchString),
                    currentUser
                ));
        }        
    }
}

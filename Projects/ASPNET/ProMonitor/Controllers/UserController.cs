using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProMonitor.Models;
using ProMonitor.Services;
using ProMonitor.ViewModels;
using System.Threading.Tasks;

namespace ProMonitor.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly UserService userService;

        public UserController(UserManager<User> userManager, UserService userService)
        {
            this.userManager = userManager;
            this.userService = userService;
        }

        public async Task<IActionResult> Index(string Id)
        {
            var currentUser = await userManager.GetUserAsync(User);
            var actualUser = userService.GetUserById(Id);

            return View(new UserIndexViewModel(
                    currentUser,
                    actualUser
                ));
        }
    }
}

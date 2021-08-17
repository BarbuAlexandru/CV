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
    public class HomeController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly ProjectService projectService;
        private readonly UserTaskConService userTaskConService;

        public HomeController(UserManager<User> userManager, ProjectService projectService, UserTaskConService userTaskConService)
        {
            this.userManager = userManager;
            this.projectService = projectService;
            this.userTaskConService = userTaskConService;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await userManager.GetUserAsync(User);

            return View(new HomeIndexViewModel(
                    currentUser,
                    projectService.GetAllUsersProjects(currentUser),
                    userTaskConService.GetAllUserTaskConByUserId(currentUser.Id)
                ));
        }
    }
}

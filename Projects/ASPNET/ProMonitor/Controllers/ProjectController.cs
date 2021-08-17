using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProMonitor.Models;
using ProMonitor.Services;
using ProMonitor.ViewModels;
using System;
using System.Threading.Tasks;

namespace ProMonitor.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly UserService userService;
        private readonly ProjectService projectService;
        private readonly UserProjectConService userProjectConService;
        private readonly TaskService taskService;

        public ProjectController(UserManager<User> userManager, UserService userService, ProjectService projectService,
                                UserProjectConService userProjectConService, TaskService taskService)
        {
            this.userManager = userManager;
            this.userService = userService;
            this.projectService = projectService;
            this.userProjectConService = userProjectConService;
            this.taskService = taskService;
        }

        public async Task<IActionResult> List(string Id)
        {
            var currentUser = await userManager.GetUserAsync(User);
            var actualUser = userService.GetUserById(Id);

            return View( new ProjectListViewModel(
                    currentUser,
                    userService.GetUserById(Id),
                    projectService.GetAllUsersProjects(actualUser)
                ));
        }

        public async Task<IActionResult> Create(string title, string description, int? budget, DateTime? startDate, DateTime? estimatedEndDate)
        {
            var currentUser = await userManager.GetUserAsync(User);
            if (title != null)
            {
                projectService.CreateProject(currentUser, title, description, budget, startDate, estimatedEndDate);
                return Redirect(Url.Action("Index", "Home"));
            }
            return View();
        }

        public async Task<IActionResult> Delete(string Id)
        {
            var currentUser = await userManager.GetUserAsync(User);
            projectService.DeleteProject(currentUser, Id);
            return Redirect(Url.Action("Index", "Home"));
        }

        public async Task<IActionResult> Index(string Id)
        {
            var currentUser = await userManager.GetUserAsync(User);
            return View(new ProjectIndexViewModel(
                    currentUser,
                    projectService.GetProjectById(Id)
                ));
        }

        public async Task<IActionResult> EndProject(string Id)
        {
            var currentUser = await userManager.GetUserAsync(User);
            projectService.ChangeProjectStatus(currentUser, Id);
            return Redirect(Url.Action("Index", "Project", new { Id = Id }));
        }

        public async Task<IActionResult> RestartProject(string Id)
        {
            var currentUser = await userManager.GetUserAsync(User);
            projectService.ChangeProjectStatus(currentUser, Id);
            return Redirect(Url.Action("Index", "Project", new { Id = Id }));
        }

        public async Task<IActionResult> Members(string Id, string searchString)
        {
            var currentUser = await userManager.GetUserAsync(User);
            return View(new ProjectMembersViewModel(
                    currentUser,
                    projectService.GetProjectById(Id),
                    searchString,
                    userService.SearchUsersByEmail(searchString)
                ));
        }

        public IActionResult AddUser(string Id, string userId)
        {
            projectService.AddUserProjectCon(Id, userService.GetUserById(userId));
            return Redirect(Url.Action("Members", "Project", new { Id = Id }));
        }

        public IActionResult RemoveUser(string Id, string userId)
        {
            projectService.RemoveUserProjectCon(Id, userService.GetUserById(userId));
            return Redirect(Url.Action("Members", "Project", new { Id = Id }));
        }

        public async Task<IActionResult> ModifyCon(string Id, string projectId, string role, string description, string status)
        {
            var currentUser = await userManager.GetUserAsync(User);
            if (role != null)
            {
                userProjectConService.UpdateConnection(Id, role, description, status);
                return Redirect(Url.Action("Members", "Project", new { Id = projectId }));
            }
            return View(new ProjectModifyConViewModel(
                currentUser,
                userProjectConService.GetUserProjectConById(Id),
                projectService.GetProjectById(projectId)
                ));
        }

        public async Task<IActionResult> Edit(string Id, string title, string description, int budget, DateTime startDate, DateTime estimatedEndDate)
        {
            var currentUser = await userManager.GetUserAsync(User);
            if (title != null)
            {
                projectService.EditProjectById(currentUser, Id, title, description, budget, startDate, estimatedEndDate);
                return Redirect(Url.Action("Index", "Project", new { Id = Id }));
            }
            return View(new ProjectEditViewModel(
                    currentUser,
                    projectService.GetProjectById(Id)
                ));
        }

        public async Task<IActionResult> Tasks(string Id)
        {
            var currentUser = await userManager.GetUserAsync(User);
            var project = projectService.GetProjectById(Id);
            return View(new ProjectTasksViewModel(
                    currentUser,
                    project,
                    taskService.GetAllProjectTasks(project)
                ));
        }
    }
}

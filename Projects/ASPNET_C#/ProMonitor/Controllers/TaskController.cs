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
    public class TaskController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly UserService userService;
        private readonly ProjectService projectService;
        private readonly TaskService taskService;
        private readonly UserTaskConService userTaskConService;

        public TaskController(UserManager<User> userManager, UserService userService, ProjectService projectService,
                            TaskService taskService, UserTaskConService userTaskConService)
        {
            this.userManager = userManager;
            this.userService = userService;
            this.projectService = projectService;
            this.taskService = taskService;
            this.userTaskConService = userTaskConService;
        }

        public async Task<IActionResult> Create(string Id, string title, string description, int cost, DateTime startDate, DateTime estimatedEndDate)
        {
            var currentUser = await userManager.GetUserAsync(User);
            var project = projectService.GetProjectById(Id);
            if (title != null)
            {
                taskService.CreateTask(currentUser, project, title, description, cost, startDate, estimatedEndDate);
                return Redirect(Url.Action("Tasks", "Project", new { Id = Id }));
            }
            return View(new TaskCreateViewModel(
                    currentUser,
                    project
                ));
        }

        public async Task<IActionResult> Delete(string Id, string taskId)
        {
            var currentUser = await userManager.GetUserAsync(User);
            var project = projectService.GetProjectById(Id);
            if(currentUser.Id == project.OwnerId)
            {
                taskService.DeleteTask(taskId);
            }
            return Redirect(Url.Action("Tasks", "Project", new { Id = Id }));
        }

        public async Task<IActionResult> Edit(string Id, string taskId, string title, string description, int cost, DateTime startDate, DateTime estimatedEndDate)
        {
            var currentUser = await userManager.GetUserAsync(User);
            var project = projectService.GetProjectById(Id);
            if(currentUser.Id == project.OwnerId)
            {
                if (title != null)
                {
                    taskService.EditTask(taskId, title, description, cost, startDate, estimatedEndDate);
                    return Redirect(Url.Action("Tasks", "Project", new { Id = Id }));
                }
                return View(new TaskEditViewModel(
                        taskService.GetTaskById(taskId),
                        project
                    ));
            }
            return Redirect(Url.Action("Tasks", "Project", new { Id = Id }));
        }

        public IActionResult FinishTask(string Id, string taskId)
        {
            taskService.FinishTask(taskId);
            return Redirect(Url.Action("Tasks", "Project", new { Id = Id }));
        }

        public IActionResult RestartTask(string Id, string taskId)
        {
            taskService.RestartTask(taskId);
            return Redirect(Url.Action("Tasks", "Project", new { Id = Id }));
        }

        public async Task<IActionResult> Index(string Id, string taskId)
        {
            var currentUser = await userManager.GetUserAsync(User);
            var project = projectService.GetProjectById(Id);
            var task = taskService.GetTaskById(taskId);
            return View(new TaskIndexViewModel(
                    currentUser,
                    task,
                    project
                ));
        }

        public async Task<IActionResult> Members(string Id, string taskId)
        {
            var currentUser = await userManager.GetUserAsync(User);
            var project = projectService.GetProjectById(Id);
            return View(new TaskMembersViewModel(
                    currentUser,
                    project,
                    taskService.GetTaskById(taskId),
                    taskService.GetUserTaskConOfTaskById(taskId)
                ));
        }

        public IActionResult AddUserToTask(string Id, string taskId, string userId)
        {
            userTaskConService.AddUserTaskCon(taskService.GetTaskById(taskId), userService.GetUserById(userId));
            return Redirect(Url.Action("Members", "Task", new { Id = Id , taskId = taskId }));
        }

        public IActionResult RemoveUserToTask(string Id, string taskId, string userId)
        {
            userTaskConService.RemoveUserTaskCon(taskService.GetTaskById(taskId), userService.GetUserById(userId));
            return Redirect(Url.Action("Members", "Task", new { Id = Id, taskId = taskId }));
        }

        public async Task<IActionResult> List(string Id)
        {
            var currentUser = await userManager.GetUserAsync(User);
            return View( new TaskListViewModel(
                    currentUser,
                    userTaskConService.GetAllUserTaskConByUserId(currentUser.Id)
                ));
        }
    }
}

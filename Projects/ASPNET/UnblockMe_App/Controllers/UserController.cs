using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using UnblockMe_App.Models;
using UnblockMe_App.Services;
using UnblockMe_App.ViewModels;

namespace UnblockMe_App.Controllers
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

        [HttpGet]
        public async Task<IActionResult> Index(string Id, string newStatus, string rating, string comment)
        {
            var currentUser = await userManager.GetUserAsync(User);
            var profileUser = userService.GetUserById(Id);

            if (rating != null)
            {
                if (rating.Contains("Delete"))
                {
                    userService.DeleteRatingByUserRatingId(profileUser, currentUser);
                }
                else
                {
                    userService.AddUpdateRatingToUser(profileUser, currentUser, Int32.Parse(rating), comment);
                }
            }

            if (newStatus != null && currentUser.Id == Id)
            {
                userService.UpdateUserStatus(Id, newStatus);
            }
            var userRatingCurrent = userService.GetUserRatingByIds(Id, currentUser.Id);
            return View(new UserIndexViewModel(
                    currentUser,
                    profileUser,
                    userService.GetUserCarsByUserId(Id),
                    userRatingCurrent
                ));
        }

        public async Task<IActionResult> DeleteAdditionalInformation()
        {
            var currentUser = await userManager.GetUserAsync(User);
            userService.DeleteAdditionalInfoOfUser(currentUser);
            return Redirect(Url.Action("Index", "User", new { Id = currentUser.Id }));
        }
    }
}

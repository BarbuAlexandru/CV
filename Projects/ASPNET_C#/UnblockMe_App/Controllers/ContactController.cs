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
    public class ContactController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly UserService userService;
        private readonly ContactService contactService;

        public ContactController(UserManager<User> userManager, UserService userService, ContactService contactService)
        {
            this.userManager = userManager;
            this.userService = userService;
            this.contactService = contactService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string Id)
        {
            var currentUser = await userManager.GetUserAsync(User);
            if(currentUser.Id == Id)
            {
                return Redirect(Url.Action("Index", "Home"));
            }
            return View( new ContactIndexViewModel(
                    currentUser,
                    userService.GetUserById(Id)
                ));
        }

        [HttpGet]
        public  IActionResult Send(string Id, string message, string sendMethod)
        {
            message += "\n\nSend to you by the application UnblockMe." +
                       "\nIf you dont use this application, please ignore this message.";
            var user = userService.GetUserById(Id);
            switch (sendMethod)
            {
                case "SMS":
                    contactService.SendSMS(user.PhoneNumber, message);
                    break;
                case "Email":
                    contactService.SendEmail(user.Email, message);
                    break;
                default:
                    break;
            }
            return Redirect(Url.Action("Index", "User", new { Id = Id }));
        }
    }
}

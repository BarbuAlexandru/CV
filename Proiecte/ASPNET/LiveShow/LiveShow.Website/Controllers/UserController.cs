using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiveShow.Website.Services;
using LiveShow.Website.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LiveShow.Website.Controllers
{
    public class UserController : Controller
    {
        private readonly IApiService apiService;
        public UserController(IApiService apiService)
        {
            this.apiService = apiService;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterUser([FromForm]RegisterUserViewModel model)
        {
            apiService.RegisterUser(model.FirstName, model.LastName, model.UserName, model.Password, model.UserType);
            return Redirect(Url.Action("RegisterValidation", "User"));
        }

        public IActionResult RegisterValidation()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
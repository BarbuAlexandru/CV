using LiveShow.Services;
using LiveShow.Services.Models.Show;
using LiveShow.Services.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace LiveShow.Api.Controllers
{
    public class UserController : LiveShowApiControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public IActionResult Register(UserDto user)
        {
            userService.RegisterNewUser(user);
            return Ok();
        }
    }
}

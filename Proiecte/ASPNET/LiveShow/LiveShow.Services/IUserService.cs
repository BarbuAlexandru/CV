using LiveShow.Services.Models.Show;
using LiveShow.Services.Models.User;
using System;

namespace LiveShow.Services
{
    public interface IUserService
    {
        void RegisterNewUser(UserDto user);
    }
}
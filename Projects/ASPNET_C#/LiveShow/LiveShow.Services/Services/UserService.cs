using LiveShow.Dal;
using LiveShow.Dal.Models;
using LiveShow.Services.Models.Show;
using LiveShow.Services.Models.User;
using System;

namespace LiveShow.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void RegisterNewUser(UserDto user)
        {
            UserType userType;
            switch (user.UserType)
            {
                case "Regular":
                    userType = UserType.Regular;
                    break;
                case "Artist":
                    userType = UserType.Artist;
                    break;
                default:
                    throw new NotSupportedException();
            }

            unitOfWork.UserRepository.AddAsync(new User { 
                Id = Guid.NewGuid(),
                UserName = user.Username,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Type = userType
            });
        }
    }
}

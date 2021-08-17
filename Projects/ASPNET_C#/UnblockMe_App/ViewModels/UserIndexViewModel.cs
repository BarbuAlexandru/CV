using System.Collections.Generic;
using UnblockMe_App.Models;

namespace UnblockMe_App.ViewModels
{
    public class UserIndexViewModel
    {
        public User CurrentUser { get; set; }
        public User UserProfile { get; set; }
        public List<Car> UserCars { get; set; }
        public UserRating CurrentUserRating { get; set; }

        public UserIndexViewModel(User currentUser, User userProfile, List<Car> userCars, UserRating currentUserRating)
        {
            this.CurrentUser = currentUser;
            this.UserProfile = userProfile;
            this.UserCars = userCars;
            this.CurrentUserRating = currentUserRating;
        }
    }
}

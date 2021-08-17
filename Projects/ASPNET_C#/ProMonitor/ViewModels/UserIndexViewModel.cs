using ProMonitor.Models;

namespace ProMonitor.ViewModels
{
    public class UserIndexViewModel
    {
        public User CurrentUser { get; set; }
        public User ActualUser { get; set; }

        public UserIndexViewModel(User currentUser, User actualUser)
        {
            this.CurrentUser = currentUser;
            this.ActualUser = actualUser;
        }
    }
}

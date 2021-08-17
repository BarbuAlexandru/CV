using UnblockMe_App.Models;

namespace UnblockMe_App.ViewModels
{
    public class ContactIndexViewModel
    {
        public User CurrentUser { get; set; }
        public User ContactUser { get; set; }

        public ContactIndexViewModel(User currentUser, User contactUser)
        {
            this.CurrentUser = currentUser;
            this.ContactUser = contactUser;
        }

    }
}

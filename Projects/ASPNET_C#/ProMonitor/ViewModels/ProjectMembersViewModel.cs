using ProMonitor.Models;
using System.Collections.Generic;

namespace ProMonitor.ViewModels
{
    public class ProjectMembersViewModel
    {
        public User CurrentUser { get; set; }
        public Project Project { get; set; }
        public string SearchedText { get; set; }
        public List<User> SearchedUsers { get; set; }

        public ProjectMembersViewModel(User currentUser, Project project, string searchedText, List<User> searchedUsers)
        {
            this.CurrentUser = currentUser;
            this.Project = project;
            this.SearchedText = searchedText;
            this.SearchedUsers = searchedUsers;
        }
    }
}

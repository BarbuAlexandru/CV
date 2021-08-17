using ProMonitor.Models;
using System.Collections.Generic;

namespace ProMonitor.ViewModels
{
    public class HomeIndexViewModel
    {
        public User CurrentUser { get; set; }
        public List<UserProjectCon> ProjectsConnections { get; set; }
        public List<UserTaskCon> UserTaskCon { get; set; }

        public HomeIndexViewModel(User currentUser, List<UserProjectCon> projectsConnections, List<UserTaskCon> userTaskCon)
        {
            this.CurrentUser = currentUser;
            this.ProjectsConnections = projectsConnections;
            this.UserTaskCon = userTaskCon;
        }
    }
}

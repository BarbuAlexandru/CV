using ProMonitor.Models;
using System.Collections.Generic;

namespace ProMonitor.ViewModels
{
    public class ProjectListViewModel
    {

        public User CurrentUser { get; set; }
        public User ActualUser { get; set; }
        public List<UserProjectCon> ProjectsConnections { get; set; }

        public ProjectListViewModel(User currentUser, User actualUser, List<UserProjectCon> projectsConnections)
        {
            this.CurrentUser = currentUser;
            this.ActualUser = actualUser;
            this.ProjectsConnections = projectsConnections;
        }
    }
}

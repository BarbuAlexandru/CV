using ProMonitor.Models;

namespace ProMonitor.ViewModels
{
    public class ProjectIndexViewModel
    {
        public User CurrentUser { get; set; }
        public Project Project { get; set; }

        public ProjectIndexViewModel(User currentUser, Project project)
        {
            this.CurrentUser = currentUser;
            this.Project = project;
        }
    }
}

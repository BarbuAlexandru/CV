using ProMonitor.Models;

namespace ProMonitor.ViewModels
{
    public class ProjectEditViewModel
    {
        public User CurrentUser { get; set; }
        public Project Project { get; set; }

        public ProjectEditViewModel(User currentUser, Project project)
        {
            this.CurrentUser = currentUser;
            this.Project = project;
        }
    }
}

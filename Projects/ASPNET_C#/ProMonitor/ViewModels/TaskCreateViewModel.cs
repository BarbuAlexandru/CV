using ProMonitor.Models;

namespace ProMonitor.ViewModels
{
    public class TaskCreateViewModel
    {
        public User CurrentUser { get; set; }
        public Project Project { get; set; }

        public TaskCreateViewModel(User currentUser, Project project)
        {
            this.CurrentUser = currentUser;
            this.Project = project;
        }
    }
}

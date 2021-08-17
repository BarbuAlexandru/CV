using ProMonitor.Models;

namespace ProMonitor.ViewModels
{
    public class TaskIndexViewModel
    {
        public User CurrentUser { get; set; }
        public Models.Task Task { get; set; }
        public Project Project { get; set; }
        
        public TaskIndexViewModel(User currentUser, Models.Task task, Project project)
        {
            this.CurrentUser = currentUser;
            this.Task = task;
            this.Project = project;
        }
    }
}

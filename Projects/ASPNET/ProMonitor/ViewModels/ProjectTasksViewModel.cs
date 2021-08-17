using ProMonitor.Models;
using System.Collections.Generic;

namespace ProMonitor.ViewModels
{
    public class ProjectTasksViewModel
    {
        public User CurrentUser { get; set; }
        public Project Project { get; set; }
        public List<Models.Task> Tasks { get; set; }

        public ProjectTasksViewModel(User currentUser, Project project, List<Models.Task> tasks)
        {
            this.CurrentUser = currentUser;
            this.Project = project;
            this.Tasks = tasks;
        }
    }
}

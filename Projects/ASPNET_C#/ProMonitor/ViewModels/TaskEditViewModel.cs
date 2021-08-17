using ProMonitor.Models;

namespace ProMonitor.ViewModels
{
    public class TaskEditViewModel
    {
        public Models.Task Task { get; set; }
        public Project Project { get; set; }
        
        public TaskEditViewModel(Models.Task task, Project project)
        {
            this.Task = task;
            this.Project = project;
        }
    }
}

using ProMonitor.Models;
using System.Collections.Generic;

namespace ProMonitor.ViewModels
{
    public class TaskMembersViewModel
    {
        public User CurrentUser { get; set; }
        public Project Project { get; set; }
        public Models.Task Task { get; set; }
        public List<UserTaskCon> UserTaskCon { get; set; }

        public TaskMembersViewModel(User currentUser, Project project, Models.Task task, List<UserTaskCon> userTaskCon)
        {
            this.CurrentUser = currentUser;
            this.Project = project;
            this.Task = task;
            this.UserTaskCon = userTaskCon;
        }
    }
}

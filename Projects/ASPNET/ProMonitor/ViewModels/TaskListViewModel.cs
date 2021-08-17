using ProMonitor.Models;
using System.Collections.Generic;

namespace ProMonitor.ViewModels
{
    public class TaskListViewModel
    {
        public User CurrentUser { get; set; }
        public List<UserTaskCon> UserTaskCon { get; set; }

        public TaskListViewModel(User currentUser, List<UserTaskCon> userTaskCon)
        {
            this.CurrentUser = currentUser;
            this.UserTaskCon = userTaskCon;
        }
    }
}

using ProMonitor.Models;

namespace ProMonitor.ViewModels
{
    public class ProjectModifyConViewModel
    {
        public User CurrentUser { get; set; }
        public UserProjectCon UserProjCon { get; set; }
        public Project Project { get; set; }

        public ProjectModifyConViewModel(User currentUser, UserProjectCon userProjCon, Project project)
        {
            this.CurrentUser = currentUser;
            this.UserProjCon = userProjCon;
            this.Project = project;
        }
    }
}

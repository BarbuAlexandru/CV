using Microsoft.EntityFrameworkCore;
using ProMonitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProMonitor.Services
{
    public class ProjectService
    {
        private readonly ProMonitorContext dbContext;

        public ProjectService(ProMonitorContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //Services
        public Project GetProjectById(string id)
        {
            return dbContext.Project.Include(proj => proj.UserProjectCon).ThenInclude(con=> con.User).Include(proj=>proj.Task)
                                    .ToList().Find(proj=> proj.Id == Guid.Parse(id));
        }

        public void CreateProject(User owner, string title, string description, int? budget, DateTime? startDate, DateTime? estimatedEndDate)
        {
            var project = new Project()
            {
                Id = Guid.NewGuid(),
                Title = title,
                Description = description,
                Budget = budget,
                StartDate = startDate,
                EstimatedEndDate = estimatedEndDate,
                EndDate = null,
                Status = "In progress",
                OwnerId = owner.Id,
                Owner = owner
            };

            var userProjectCon = new UserProjectCon()
            {
                Id = Guid.NewGuid(),
                Role = "Owner",
                Description = "Owner",
                Status = "Active",
                Project = project,
                ProjectId = project.Id,
                User = owner,
                UserId = owner.Id
            };

            project.UserProjectCon.Add(userProjectCon);
            owner.Project.Add(project);
            owner.UserProjectCon.Add(userProjectCon);

            dbContext.User.Update(owner);
            dbContext.Project.Add(project);
            dbContext.UserProjectCon.Add(userProjectCon);

            dbContext.SaveChanges();
        }

        public List<UserProjectCon> GetAllUsersProjects(User user)
        {
            return dbContext.UserProjectCon.Include(con => con.Project).ThenInclude(proj=>proj.Owner)
                                            .Include(con=> con.Project).ThenInclude(proj=>proj.Task).Where(con => con.UserId == user.Id).ToList();
        }

        public void DeleteProject(User user, string Id)
        {
            var project = GetProjectById(Id);
            if(project.OwnerId == user.Id)
            {
                user.Project.Remove(project);
                var userProjectCon = dbContext.UserProjectCon.Include(con => con.User).Where(con => con.ProjectId == project.Id).ToList();

                foreach (var con in userProjectCon)
                {
                    con.User.UserProjectCon.Remove(con);
                    dbContext.UserProjectCon.Remove(con);
                }

                var tasks = dbContext.Task.Include(task=>task.UserTaskCon).Where(task => task.ProjectId == project.Id).ToList();
                List<UserTaskCon> userTaskCon = new List<UserTaskCon>();
                foreach (var task in tasks)
                {
                    foreach(var con in task.UserTaskCon)
                    {
                        userTaskCon.Add(con);
                    }
                }
                
                foreach(var con in userTaskCon)
                {
                    con.User.UserTaskCon.Remove(con);
                    dbContext.User.Update(con.User);
                    var task = tasks.FirstOrDefault(task => task.Id == con.TaskId);
                    task.UserTaskCon.Remove(con);
                    dbContext.UserTaskCon.Remove(con);
                }

                foreach(var task in tasks)
                {
                    dbContext.Task.Remove(task);
                }

                dbContext.User.Update(user);
                dbContext.Project.Remove(project);

                dbContext.SaveChanges();
            }
            return;
        }

        public void ChangeProjectStatus(User user, string id)
        {
            var project = GetProjectById(id);
            if(project.OwnerId != user.Id)
            {
                return;
            }
            if(project.Status=="In progress")
            {
                project.Status = "Finished";
                project.EndDate = DateTime.Now;
            }
            else
            {
                project.Status = "In progress";
                project.EndDate = null;
            }
            dbContext.Project.Update(project);
            dbContext.SaveChanges();
        }

        public void AddUserProjectCon(string projectId, User user)
        {
            var project = GetProjectById(projectId);

            if(dbContext.UserProjectCon.FirstOrDefault(con => con.ProjectId == project.Id && con.UserId == user.Id)!= null)
            {
                return;
            }

            var userProjectCon = new UserProjectCon()
            {
                Id = Guid.NewGuid(),
                Role = "Member",
                Description = "Member",
                Status = "Active",
                Project = project,
                ProjectId = project.Id,
                User = user,
                UserId = user.Id
            };

            dbContext.UserProjectCon.Add(userProjectCon);

            project.UserProjectCon.Add(userProjectCon);
            user.UserProjectCon.Add(userProjectCon);
            dbContext.Project.Update(project);
            dbContext.User.Update(user);
            dbContext.SaveChanges();
        }

        public void RemoveUserProjectCon(string id, User user)
        {
            var project = GetProjectById(id);
            var userProjectCon = dbContext.UserProjectCon.FirstOrDefault(con => con.ProjectId == project.Id && con.UserId == user.Id);

            if(project.Owner.Id == user.Id)
            {
                return;
            }

            user.UserProjectCon.Remove(userProjectCon);
            project.UserProjectCon.Remove(userProjectCon);
            dbContext.User.Update(user);
            dbContext.Project.Update(project);
            dbContext.UserProjectCon.Remove(userProjectCon);
            dbContext.SaveChanges();
        }

        public void EditProjectById(User user, string id, string title, string description, int budget, DateTime startDate, DateTime estimatedEndDate)
        {
            var project = GetProjectById(id);
            if (project.OwnerId != user.Id)
            {
                return;
            }
            project.Title = title;
            project.Description = description;
            project.Budget = budget;
            project.StartDate = startDate;
            project.EstimatedEndDate = estimatedEndDate;

            dbContext.Project.Update(project);
            dbContext.SaveChanges();
        }
    }
}

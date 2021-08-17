using Microsoft.EntityFrameworkCore;
using ProMonitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProMonitor.Services
{
    public class TaskService
    {
        private readonly ProMonitorContext dbContext;

        public TaskService(ProMonitorContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //Services
        public void CreateTask(User currentUser, Project project, string title, string description, int cost, DateTime startDate, DateTime estimatedEndDate)
        {
            if(currentUser.Id != project.OwnerId)
            {
                return;
            }

            var task = new Models.Task()
            {
                Id = Guid.NewGuid(),
                Title = title,
                Description = description,
                Cost = cost,
                StartDate = startDate,
                EstimatedEndDate = estimatedEndDate,
                EndDate = null,
                Status = "Active",
                Project = project,
                ProjectId = project.Id,
                UserTaskCon = null
            };
            project.Task.Add(task);
            dbContext.Task.Add(task);
            dbContext.Project.Update(project);
            dbContext.SaveChanges();
        }

        public List<Models.Task> GetAllProjectTasks(Project project)
        {
            return dbContext.Task.Include(task=>task.UserTaskCon).Where(task=> task.ProjectId == project.Id).ToList();
        }

        public void DeleteTask(string taskId)
        {
            var task = GetTaskById(taskId);
            var project = dbContext.Project.FirstOrDefault(proj => proj.Id == task.ProjectId);
            var userTaskCon = dbContext.UserTaskCon.Include(con=>con.User).Where(con => con.TaskId == task.Id).ToList();

            project.Task.Remove(task);
            dbContext.Project.Update(project);

            foreach (var con in userTaskCon)
            {
                con.User.UserTaskCon.Remove(con);
                dbContext.User.Update(con.User);
                dbContext.UserTaskCon.Remove(con);
            }
            dbContext.Task.Remove(task);
            dbContext.SaveChanges();
        }

        public void EditTask(string taskId, string title, string description, int cost, DateTime startDate, DateTime estimatedEndDate)
        {
            var task = GetTaskById(taskId);
            task.Title = title;
            task.Description = description;
            task.Cost = cost;
            task.StartDate = startDate;
            task.EstimatedEndDate = estimatedEndDate;

            dbContext.Task.Update(task);
            dbContext.SaveChanges();
        }

        public Models.Task GetTaskById(string taskId)
        {
            return dbContext.Task.Include(task=>task.UserTaskCon).FirstOrDefault(task => task.Id == Guid.Parse(taskId));
        }

        public void FinishTask(string taskId)
        {
            var task = GetTaskById(taskId);
            task.Status = "Finished";
            task.EndDate = DateTime.Now;
            dbContext.Task.Update(task);
            dbContext.SaveChanges();
        }

        internal void RestartTask(string taskId)
        {
            var task = GetTaskById(taskId);
            task.Status = "Active";
            task.EndDate = null;
            dbContext.Task.Update(task);
            dbContext.SaveChanges();
        }

        public List<UserTaskCon> GetUserTaskConOfTaskById(string taskId)
        {
            return dbContext.UserTaskCon.Include(con=>con.User).Include(con=>con.Task).Where(con => con.TaskId == Guid.Parse(taskId)).ToList();
        }
    }
}

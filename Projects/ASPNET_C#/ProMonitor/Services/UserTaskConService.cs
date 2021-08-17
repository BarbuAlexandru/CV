using Microsoft.EntityFrameworkCore;
using ProMonitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProMonitor.Services
{
    public class UserTaskConService
    {
        private readonly ProMonitorContext dbContext;

        public UserTaskConService(ProMonitorContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //Services
        public void AddUserTaskCon(Models.Task task, User user)
        {
            if(dbContext.UserTaskCon.FirstOrDefault(con => (con.TaskId == task.Id && con.UserId == user.Id))!=null)
            {
                return;
            }
            var userTaskCon = new UserTaskCon()
            {
                Id = Guid.NewGuid(),
                Status = "Active",
                Task = task,
                TaskId = task.Id,
                User = user,
                UserId = user.Id
            };

            user.UserTaskCon.Add(userTaskCon);
            task.UserTaskCon.Add(userTaskCon);
            dbContext.UserTaskCon.Add(userTaskCon);
            dbContext.User.Update(user);
            dbContext.Task.Update(task);
            dbContext.SaveChanges();
        }

        public void RemoveUserTaskCon(Models.Task task, User user)
        {
            var userTaskCon = dbContext.UserTaskCon.FirstOrDefault(con => (con.TaskId == task.Id && con.UserId == user.Id));
            if(userTaskCon == null)
            {
                return;
            }

            user.UserTaskCon.Remove(userTaskCon);
            task.UserTaskCon.Remove(userTaskCon);
            dbContext.UserTaskCon.Remove(userTaskCon);
            dbContext.User.Update(user);
            dbContext.Task.Update(task);
            dbContext.SaveChanges();
        }

        public List<UserTaskCon> GetAllUserTaskConByUserId(string id)
        {
            return dbContext.UserTaskCon.Include(con=> con.Task).ThenInclude(task=>task.Project).Where(con=> con.UserId == id).ToList();
        }
    }
}

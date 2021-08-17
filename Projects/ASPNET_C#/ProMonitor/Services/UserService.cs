using Microsoft.EntityFrameworkCore;
using ProMonitor.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProMonitor.Services
{
    public class UserService
    {
        private readonly ProMonitorContext dbContext;

        public UserService(ProMonitorContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //Services
        public User GetUserById(string id)
        {
            return dbContext.User.Include(user => user.UserProjectCon).ThenInclude(con=>con.Project)
                                .Include(user=>user.UserTaskCon).ThenInclude(con=>con.Task).FirstOrDefault(user => user.Id == id);
        }

        public List<User> SearchUsersByEmail(string email)
        {
            if(email == null)
            {
                return null;
            }
            return dbContext.User.Where(user => user.Email.ToUpper().Contains(email.ToUpper())).Include(user=> user.Project).ToList();
        }
    }
}

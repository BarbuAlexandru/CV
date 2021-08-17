using ProMonitor.Models;
using System;
using System.Linq;

namespace ProMonitor.Services
{
    public class UserProjectConService
    {
        private readonly ProMonitorContext dbContext;

        public UserProjectConService(ProMonitorContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //Services
        public UserProjectCon GetUserProjectConById(string Id)
        {
            return dbContext.UserProjectCon.FirstOrDefault(con => con.Id == Guid.Parse(Id));
        }

        public void UpdateConnection(string id, string role, string description, string status)
        {
            var userProjectCon = GetUserProjectConById(id);
            userProjectCon.Role = role;
            userProjectCon.Description = description;
            userProjectCon.Status = status;
            dbContext.UserProjectCon.Update(userProjectCon);
            dbContext.SaveChanges();
        }
    }
}

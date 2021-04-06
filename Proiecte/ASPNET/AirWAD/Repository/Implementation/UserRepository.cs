using AirWAD.Models.DataBase;
using AirWAD.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirWAD.Repository.Implementation
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AirWADContext dbContext) : base(dbContext)
        {

        }

        public User GetClientByUserId(Guid userId)
        {
            return dbContext.Users
                            .Where(user => user.Id == userId)
                            .SingleOrDefault();
        }

        public User GetUserById(string userId)
        {
            var userIdGuid = Guid.Parse(userId);
            return dbContext.Users
                .Where(user => user.Id == userIdGuid)
                .SingleOrDefault();
        }
    }
}
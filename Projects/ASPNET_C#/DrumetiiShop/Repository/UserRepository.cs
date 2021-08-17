using DrumetiiShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrumetiiShop.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DrumetiiShopDbContext dbContext) : base(dbContext)
        {

        }
    }
}

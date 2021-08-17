using PocketPlane.ApplicationLogic.Abstractions;
using PocketPlane.ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PocketPlane.DataAccess
{
    public class AdminRepository : BaseRepository<Admin>, IAdminRepository
    {
        public AdminRepository(PocketPlaneDbContext dbContext) : base(dbContext)
        {
        }
        public Admin GetAdminByUserId(Guid userId)
        {
            return dbContext.Admins
                            .Where(admin => admin.UserId == userId)
                            .FirstOrDefault();
        }
    }
}

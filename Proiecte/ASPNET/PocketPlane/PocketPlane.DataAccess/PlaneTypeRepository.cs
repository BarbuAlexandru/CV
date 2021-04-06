using Microsoft.EntityFrameworkCore;
using PocketPlane.ApplicationLogic.Abstractions;
using PocketPlane.ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PocketPlane.DataAccess
{
    public class PlaneTypeRepository : BaseRepository<PlaneType>, IPlaneTypeRepository
    {
        public PlaneTypeRepository(PocketPlaneDbContext dbContext) : base(dbContext)
        {


        }

        public PlaneType GetPlaneTypeByID(Guid Id)
        {

            return dbContext.PlaneTypes
                            .Where(planeType => planeType.Id == Id)
                            .Include(planeType => planeType.Flight)
                            .FirstOrDefault();
        }

        public IEnumerable<PlaneType> GetAllPlaneTypes()
        {
            return dbContext.PlaneTypes
                             .Include(planeType => planeType.Flight)
                             .AsEnumerable();
        }

    }
}

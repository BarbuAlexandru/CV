using PocketPlane.ApplicationLogic.Abstractions;
using PocketPlane.ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace PocketPlane.DataAccess
{
    public class FlightScheduleRepository : BaseRepository<FlightSchedule>, IFlightScheduleRepository
    {
        public FlightScheduleRepository(PocketPlaneDbContext dbContext) : base(dbContext)
        {


        }
    }
}

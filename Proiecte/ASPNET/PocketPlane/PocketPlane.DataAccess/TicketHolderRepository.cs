using PocketPlane.ApplicationLogic.Abstractions;
using PocketPlane.ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace PocketPlane.DataAccess
{
    public class TicketHolderRepository : BaseRepository<TicketHolder>, ITicketHolderRepository
    {
        public TicketHolderRepository(PocketPlaneDbContext dbContext) : base(dbContext)
        {


        }
    }
}

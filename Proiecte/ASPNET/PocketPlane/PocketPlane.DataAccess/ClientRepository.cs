using PocketPlane.ApplicationLogic.Abstractions;
using PocketPlane.ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PocketPlane.DataAccess
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public ClientRepository(PocketPlaneDbContext dbContext) : base(dbContext)
        {

        }

        public Client GetClientByUserId(Guid userId)
        {
            return dbContext.Clients
                            .Where(client => client.UserId == userId)
                            .FirstOrDefault();
        }
    }
}

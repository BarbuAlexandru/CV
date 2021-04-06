using PocketPlane.ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace PocketPlane.ApplicationLogic.Abstractions
{
    public interface IClientRepository: IRepository<Client>
    {
        public Client GetClientByUserId(Guid userId);
    }
}

using PocketPlane.ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace PocketPlane.ApplicationLogic.Abstractions
{
    public interface IAdminRepository: IRepository<Admin>
    {
        public Admin GetAdminByUserId(Guid userId);
    }
}

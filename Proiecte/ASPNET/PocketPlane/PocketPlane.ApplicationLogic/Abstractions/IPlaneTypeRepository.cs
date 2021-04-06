using PocketPlane.ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace PocketPlane.ApplicationLogic.Abstractions
{
    public interface IPlaneTypeRepository : IRepository<PlaneType>
    {
        public PlaneType GetPlaneTypeByID(Guid Id);
        public IEnumerable<PlaneType> GetAllPlaneTypes();
    }
    
}

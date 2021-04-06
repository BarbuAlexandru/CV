using PocketPlane.ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketPlane.Models.Admins
{
    public class AdminPlaneTypesViewModel
    {
        public IEnumerable<PlaneType> PlaneTypes { get; internal set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketPlane.ApplicationLogic.DataModel
{
    public class Client
    {

        public Guid Id { set; get; }
        public Guid UserId { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Email { set; get; }
        public string PhoneNo { set; get; }
        public string Address { set; get; }
        public string CI_Passport { set; get; }

    }
}

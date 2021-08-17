using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PocketPlane.ApplicationLogic.DataModel
{
    public class Admin
    {
        [Key]
        public Guid Id { set; get; }
        public Guid UserId { set; get; }
        public string? Code { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
    }
}
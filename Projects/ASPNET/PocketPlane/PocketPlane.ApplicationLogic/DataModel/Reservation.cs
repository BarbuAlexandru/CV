using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PocketPlane.ApplicationLogic.DataModel
{
    public class Reservation
    { 
        public Guid Id { set; get; }
        public Client? Client { set; get; }
        public TicketHolder? TicketHolder { set; get; }
        public int Seat { set; get; }

    }
}
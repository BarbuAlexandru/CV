using PocketPlane.ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace PocketPlane.ApplicationLogic.Abstractions
{
    public interface IReservationRepository : IRepository<Reservation>
    {
        public Reservation GetReservationByID(Guid Id);
        public IEnumerable<Reservation> GetAllReservations();

        public void DeleteReservationsfromFlight(ICollection<Reservation> reservations);

    }
}

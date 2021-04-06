using Microsoft.EntityFrameworkCore;
using PocketPlane.ApplicationLogic.Abstractions;
using PocketPlane.ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PocketPlane.DataAccess
{
    public class ReservationRepository : BaseRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(PocketPlaneDbContext dbContext) : base(dbContext)
        {


        }

        public Reservation GetReservationByID(Guid Id)
        {

            return dbContext.Reservations
                            .Where(res => res.Id == Id)
                            .Include(res => res.TicketHolder)
                            .Include(res => res.Client)
                            .FirstOrDefault();
        }
        public IEnumerable<Reservation> GetAllReservations()
        {
            return dbContext.Reservations
                             .Include(reservation => reservation.TicketHolder)
                             .Include(reservation => reservation.Client)
                             .AsEnumerable();
        }

        public void DeleteReservationsfromFlight(ICollection<Reservation> reservations)
        {
            foreach (var rez in reservations)
                dbContext.Reservations.Remove(rez);
            dbContext.SaveChanges();
        }
    }
}

using AirWAD.Models.DataBase;
using AirWAD.Repository.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirWAD.Repository.Implementation
{
    public class ReservationRepository : BaseRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(AirWADContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<Reservation> GetReservations()
        {
            return dbContext.Reservations.Where(x => x.Id != null)
                           .Include(reservation => reservation.Rental)
                           .AsEnumerable();
        }
    }
}
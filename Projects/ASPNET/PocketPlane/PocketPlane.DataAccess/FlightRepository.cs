using Microsoft.EntityFrameworkCore;
using PocketPlane.ApplicationLogic.Abstractions;
using PocketPlane.ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PocketPlane.DataAccess
{
    public class FlightRepository : BaseRepository<Flight>, IFlightRepository
    {
        public FlightRepository(PocketPlaneDbContext dbContext) : base(dbContext)
        {


        }

        public Flight GetFlightByID(Guid Id)
        {

            var flight_value = dbContext.Flights
                                        .Where(flight => flight.Id == Id)
                                        .Include(flight => flight.FlightSchedule)
                                        .Include(flight => flight.Admin)
                                        .Include(flight => flight.Reservations).ThenInclude(rez => rez.TicketHolder)
                                        .FirstOrDefault();
            return flight_value;
        }

        public IEnumerable<Flight> GetAllFlights()
        {
            return dbContext.Flights
                             .Include(flight => flight.FlightSchedule)
                             .Include(flight => flight.Admin)
                             .Include(flight => flight.Reservations)
                             .AsEnumerable();
        }

        public IEnumerable<Flight> GetFutureFlights()
        {
            return dbContext.Flights
                             .Where(flight => flight.FlightSchedule.DepartureDate > DateTime.Now)
                             .Include(flight => flight.FlightSchedule)
                             .Include(flight => flight.Admin)
                             .Include(flight => flight.Reservations)
                             .AsEnumerable();
        }

        public IEnumerable<Flight> GetPastFlights()
        {
            return dbContext.Flights
                             .Where(flight => flight.FlightSchedule.DepartureDate < DateTime.Now)
                             .Include(flight => flight.FlightSchedule)
                             .Include(flight => flight.Admin)
                             .Include(flight => flight.Reservations)
                             .AsEnumerable();
        }

        public IEnumerable<Flight> GetByNO(string flightNO)
        {
            return dbContext.Flights
                .Where(x => x.FlightNo == flightNO || flightNO == null)
                .Include(flight => flight.FlightSchedule)
                .Include(flight => flight.Admin)
                .Include(flight => flight.Reservations)
                .AsEnumerable();
        }

        public IEnumerable<Flight> GetByBusinessPrice(string businessPrice)
        {
            return dbContext.Flights
                .Where(x => x.BusinessPrice.ToString() == businessPrice || businessPrice == null)
                .Include(flight => flight.FlightSchedule)
                .Include(flight => flight.Admin)
                .Include(flight => flight.Reservations)
                .AsEnumerable();
        }

        public IEnumerable<Flight> GetByDepartureCity(string departureCity)
        {
            return dbContext.Flights
                .Where(x => x.FlightSchedule.DepartureCity == departureCity || departureCity == null)
                .Include(flight => flight.FlightSchedule)
                .Include(flight => flight.Admin)
                .Include(flight => flight.Reservations)
                .AsEnumerable();
        }

        public IEnumerable<Flight> GetByArrivalCity(string arrivalCity)
        {
            return dbContext.Flights
                .Where(x => x.FlightSchedule.ArrivalCity == arrivalCity || arrivalCity == null)
                .Include(flight => flight.FlightSchedule)
                .Include(flight => flight.Admin)
                .Include(flight => flight.Reservations)
                .AsEnumerable();
        }
    }
}

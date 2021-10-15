using HighwayTolls.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HighwayTolls.Services
{
    public class TripService
    {

        private readonly NetRomTestDbContext dbContext;
        private readonly TollLocationService tollLocationService;

        public TripService(NetRomTestDbContext dbContext, TollLocationService tollLocationService)
        {
            this.dbContext = dbContext;
            this.tollLocationService = tollLocationService;
        }

        public Trip GetTripById(Guid tripId)
        {
            return dbContext.Trips.Where(e => e.Id == tripId).FirstOrDefault();
        }

        public void CreateTrip(Employee emp, TollLocation startCity, string vehicle)
        {

            var trip = new Trip()
            {
                Id = Guid.NewGuid(),
                StartCity = startCity,
                StartCityId = startCity.Id,
                EndCity = null,
                EndCityId = null,
                Vehicle = vehicle,
                Employee = emp,
                EmployeeId = emp.Id,
                TripPayments = null
            };

            dbContext.Trips.Add(trip);
            dbContext.SaveChanges();
        }

        public List<Trip> GetUnfinishedTrips()
        {
            return dbContext.Trips.Where(t => t.EndCityId == null).ToList();
        }
    }
}

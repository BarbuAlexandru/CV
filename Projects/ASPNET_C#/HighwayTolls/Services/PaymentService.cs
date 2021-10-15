using HighwayTolls.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HighwayTolls.Services
{
    public class PaymentService
    {

        private readonly NetRomTestDbContext dbContext;
        private readonly TollLocationService tollLocationService;
        private readonly TripService tripService;

        public PaymentService(NetRomTestDbContext dbContext, TollLocationService tollLocationService, TripService tripService)
        {
            this.dbContext = dbContext;
            this.tollLocationService = tollLocationService;
            this.tripService = tripService;
        }

        //Service
        public void ExecuteTollPayment(Employee emp, Guid locationId, int price)
        {
            var payment = new TollPayment()
            {
                Id = Guid.NewGuid(),
                Amount = price,
                LocationId = locationId,
                Date = DateTime.Now,
                Employee = emp,
                EmployeeId = emp.Id
            };

            dbContext.TollPayments.Add(payment);
            dbContext.SaveChanges();
        }

        public int GetTollPrice(Guid id, string vehicle)
        {
            try
            {
                return dbContext.TollPrices.Where(p => (p.TollLocationId == id && p.Vehicle == vehicle)).FirstOrDefault().Price;
            }
            catch
            {
                throw new NullReferenceException("NO PRICE SET FOR THIS TOLL " + id+" - "+vehicle);
            }
        }

        public int GetTripPrice(Guid startCityId, Guid endCityId, string vehicle)
        {
            try
            {
                return dbContext.TripPrices.Where(t => (t.StartCityId == startCityId && t.EndCityId == endCityId && t.Vehicle == vehicle)
                                                        || (t.StartCityId == endCityId && t.EndCityId == startCityId && t.Vehicle == vehicle)).FirstOrDefault().Price;
            }
            catch
            {
                throw new NullReferenceException("NO PRICE SET FOR THIS TRIP "+startCityId+" - "+endCityId + " - "+vehicle);
            }
        }

        public void ExecuteTripPayment(Employee emp, Guid tripId, int price)
        {
            var trip = tripService.GetTripById(tripId);

            if (emp.TollBoothId == null)
            {
                throw new ArgumentNullException("currentUser.TollBoothId");
            }

            var endCity = tollLocationService.GetTollLocationByBoothId(emp.TollBoothId.Value);

            var tripPayment = new TripPayment()
            {
                Id = Guid.NewGuid(),
                Amount = price,
                Date = DateTime.Now,
                LocationId = endCity.Id,
                Trip = trip,
                TripId = trip.Id
            };

            trip.EndCity = endCity;
            trip.EndCityId = endCity.Id;
            trip.Employee = emp;
            trip.EmployeeId = emp.Id;

            dbContext.TripPayments.Add(tripPayment);
            dbContext.Trips.Update(trip);
            dbContext.SaveChanges();
        }

        public List<TollPayment> GetAllTollPaymentsInLocation(Guid locationId)
        {
            return dbContext.TollPayments.Where(p => p.LocationId == locationId).ToList();
        }

        public List<TripPayment> GetAllTripPaymentsInLocation(Guid locationId)
        {
            return dbContext.TripPayments.Where(p => p.LocationId == locationId).ToList();
        }

    }
}

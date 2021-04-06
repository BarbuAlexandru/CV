using PocketPlane.ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace PocketPlane.ApplicationLogic.Abstractions
{
    public interface IFlightRepository: IRepository<Flight>
    {
        public Flight GetFlightByID(Guid Id);

        public IEnumerable<Flight> GetAllFlights();

        public IEnumerable<Flight> GetPastFlights();

        public IEnumerable<Flight> GetFutureFlights();
        IEnumerable<Flight> GetByNO(string flightNO);
        IEnumerable<Flight> GetByBusinessPrice(string businessPrice);
        IEnumerable<Flight> GetByDepartureCity(string departureCity);
        IEnumerable<Flight> GetByArrivalCity(string arrivalCity);
    }
}

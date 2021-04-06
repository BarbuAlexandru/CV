using PocketPlane.ApplicationLogic.Exceptions;
using PocketPlane.ApplicationLogic.Abstractions;
using PocketPlane.ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PocketPlane.ApplicationLogic.Services
{
    public class AdminsService
    {
        private IAdminRepository adminRepository;
        private IFlightRepository flightRepository;
        private IPlaneTypeRepository planeTypeRepository;
        private IFlightScheduleRepository flightScheduleRepository;
        private IReservationRepository reservationRepository;

        public AdminsService(IAdminRepository adminRepository, IFlightRepository flightRepository, IPlaneTypeRepository planeTypeRepository, 
            IFlightScheduleRepository flightScheduleRepository, IReservationRepository reservationRepository)
        {
            this.adminRepository = adminRepository;
            this.flightRepository = flightRepository;
            this.planeTypeRepository = planeTypeRepository;
            this.flightScheduleRepository = flightScheduleRepository;
            this.reservationRepository = reservationRepository;
        }

        public Admin GetAdminById(string adminId)
        {
            Guid adminIdGuid = Guid.Empty;
            if (!Guid.TryParse(adminId, out adminIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }

            var admin = adminRepository.GetAdminByUserId(adminIdGuid);
            if (admin == null)
            {
                throw new EntityNotFoundException(adminIdGuid);
            }

            return admin;

        }

        public PlaneType GetPlaneTypeById(string planeTypeId)
        {
            Guid planeTypeIdGuid = Guid.Empty;
            if (!Guid.TryParse(planeTypeId, out planeTypeIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }

            var planeType = planeTypeRepository.GetById(planeTypeIdGuid);
            if (planeType == null)
            {
                throw new EntityNotFoundException(planeTypeIdGuid);
            }

            return planeType;
        }

        public Flight GetFlightById(Guid flightId)
        {

            var flight = flightRepository.GetFlightByID(flightId);

            //var res = reservationRepository.GetReservationByID(res.Id);
            
            if (flight == null)
            {
                throw new EntityNotFoundException(flightId);
            }

            return flight;
        }



        public void AddFlight( string flightNo, decimal businessPrice, decimal economyPrice,
                               DateTime departureDate, string departureCity, string departureAirport, 
                               string departureHour, DateTime arrivalDate, 
                               string arrivalCity, string arrivalAirport, string arrivalHour,
                               Guid planeTypeId,string adminId)
         {

             Guid adminIdGuid = Guid.Empty;
             if (!Guid.TryParse(adminId, out adminIdGuid))
             {
                 throw new Exception("Invalid Guid Format");
             }
             var admin = adminRepository.GetAdminByUserId(adminIdGuid);
             if (admin == null)
             {
                 throw new EntityNotFoundException(adminIdGuid);
             }

             var flightSchedule = flightScheduleRepository.Add( new FlightSchedule() { 
                Id = Guid.NewGuid(),
                DepartureDate = departureDate,
                DepartureCity = departureCity,
                DepartureAirport = departureAirport,
                DepartureHour = departureHour,
                ArrivalDate = arrivalDate,
                ArrivalCity = arrivalCity,
                ArrivalAirport = arrivalAirport,
                ArrivalHour = arrivalHour
             });
            var flight = flightRepository.Add(new Flight()
            {
                Id = Guid.NewGuid(),
                Admin = admin,
                FlightNo = flightNo,
                BusinessPrice = businessPrice,
                EconomyPrice = economyPrice,
                FlightSchedule = flightSchedule,
            });

            var planeType = planeTypeRepository.GetPlaneTypeByID(planeTypeId);
            planeType.Flight.Add(flight);
            planeTypeRepository.Update(planeType);
         }

        public bool DeleteFlight(Flight flight)
        {
            var flightSchedule = flight.FlightSchedule;
            flightScheduleRepository.Delete(flightSchedule);

            var reservations = flight.Reservations;
            reservationRepository.DeleteReservationsfromFlight(reservations);
            
            return flightRepository.Delete(flight);
        }

        public void EditFlight(Guid FlightId, string flightNo, decimal businessPrice, decimal economyPrice,
                               DateTime departureDate, string departureCity, string departureAirport,
                               string departureHour, DateTime arrivalDate,
                               string arrivalCity, string arrivalAirport, string arrivalHour)
        {

            /*Guid adminIdGuid = Guid.Empty;
            if (!Guid.TryParse(adminId, out adminIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }
            var admin = adminRepository.GetById(adminIdGuid);
            if (admin == null)
            {
                throw new EntityNotFoundException(adminIdGuid);
            }*/

            var flight = flightRepository.GetFlightByID(FlightId);
            flight.FlightNo = flightNo;
            flight.BusinessPrice = businessPrice;
            flight.EconomyPrice = economyPrice;
            flight.FlightSchedule.DepartureDate = departureDate;
            flight.FlightSchedule.DepartureCity = departureCity;
            flight.FlightSchedule.DepartureAirport = departureAirport;
            flight.FlightSchedule.DepartureHour = departureHour;
            flight.FlightSchedule.ArrivalDate = arrivalDate;
            flight.FlightSchedule.ArrivalCity = arrivalCity;
            flight.FlightSchedule.ArrivalAirport = arrivalAirport;
            flight.FlightSchedule.ArrivalHour = arrivalHour;

            flightRepository.Update(flight);
        }


        public IEnumerable<Flight> GetFlightByNO(string flightNO)
        {
            return flightRepository.GetByNO(flightNO);
        }

        public IEnumerable<Flight> GetFlightByBusinessPrice(string businessPrice)
        {
            return flightRepository.GetByBusinessPrice(businessPrice);
        }

        public IEnumerable<Flight> GetFlightByDepartureCity(string departureCity)
        {
            return flightRepository.GetByDepartureCity(departureCity);
        }

        public IEnumerable<Flight> GetFlightByArrivalCity(string arrivalCity)
        {
            return flightRepository.GetByArrivalCity(arrivalCity);
        }


        public void AddPlaneType(string model, string manfacturer, int capacityBusiness, int capacityEconomy)
         {
            planeTypeRepository.Add(new PlaneType() 
            { Id = Guid.NewGuid(), 
                Model = model, 
                Manufacturer = manfacturer,                               
                CapacityBusiness = capacityBusiness, 
                CapacityEconomy = capacityEconomy });

         }

        public IEnumerable<PlaneType> GetPlaneTypes()
        {
            return planeTypeRepository.GetAllPlaneTypes();
        }

        public IEnumerable<Flight> GetAllFlights()
        {

            return flightRepository.GetAllFlights()
                            .AsEnumerable();
        }

        public IEnumerable<Flight> GetFutureFlights()
        {
            return flightRepository.GetFutureFlights();
        }

        public IEnumerable<Flight> GetPastFlights()
        {
            return flightRepository.GetPastFlights();
        }


        public Admin CreateAdmin(string userId, string firstName, string lastName)
        {
            var admin = new Admin
            {
                UserId = Guid.Parse(userId),
                FirstName = firstName,
                LastName = lastName
            };
            adminRepository.Add(admin);
            return admin;
        }


        public void EditAccount(Guid userId, string firstName, string lastName)
        {

            var admin = adminRepository.GetAdminByUserId(userId);

            admin.FirstName = firstName;
            admin.LastName = lastName;

            adminRepository.Update(admin);
        }



    }
}

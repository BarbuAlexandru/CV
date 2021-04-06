using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PocketPlane.ApplicationLogic.Abstractions;
using PocketPlane.ApplicationLogic.DataModel;
using PocketPlane.ApplicationLogic.Exceptions;
using PocketPlane.ApplicationLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PocketPlaneUnitTests.Services
{
    [TestClass]
    public class AdminsServiceUnitTests
    {
        private AdminsService adminsService;
        private Mock<IAdminRepository> adminRepositoryMock;
        private Mock<IFlightRepository> flightRepositoryMock;
        private Mock<IPlaneTypeRepository> planeTypeRepositoryMock;
        private Mock<IFlightScheduleRepository> flightScheduleRepositoryMock;
        private Mock<IReservationRepository> reservationRepositoryMock;

        //Setup
        [TestInitialize]
        public void Setup()
        {
            adminRepositoryMock = new Mock<IAdminRepository>();
            flightRepositoryMock = new Mock<IFlightRepository>();
            planeTypeRepositoryMock = new Mock<IPlaneTypeRepository>();
            flightScheduleRepositoryMock = new Mock<IFlightScheduleRepository>();
            reservationRepositoryMock = new Mock<IReservationRepository>();
        }


        //GetAdminById - Method
        [TestMethod]
        public void GetAdminById_ThrowsException_InvalidId()
        {
            adminsService = new AdminsService(adminRepositoryMock.Object, flightRepositoryMock.Object,
                planeTypeRepositoryMock.Object, flightScheduleRepositoryMock.Object, reservationRepositoryMock.Object);

            var invalidAdminId = "invalid";
            Assert.ThrowsException<Exception>(() =>
            {
                adminsService.GetAdminById(invalidAdminId);
            });
        }

        [TestMethod]
        public void GetAdminById_ThrowsEntityNotFound_AdminDoesntExist()
        {
            var nonExistingAdmin = Guid.NewGuid().ToString();
            var existingAdmin = Guid.NewGuid();

            var admin = new Admin
            {
                Id = existingAdmin,
                FirstName = "firstName",
                LastName = "lastName"
            };

            adminRepositoryMock.Setup(adminRepositoryMock => adminRepositoryMock.GetAdminByUserId(existingAdmin)).Returns(admin);

            adminsService = new AdminsService(adminRepositoryMock.Object, flightRepositoryMock.Object,
                planeTypeRepositoryMock.Object, flightScheduleRepositoryMock.Object, reservationRepositoryMock.Object);

            Assert.ThrowsException<EntityNotFoundException>(() =>
            {
                adminsService.GetAdminById(nonExistingAdmin);
            });
        }

        [TestMethod]
        public void GetAdminById_Returns_AdminExists()
        {
            var existingAdminId = Guid.NewGuid();

            var admin = new Admin
            {
                Id = existingAdminId,
                UserId = Guid.NewGuid(),
                FirstName = "firstName",
                LastName = "lastName"
            };

            adminRepositoryMock.Setup(adminRepositoryMock => adminRepositoryMock.GetAdminByUserId(existingAdminId)).Returns(admin);

            adminsService = new AdminsService(adminRepositoryMock.Object, flightRepositoryMock.Object,
                planeTypeRepositoryMock.Object, flightScheduleRepositoryMock.Object, reservationRepositoryMock.Object);

            var searchedAdmin = adminsService.GetAdminById(existingAdminId.ToString());

            Assert.IsNotNull(searchedAdmin);
        }


        //GetPlaneTypeById - Method
        [TestMethod]
        public void GetPlaneTypeById_ThrowsException_InvalidId()
        {
            adminsService = new AdminsService(adminRepositoryMock.Object, flightRepositoryMock.Object,
                planeTypeRepositoryMock.Object, flightScheduleRepositoryMock.Object, reservationRepositoryMock.Object);

            var invalidPlaneTypeId = "invalid";
            Assert.ThrowsException<Exception>(() =>
            {
                adminsService.GetPlaneTypeById(invalidPlaneTypeId);
            });
        }

        [TestMethod]
        public void GetPlaneTypeById_ThrowsEntityNotFound_PlaneTypeDoesntExist()
        {
            var nonExistingPlaneType = Guid.NewGuid().ToString();
            var existingPlaneType = Guid.NewGuid();

            var planeType = new PlaneType
            {
                Id = existingPlaneType,
                Model = "model",
                Manufacturer = "manufacturer",
                CapacityBusiness = 100,
                CapacityEconomy = 100
            };

            planeTypeRepositoryMock.Setup(planeTypeRepositoryMock => planeTypeRepositoryMock.GetById(existingPlaneType)).Returns(planeType);

            adminsService = new AdminsService(adminRepositoryMock.Object, flightRepositoryMock.Object,
                planeTypeRepositoryMock.Object, flightScheduleRepositoryMock.Object, reservationRepositoryMock.Object);

            Assert.ThrowsException<EntityNotFoundException>(() =>
            {
                adminsService.GetPlaneTypeById(nonExistingPlaneType);
            });
        }

        [TestMethod]
        public void GetPlaneTypeById_Returns_PlaneTypeExists()
        {
            var existingPlaneType = Guid.NewGuid();

            var planeType = new PlaneType
            {
                Id = existingPlaneType,
                Model = "model",
                Manufacturer = "manufacturer",
                CapacityBusiness = 100,
                CapacityEconomy = 100
            };

            planeTypeRepositoryMock.Setup(planeTypeRepositoryMock => planeTypeRepositoryMock.GetById(existingPlaneType)).Returns(planeType);

            adminsService = new AdminsService(adminRepositoryMock.Object, flightRepositoryMock.Object,
                planeTypeRepositoryMock.Object, flightScheduleRepositoryMock.Object, reservationRepositoryMock.Object);

            var searchedPlaneType = adminsService.GetPlaneTypeById(existingPlaneType.ToString());

            Assert.IsNotNull(searchedPlaneType);
        }

        //GetFlightById - Method
        [TestMethod]
        public void GetFlightById_ThrowsException_InvalidId()
        {
            adminsService = new AdminsService(adminRepositoryMock.Object, flightRepositoryMock.Object,
                planeTypeRepositoryMock.Object, flightScheduleRepositoryMock.Object, reservationRepositoryMock.Object);

            var invalidFlightId = "invalid";
            Assert.ThrowsException<FormatException>(() =>
            {
                adminsService.GetFlightById(Guid.Parse(invalidFlightId));
            });
        }

        [TestMethod]
        public void GetFlightById_ThrowsEntityNotFound_FlightDoesntExist()
        {
            var nonExistingFlight = Guid.NewGuid().ToString();
            var existingFlight = Guid.NewGuid();

            var flight = new Flight
            {
                Id = existingFlight,
                FlightNo = "default",
                BusinessPrice = 10,
                EconomyPrice = 10
            };

            flightRepositoryMock.Setup(flightRepositoryMock => flightRepositoryMock.GetFlightByID(existingFlight)).Returns(flight);

            adminsService = new AdminsService(adminRepositoryMock.Object, flightRepositoryMock.Object,
                planeTypeRepositoryMock.Object, flightScheduleRepositoryMock.Object, reservationRepositoryMock.Object);

            Assert.ThrowsException<EntityNotFoundException>(() =>
            {
                adminsService.GetFlightById(Guid.Parse(nonExistingFlight));
            });
        }

        [TestMethod]
        public void GetFlightById_Returns_FlightExists()
        {
            var existingFlight = Guid.NewGuid();

            var flight = new Flight
            {
                Id = existingFlight,
                FlightNo = "default",
                BusinessPrice = 10,
                EconomyPrice = 10
            };

            flightRepositoryMock.Setup(flightRepositoryMock => flightRepositoryMock.GetFlightByID(existingFlight)).Returns(flight);

            adminsService = new AdminsService(adminRepositoryMock.Object, flightRepositoryMock.Object,
                planeTypeRepositoryMock.Object, flightScheduleRepositoryMock.Object, reservationRepositoryMock.Object);

            var searchedFlight = adminsService.GetFlightById(existingFlight);

            Assert.IsNotNull(searchedFlight);
        }

        // New Tests ----------------------

        //GetFlightByNO - Method Unit Tests
        [TestMethod]
        public void GetFlightByNO_NullFlightNo_ThrowsException()
        {
            Assert.ThrowsException<NullReferenceException>(() => {
                adminsService.GetFlightByNO(null);
            });
        }

        [TestMethod]
        public void GetFlightByNO_InexistentFlightNo_EmptyCollection()
        {
            string searchedNO = "var0";
            List<Flight> flights = new List<Flight>();
            flights.Add(new Flight 
            { 
                Id = Guid.NewGuid(),
                FlightNo = "var1"
            });
            flights.Add(new Flight
            {
                Id = Guid.NewGuid(),
                FlightNo = "var2"
            });

            flightRepositoryMock.Setup(flightRepositoryMock => flightRepositoryMock.GetByNO(searchedNO)).
                Returns(flights.FindAll(flight => flight.FlightNo.Equals(searchedNO)).AsEnumerable());

            adminsService = new AdminsService(adminRepositoryMock.Object, flightRepositoryMock.Object,
                planeTypeRepositoryMock.Object, flightScheduleRepositoryMock.Object, reservationRepositoryMock.Object);

            Assert.IsTrue(adminsService.GetFlightByNO(searchedNO).Count() == 0);
        }

        [TestMethod]
        public void GetFlightByNO_ExistentFlightNo_ValidCollection()
        {
            string searchedNO = "var1";
            List<Flight> flights = new List<Flight>();
            flights.Add(new Flight
            {
                Id = Guid.NewGuid(),
                FlightNo = searchedNO
            });
            flights.Add(new Flight
            {
                Id = Guid.NewGuid(),
                FlightNo = "var2"
            });

            flightRepositoryMock.Setup(flightRepositoryMock => flightRepositoryMock.GetByNO(searchedNO)).
                Returns(flights.FindAll(flight => flight.FlightNo.Equals(searchedNO)).AsEnumerable());

            adminsService = new AdminsService(adminRepositoryMock.Object, flightRepositoryMock.Object,
                planeTypeRepositoryMock.Object, flightScheduleRepositoryMock.Object, reservationRepositoryMock.Object);

            Assert.IsNotNull(adminsService.GetFlightByNO(searchedNO));
        }

        // GetFlightByDepCity - Method Unit Tests
        [TestMethod]
        public void GetFlightByDepCity_NullDepCity_ThrowsException()
        {
            Assert.ThrowsException<NullReferenceException>(() => {
                adminsService.GetFlightByDepartureCity(null);
            });
        }



        [TestMethod]
        public void GetFlightByDepCity_InexistentDepCity_EmptyCollection()
        {
            string searchedDepCity = "depcity";
            List<Flight> flights = new List<Flight>();
            flights.Add(new Flight
            {
                Id = Guid.NewGuid(),
                FlightSchedule = new FlightSchedule { Id = Guid.NewGuid(), DepartureCity = "depcity1" }

            });
            flights.Add(new Flight
            {
                Id = Guid.NewGuid(),
                FlightSchedule = new FlightSchedule { Id = Guid.NewGuid(), DepartureCity = "depcity2" }
            });

            flightRepositoryMock.Setup(flightRepositoryMock => flightRepositoryMock.GetByDepartureCity(searchedDepCity)).
                Returns(flights.FindAll(flight => flight.FlightSchedule.DepartureCity.Equals(searchedDepCity)).AsEnumerable());

            adminsService = new AdminsService(adminRepositoryMock.Object, flightRepositoryMock.Object,
                planeTypeRepositoryMock.Object, flightScheduleRepositoryMock.Object, reservationRepositoryMock.Object);

            Assert.IsTrue(adminsService.GetFlightByDepartureCity(searchedDepCity).Count() == 0);
        }


        [TestMethod]
        public void GetFlightByDepCity_ExistentDepCity_EmptyCollection()
        {
            string searchedDepCity = "depcity";
            List<Flight> flights = new List<Flight>();
            flights.Add(new Flight
            {
                Id = Guid.NewGuid(),
                FlightSchedule = new FlightSchedule { Id = Guid.NewGuid(), DepartureCity = searchedDepCity }

            });
            flights.Add(new Flight
            {
                Id = Guid.NewGuid(),
                FlightSchedule = new FlightSchedule { Id = Guid.NewGuid(), DepartureCity = "depcity2" }
            });

            flightRepositoryMock.Setup(flightRepositoryMock => flightRepositoryMock.GetByDepartureCity(searchedDepCity)).
                Returns(flights.FindAll(flight => flight.FlightSchedule.DepartureCity.Equals(searchedDepCity)).AsEnumerable());

            adminsService = new AdminsService(adminRepositoryMock.Object, flightRepositoryMock.Object,
                planeTypeRepositoryMock.Object, flightScheduleRepositoryMock.Object, reservationRepositoryMock.Object);

            Assert.IsNotNull(adminsService.GetFlightByDepartureCity(searchedDepCity));
        }

        //GetFlightByArrivalCity - Method Unit Tests
        [TestMethod]
        public void GetFlightByArrivalCity_NullArrivalCity_ThrowsException()
        {
            Assert.ThrowsException<NullReferenceException>(() => {
                adminsService.GetFlightByDepartureCity(null);
            });
        }



        [TestMethod]
        public void GetFlightByArrivalCity_InexistentArrivalCity_EmptyCollection()
        {
            string searchedArrivalpCity = "Arrivalcity";
            List<Flight> flights = new List<Flight>();
            flights.Add(new Flight
            {
                Id = Guid.NewGuid(),
                FlightSchedule = new FlightSchedule { Id = Guid.NewGuid(), ArrivalCity = "Arrivalcity1" }

            });
            flights.Add(new Flight
            {
                Id = Guid.NewGuid(),
                FlightSchedule = new FlightSchedule { Id = Guid.NewGuid(), ArrivalCity = "Arrivalcity2" }
            });

            flightRepositoryMock.Setup(flightRepositoryMock => flightRepositoryMock.GetByDepartureCity(searchedArrivalpCity)).
                Returns(flights.FindAll(flight => flight.FlightSchedule.ArrivalCity.Equals(searchedArrivalpCity)).AsEnumerable());

            adminsService = new AdminsService(adminRepositoryMock.Object, flightRepositoryMock.Object,
                planeTypeRepositoryMock.Object, flightScheduleRepositoryMock.Object, reservationRepositoryMock.Object);

            Assert.IsTrue(adminsService.GetFlightByDepartureCity(searchedArrivalpCity).Count() == 0);
        }


        [TestMethod]
        public void GetFlightByArrivalCity_ExistentArrivalCity_EmptyCollection()
        {
            string searchedArrivalpCity = "Arrivalcity";
            List<Flight> flights = new List<Flight>();
            flights.Add(new Flight
            {
                Id = Guid.NewGuid(),
                FlightSchedule = new FlightSchedule { Id = Guid.NewGuid(), ArrivalCity = searchedArrivalpCity }

            });
            flights.Add(new Flight
            {
                Id = Guid.NewGuid(),
                FlightSchedule = new FlightSchedule { Id = Guid.NewGuid(), ArrivalCity = "Arrivalcity2" }
            });

            flightRepositoryMock.Setup(flightRepositoryMock => flightRepositoryMock.GetByDepartureCity(searchedArrivalpCity)).
                Returns(flights.FindAll(flight => flight.FlightSchedule.ArrivalCity.Equals(searchedArrivalpCity)).AsEnumerable());

            adminsService = new AdminsService(adminRepositoryMock.Object, flightRepositoryMock.Object,
                planeTypeRepositoryMock.Object, flightScheduleRepositoryMock.Object, reservationRepositoryMock.Object);

            Assert.IsNotNull(adminsService.GetFlightByDepartureCity(searchedArrivalpCity));
        }
    }
}

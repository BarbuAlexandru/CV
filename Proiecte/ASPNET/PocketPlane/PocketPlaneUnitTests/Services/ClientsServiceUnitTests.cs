using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PocketPlane.ApplicationLogic.Abstractions;
using PocketPlane.ApplicationLogic.DataModel;
using PocketPlane.ApplicationLogic.Exceptions;
using PocketPlane.ApplicationLogic.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PocketPlaneUnitTests.Services
{
    [TestClass]
    public class ClientsServiceUnitTests
    {
        private ClientsService clientsService;
        private AdminsService adminsService;
        private Mock<IClientRepository> clientRepositoryMock;
        private Mock<ITicketHolderRepository> ticketHolderRepositoryMock;
        private Mock<IReservationRepository> reservationRepositoryMock;
        private Mock<IFlightRepository> flightRepositoryMock;
        private Mock<IAdminRepository> adminRepositoryMock;
        private Mock<IPlaneTypeRepository> planeTypeRepositoryMock;
        private Mock<IFlightScheduleRepository> flightScheduleRepositoryMock;

        //Setup
        [TestInitialize]
        public void Setup()
        {
            clientRepositoryMock = new Mock<IClientRepository>();
            ticketHolderRepositoryMock = new Mock<ITicketHolderRepository>();
            reservationRepositoryMock = new Mock<IReservationRepository>();
            flightRepositoryMock = new Mock<IFlightRepository>();
            adminRepositoryMock = new Mock<IAdminRepository>();
            planeTypeRepositoryMock = new Mock<IPlaneTypeRepository>();
            flightScheduleRepositoryMock = new Mock<IFlightScheduleRepository>();
        }

        //GetClientById - Method
        [TestMethod]
        public void GetClientById_ThrowsException_InvalidId()
        {
            clientsService = new ClientsService(clientRepositoryMock.Object, ticketHolderRepositoryMock.Object,
               reservationRepositoryMock.Object, flightRepositoryMock.Object);

            var invalidClientId = "invalid";
            Assert.ThrowsException<Exception>(() =>
            {
                clientsService.GetClientById(invalidClientId);
            });
        }

        [TestMethod]
        public void GetClientById_ThrowsEntityNotFound_ClientDoesntExist()
        {
            var nonExistingClient = Guid.NewGuid().ToString();
            var existingClient = Guid.NewGuid();

            var client = new Client
            {
                Id = existingClient,
                FirstName = "firstName",
                LastName = "lastName"
            };

            clientRepositoryMock.Setup(clientRepositoryMock => clientRepositoryMock.GetClientByUserId(existingClient)).Returns(client);

            clientsService = new ClientsService(clientRepositoryMock.Object, ticketHolderRepositoryMock.Object,
               reservationRepositoryMock.Object, flightRepositoryMock.Object);

            Assert.ThrowsException<EntityNotFoundException>(() =>
            {
                clientsService.GetClientById(nonExistingClient);
            });
        }

        [TestMethod]
        public void GetClientById_Returns_ClientExists()
        {
            var existingClientId = Guid.NewGuid();

            var client = new Client
            {
                Id = existingClientId,
                UserId = Guid.NewGuid(),
                FirstName = "firstName",
                LastName = "lastName"
            };

            clientRepositoryMock.Setup(clientRepositoryMock => clientRepositoryMock.GetClientByUserId(existingClientId)).Returns(client);

            clientsService = new ClientsService(clientRepositoryMock.Object, ticketHolderRepositoryMock.Object,
               reservationRepositoryMock.Object, flightRepositoryMock.Object);

            var searchedClient = clientsService.GetClientById(existingClientId.ToString());

            Assert.IsNotNull(searchedClient);
        }

        [TestMethod]
        public void ClientEditAccount_ClientDoesntExist()
        {
            var existingClientId = Guid.NewGuid();

            var client = new Client
            {
                Id = existingClientId,
                UserId = Guid.NewGuid(),
                FirstName = "firstName",
                LastName = "lastName",
                PhoneNo = "0771234567",
                Address = "street x nr 5"
            };

            clientsService = new ClientsService(clientRepositoryMock.Object, ticketHolderRepositoryMock.Object,
               reservationRepositoryMock.Object, flightRepositoryMock.Object);
            Assert.ThrowsException<NullReferenceException>(() =>
            {
                clientsService.EditAccount(existingClientId, "firstName", "lastName", "0771234567", "street x nr 5");
            });
        }

        //GetReservations - Method
        [TestMethod]
        public void GetReservations()
        {
            clientsService = new ClientsService(clientRepositoryMock.Object, ticketHolderRepositoryMock.Object,
               reservationRepositoryMock.Object, flightRepositoryMock.Object);

            Assert.IsNotNull(clientsService.GetReservations());
        }

        [TestMethod]
        public void GetReservations_ThrowsNullReferenceException()
        {
            Assert.ThrowsException<NullReferenceException>(() =>
            {
                clientsService.GetReservations();
            });
        }

        [TestMethod]
        public void BuyTicket_Returns_FlightExists()
        {
            var existingClientId = Guid.NewGuid();

            var client = new Client
            {
                Id = existingClientId,
                UserId = Guid.NewGuid(),
                FirstName = "firstName",
                LastName = "lastName"
            };

            var existingFlight = Guid.NewGuid();

            var flight = new Flight
            {
                Id = existingFlight,
                FlightNo = "default",
                BusinessPrice = 10,
                EconomyPrice = 10
            };

            flightRepositoryMock.Setup(flightRepositoryMock => flightRepositoryMock.GetFlightByID(existingFlight)).Returns(flight);

            var existingTicketHolder = Guid.NewGuid();

            var ticketHolder = new TicketHolder
            {
                Id = Guid.NewGuid(),
                FirstName = "firstName",
                LastName = "lastName",
                Nationality = "nationality",
                CI_Passport = "cI_Passport"
            };

            var existingReservation = Guid.NewGuid();

            var reservation = new Reservation
            {
                Id = Guid.NewGuid(),
                Client = client,
                TicketHolder = ticketHolder,
                Seat = 32
            };

            flightRepositoryMock.Setup(flightRepositoryMock => flightRepositoryMock.GetById(existingFlight)).Returns(flight);

            clientsService = new ClientsService(clientRepositoryMock.Object, ticketHolderRepositoryMock.Object,
               reservationRepositoryMock.Object, flightRepositoryMock.Object);
            adminsService = new AdminsService(adminRepositoryMock.Object, flightRepositoryMock.Object,
               planeTypeRepositoryMock.Object, flightScheduleRepositoryMock.Object, reservationRepositoryMock.Object);

            var searchedFlightToBuyTicket = adminsService.GetFlightById(existingFlight);

            Assert.IsNotNull(searchedFlightToBuyTicket);
        }

        [TestMethod]
        public void BuyTicket_Returns_Flight_Doesnt_Exist()
        {
            var existingClientId = Guid.NewGuid();

            var client = new Client
            {
                Id = existingClientId,
                UserId = Guid.NewGuid(),
                FirstName = "firstName",
                LastName = "lastName"
            };

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

            var existingTicketHolder = Guid.NewGuid();

            var ticketHolder = new TicketHolder
            {
                Id = Guid.NewGuid(),
                FirstName = "firstName",
                LastName = "lastName",
                Nationality = "nationality",
                CI_Passport = "cI_Passport"
            };

            var existingReservation = Guid.NewGuid();

            var reservation = new Reservation
            {
                Id = Guid.NewGuid(),
                Client = client,
                TicketHolder = ticketHolder,
                Seat = 32
            };

            flightRepositoryMock.Setup(flightRepositoryMock => flightRepositoryMock.GetById(existingFlight)).Returns(flight);

            clientsService = new ClientsService(clientRepositoryMock.Object, ticketHolderRepositoryMock.Object,
               reservationRepositoryMock.Object, flightRepositoryMock.Object);
            adminsService = new AdminsService(adminRepositoryMock.Object, flightRepositoryMock.Object,
               planeTypeRepositoryMock.Object, flightScheduleRepositoryMock.Object, reservationRepositoryMock.Object);

            Assert.ThrowsException<EntityNotFoundException>(() =>
            {
                adminsService.GetFlightById(Guid.Parse(nonExistingFlight));
            });
        }
    }
}

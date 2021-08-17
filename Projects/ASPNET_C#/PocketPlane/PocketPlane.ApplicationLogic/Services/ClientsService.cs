using PocketPlane.ApplicationLogic.Exceptions;
using PocketPlane.ApplicationLogic.Abstractions;
using PocketPlane.ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace PocketPlane.ApplicationLogic.Services
{
    public class ClientsService
    {
        private IClientRepository clientRepository;
        private ITicketHolderRepository ticketHolderRepository;
        private IReservationRepository reservationRepository;
        private IFlightRepository flightRepository;

        public ClientsService(IClientRepository clientRepository, ITicketHolderRepository ticketHolderRepository,
                        IReservationRepository reservationRepository, IFlightRepository flightRepository)
        {
            this.clientRepository = clientRepository;
            this.ticketHolderRepository = ticketHolderRepository;
            this.reservationRepository = reservationRepository;
            this.flightRepository = flightRepository;
        }

        public Client CreateClient(string userId, string firstName, string lastName, string email, string phoneNo,
                                    string adress, string cI_passport)
        {
            var client = new Client
            {
                UserId = Guid.Parse(userId),
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNo = phoneNo,
                Address = adress,
                CI_Passport = cI_passport
            };
            clientRepository.Add(client);
            return client;
        }

        public Client GetClientById(string clientId)
        {
            Guid clientIdGuid = Guid.Empty;
            if (!Guid.TryParse(clientId, out clientIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }

            var client = clientRepository.GetClientByUserId(clientIdGuid);
            if (client == null)
            {
                throw new EntityNotFoundException(clientIdGuid);
            }

            return client;

        }

        public void BuyTicket(Guid FlightId, int seat, string firstName, string lastName, string nationality,
                               string cI_Passport, string clientID)
        {

            Guid clientIdGuid = Guid.Empty;
            if (!Guid.TryParse(clientID, out clientIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }
            var client = clientRepository.GetClientByUserId(clientIdGuid);
            if (client == null)
            {
                throw new EntityNotFoundException(clientIdGuid);
            }
            var flight = flightRepository.GetFlightByID(FlightId);

            var ticketHolder = ticketHolderRepository.Add(new TicketHolder()
            {
                Id = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                Nationality = nationality,
                CI_Passport = cI_Passport
            });

            var reservation = reservationRepository.Add(new Reservation()
            {
                Id = Guid.NewGuid(),
                Client = client,
                TicketHolder = ticketHolder,
                Seat = seat,
            });

            if (flight != null)
            {
                //if(flight.Reservations == null)
                //{
                //    var res = new ICollection<Reservation>();
                //    flight.Reservations = res;
                //}
                flight.Reservations.Add(reservation);
                flightRepository.Update(flight);
            }
        }

        public IEnumerable<Reservation> GetReservations()
        {
            return reservationRepository.GetAllReservations();

        }

        public void EditAccount(Guid userId, string firstName, string lastName,
                                string phoneNo, string address)
        {

            var client = clientRepository.GetClientByUserId(userId);

            client.FirstName = firstName;
            client.LastName = lastName;
            client.PhoneNo = phoneNo;
            client.Address = address;

            clientRepository.Update(client);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PocketPlane.ApplicationLogic.DataModel;
using PocketPlane.ApplicationLogic.Services;
using PocketPlane.DataAccess;
using PocketPlane.Models.Admins;
using PocketPlane.Models.Clients;

namespace PocketPlane.Controllers
{
    [Authorize(Roles = "Client")]
    public class ClientsController : Controller
    {
        private readonly ClientsService clientsService;
        private readonly AdminsService adminsService;
        private readonly UserManager<IdentityUser> _userManager;

        public ClientsController(ClientsService clientsService, AdminsService adminsService, 
                                UserManager<IdentityUser> userManager)
        {
            this.clientsService = clientsService;
            this.adminsService = adminsService;
            _userManager = userManager;
        }

        public ActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                return BadRequest("Invalid request received ");
            }
        }

        [HttpGet]
        public IActionResult SearchFlights(string searchBy, string search)
        {
            switch (searchBy)
            {
                case "FlightNO":
                    return View(new ClientSearchFlightsViewModel { Flights = adminsService.GetFlightByNO(search) });
                case "BusinessPrice":
                    return View(new ClientSearchFlightsViewModel { Flights = adminsService.GetFlightByBusinessPrice(search) });
                case "DepartureCity":
                    return View(new ClientSearchFlightsViewModel { Flights = adminsService.GetFlightByDepartureCity(search) });
                case "ArrivalCity":
                    return View(new ClientSearchFlightsViewModel { Flights = adminsService.GetFlightByArrivalCity(search) });
                default:
                    var flights = adminsService.GetFutureFlights();
                    return View(new ClientSearchFlightsViewModel { Flights = flights });
            }
        }

        [HttpGet]
        public IActionResult BuyTicket(Guid Id)
        {
            var flight = adminsService.GetFlightById(Id);
            ClientBuyTicketViewModel clientBuyTicketViewModel = new ClientBuyTicketViewModel
            {
                FlightId = flight.Id,
                FlightNo = flight.FlightNo,
                BusinessPrice = flight.BusinessPrice,
                EconomyPrice = flight.EconomyPrice,
                DepartureDate = flight.FlightSchedule.DepartureDate,
                DepartureCity = flight.FlightSchedule.DepartureCity,
                DepartureAirport = flight.FlightSchedule.DepartureAirport,
                DepartureHour = flight.FlightSchedule.DepartureHour,
                ArrivalDate = flight.FlightSchedule.ArrivalDate,
                ArrivalAirport = flight.FlightSchedule.ArrivalAirport,
                ArrivalCity = flight.FlightSchedule.ArrivalCity,
                ArrivalHour = flight.FlightSchedule.ArrivalHour
            };
            return View(clientBuyTicketViewModel);
        }

        public IActionResult BuyTicket([FromForm]ClientBuyTicketViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var userId = _userManager.GetUserId(User);
            clientsService.BuyTicket(model.FlightId, model.Seat, model.FirstName, model.LastName, model.Nationality,
                                        model.CI_Passport, userId);
            return Redirect(Url.Action("Index", "Clients"));

        }


        [HttpGet]
        public IActionResult Reservations()
        {
            try
            {
                var reservations = clientsService.GetReservations();

                return View(new ClientReservationsViewModel { Reservations = reservations });
            }
            catch (Exception)
            {
                return BadRequest("Invalid request received ");
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditAccount()
        {
            var userId = _userManager.GetUserId(User);

            var user_identity = await _userManager.FindByIdAsync(userId);
            var user_email = await _userManager.GetEmailAsync(user_identity);
            var user_username = await _userManager.GetUserNameAsync(user_identity);

            var client = clientsService.GetClientById(userId);

            ClientEditAccountViewModel clientEditAccountViewModel = new ClientEditAccountViewModel
            {
                UserId = userId,
                FirstName = client.FirstName,
                LastName = client.LastName,
                PhoneNo = client.PhoneNo,
                Address = client.Address,
                Email = user_email,
                Username = user_username
            };
            return View(clientEditAccountViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditAccount([FromForm]ClientEditAccountViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user_identity = await _userManager.FindByIdAsync(model.UserId);
            user_identity.Email = model.Email;
            user_identity.UserName = model.Username;

            var result = await _userManager.UpdateAsync(user_identity);

            Guid clientIdGuid = Guid.Empty;
            if (!Guid.TryParse(model.UserId, out clientIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }


            clientsService.EditAccount(clientIdGuid, model.FirstName, model.LastName,
                                         model.PhoneNo, model.Address);
            return Redirect(Url.Action("Index", "Clients"));
        }

    }
}

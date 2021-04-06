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

namespace PocketPlane.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminsController : Controller
    {
        private readonly AdminsService adminsService;
        private readonly UserManager<IdentityUser> _userManager;

        public AdminsController(AdminsService adminsService, UserManager<IdentityUser> userManager)
        {
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
        public IActionResult AddPlaneType()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddPlaneType([FromForm]AdminAddPlaneTypeViewModel modelPlaneType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            adminsService.AddPlaneType(modelPlaneType.Model, modelPlaneType.Manufacturer, 
                                    modelPlaneType.CapacityBusiness, modelPlaneType.CapacityEconomy);
            return Redirect(Url.Action("Index", "Admins"));

        }

        [HttpGet]
        public IActionResult AddFlight()
        {
            var planeTypes = adminsService.GetPlaneTypes();
            AdminAddFlightViewModel adminAddFlightViewModel = new AdminAddFlightViewModel
            {
                PlaneTypes = new SelectList(planeTypes, "Id", "Model")
            };
            return View(adminAddFlightViewModel);
        }

        public IActionResult AddFlight([FromForm]AdminAddFlightViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var userId = _userManager.GetUserId(User);
            adminsService.AddFlight( model.FlightNo, model.BusinessPrice, model.EconomyPrice,
                                        model.DepartureDate, model.DepartureCity, model.DepartureAirport, model.DepartureHour,
                                        model.ArrivalDate, model.ArrivalCity, model.ArrivalAirport, model.ArrivalHour,
                                        model.PlaneType, userId);
            return Redirect(Url.Action("Index", "Admins"));

        }

        
        public IActionResult DeleteFlight(Guid Id)
        {
            var flight = adminsService.GetFlightById(Id);
            if (flight == null)
            {
                return BadRequest("Flight not found");
            }
            else
            {
                var result = adminsService.DeleteFlight(flight);
                return Redirect(Url.Action("FutureFlights", "Admins"));

            }

        }


        [HttpGet]
        public IActionResult EditFlight(Guid Id) 
        {
            var flight = adminsService.GetFlightById(Id);
            AdminEditFlightViewModel adminEditFlightViewModel = new AdminEditFlightViewModel
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
            return View(adminEditFlightViewModel);
        }
        [HttpPost]
        public IActionResult EditFlight([FromForm]AdminEditFlightViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            adminsService.EditFlight(model.FlightId, model.FlightNo, model.BusinessPrice, 
                                         model.EconomyPrice,model.DepartureDate, model.DepartureCity,
                                         model.DepartureAirport, model.DepartureHour,
                                        model.ArrivalDate, model.ArrivalCity, 
                                        model.ArrivalAirport, model.ArrivalHour
                                        );
            return Redirect(Url.Action("Index", "Admins"));
        }


        [HttpGet]
        public IActionResult DetailsFlight(Guid Id)
        {
            var flight = adminsService.GetFlightById(Id);
            AdminDetailsFlightViewModel adminDetailsFlightViewModel = new AdminDetailsFlightViewModel
            {
                Flight = flight
            };
            return View(adminDetailsFlightViewModel);
        }


        [HttpGet]
        public IActionResult FutureFlights()
        {
            try
            {

                var future_flights = adminsService.GetFutureFlights();

                return View(new AdminFutureFlightsViewModel { FutureFlights = future_flights });
            }
            catch (Exception)
            {
                return BadRequest("Invalid request received ");
            }
        }

        [HttpGet]
        public IActionResult PastFlights()
        {
            try
            {

                var past_flights = adminsService.GetPastFlights();

                return View(new AdminPastFlightsViewModel { PastFlights = past_flights });
            }
            catch (Exception)
            {
                return BadRequest("Invalid request received ");
            }
        }

        [HttpGet]
        public IActionResult PlaneTypes()
        {
            try
            {

                var planeTypes = adminsService.GetPlaneTypes();

                return View(new AdminPlaneTypesViewModel { PlaneTypes = planeTypes });
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

            var admin = adminsService.GetAdminById(userId);

            AdminEditAccountViewModel adminEditAccountViewModel = new AdminEditAccountViewModel
            {
                UserId = userId,
                FirstName = admin.FirstName,
                LastName = admin.LastName,
                Email = user_email,
                Username = user_username
            };
            return View(adminEditAccountViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditAccount([FromForm]AdminEditAccountViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user_identity = await _userManager.FindByIdAsync(model.UserId);
            user_identity.Email = model.Email;
            user_identity.UserName = model.Username;

            var result = await _userManager.UpdateAsync(user_identity);

            Guid adminIdGuid = Guid.Empty;
            if (!Guid.TryParse(model.UserId, out adminIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }


            adminsService.EditAccount(adminIdGuid, model.FirstName, model.LastName);
            return Redirect(Url.Action("Index", "Admins"));
        }

        
    }
}

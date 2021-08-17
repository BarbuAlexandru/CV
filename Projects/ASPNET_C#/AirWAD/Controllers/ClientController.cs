using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirWAD.Models.DataBase;
using AirWAD.Services;
using AirWAD.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AirWAD.Controllers
{
    public class ClientController : Controller
    {

        private readonly ClientService clientService;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public ClientController(ClientService clientService, SignInManager<IdentityUser> _signInManager, UserManager<IdentityUser> userManager)
        {
            this.clientService = clientService;
            this._signInManager = _signInManager;
            this._userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> WelcomeAsync()
        {
            await _signInManager.SignOutAsync();
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Home()
        {
            var news = clientService.GetNews();
            var reservations = clientService.GetReservations();
            return View(new HomeViewModel { News = news,
                Reservations = reservations,
                Listings = clientService.GetListings()
            });
        }

        [HttpGet]
        public IActionResult AddNews()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddRental()
        {
            return View();
        }

        [HttpGet]
        public IActionResult BoughtRentals()
        {
            var reservations = clientService.GetReservations();
            return View(new BoughtRentalsViewModel { Reservations = reservations });
        }



        [HttpGet]
        public IActionResult SearchRentals(string searchBy, string search)
        {
            SearchRentalsViewModel searchRentalsViewModel;

            switch (searchBy)
            {
                case "City":
                    if (search != null)
                    {
                        searchRentalsViewModel = new SearchRentalsViewModel
                        {
                            Listings = clientService.GetListingsByCity(search)
                        };
                    }
                    else
                    {
                        searchRentalsViewModel = new SearchRentalsViewModel
                        {
                            Listings = clientService.GetListings()
                        };
                    }
                    return View(searchRentalsViewModel);
                case "Price":
                    if (search != null)
                    {
                        searchRentalsViewModel = new SearchRentalsViewModel
                        {
                            Listings = clientService.GetListingsByPrice(search)
                        };
                    }
                    else
                    {
                        searchRentalsViewModel = new SearchRentalsViewModel
                        {
                            Listings = clientService.GetListings()
                        };
                    }
                    return View(searchRentalsViewModel);
                default:
                    searchRentalsViewModel = new SearchRentalsViewModel
                    {
                        Listings = clientService.GetListings()
                    };
                    return View(searchRentalsViewModel);
            }
        }


        [HttpGet]
        public IActionResult Default()
        {
            return View();
        }

        public IActionResult AddNews([FromForm]AddNewsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var userId = _userManager.GetUserId(User);
            clientService.AddNews(model.Title, model.Content, userId);

            return Redirect(Url.Action("Home", "Client"));
        }

        [HttpGet]
        public IActionResult DeleteNews(Guid Id)
        {
            clientService.DeleteNews(Id);
            return Redirect(Url.Action("Home", "Client"));
        }

        public IActionResult AddRental([FromForm]AddRentalViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var userId = _userManager.GetUserId(User);
            clientService.AddRental(model.City, model.Address, model.StartDate, model.EndDate, model.Description, model.Price, userId);

            return Redirect(Url.Action("Home", "Client"));
        }

        [HttpGet]
        public IActionResult DeleteRental(Guid Id)
        {
            clientService.DeleteRental(Id);
            return Redirect(Url.Action("SearchRentals", "Client"));
        }

        [HttpGet]
        public IActionResult DeleteListing(Guid Id)
        {
            clientService.DeleteListing(Id);
            return Redirect(Url.Action("SearchRentals", "Client"));
        }

        [HttpGet]
        public IActionResult BuyListing(Guid Id)
        {
            clientService.AddReservation(Id);
            return Redirect(Url.Action("BoughtRentals", "Client"));
        }
    }
}
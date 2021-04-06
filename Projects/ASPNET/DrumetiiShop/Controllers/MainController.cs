using DrumetiiShop.Models;
using DrumetiiShop.Services;
using DrumetiiShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DrumetiiShop.Controllers
{
    public class MainController : Controller
    {
        private readonly MainService mainService;

        private readonly ILogger<MainController> _logger;

        public MainController(ILogger<MainController> logger, MainService mainService)
        {
            _logger = logger;
            this.mainService = mainService;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //Implemented Auctions

        [HttpGet]
        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Home(string searchString)
        {
            if (Program.currentUser != null)
            {
                Program.currentUserNoProducts = mainService.NoProductsInCart(Program.currentUser);
            }
            var products = mainService.GetAllProducts();

            List<string> allProductNames = new List<string>();
            List<Product> searchedProducts = new List<Product>();
            foreach (var product in products)
            {
                allProductNames.Add(product.Name);
                if (searchString != null)
                {
                    //search for products that have searchString in their name
                    if (product.Name.ToUpper().Contains(searchString.ToUpper()))
                    {
                        searchedProducts.Add(product);
                    }
                }
            }
            if (searchString != null)
            {
                products = searchedProducts;
            }

            return View(new HomeViewModel
            {
                Products = products,
                AllProductNames = allProductNames,
                Categories = mainService.GetAllProductCategories(products),
                SearchedText = searchString
            });
        }

        [HttpGet]
        public IActionResult Logout()
        {
            Program.ClearCurrentUser();
            return Redirect(Url.Action("Home", "Main"));
        }

        [HttpGet]
        public IActionResult PleaseLogin()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Register([FromForm] RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (mainService.GetUserByEmail(model.Email) != null)
            {
                return Redirect(Url.Action("Register", "Main"));
            }
            if (model.Password != model.ConfirmPassword)
            {
                return Redirect(Url.Action("Register", "Main"));
            }
            var user = mainService.RegisterUser(model.Email, model.Password);
            Program.ActualizeCurrentUser(user);
            mainService.CreateCartForUser(user);
            return Redirect(Url.Action("Home", "Main"));
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Login([FromForm] LoginViewModel model)
        {
            var user = mainService.GetUserByEmail(model.Email);
            if (user == null)
            {
                return Redirect(Url.Action("Login", "Main"));
            }
            if (user.Password != model.Password)
            {
                return Redirect(Url.Action("Login", "Main"));
            }
            Program.ActualizeCurrentUser(user);
            mainService.CreateCartForUser(user);
            return Redirect(Url.Action("Home", "Main"));
        }

        [HttpGet]
        public IActionResult Account()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddProductToCart(int Id)
        {
            if (Program.currentUser != null)
            {
                mainService.AddProductToCart(Program.currentUser, Id);
                return Redirect(Url.Action("Home", "Main"));
            }
            return Redirect(Url.Action("PleaseLogin", "Main"));
        }

        [HttpGet]
        public IActionResult Cart()
        {
            Program.currentUserNoProducts = mainService.NoProductsInCart(Program.currentUser);
            List<ProductCartInfo> productCartInfos = new List<ProductCartInfo>();
            foreach (CartProductConnection connection in mainService.GetAllProductConnectionsOfCart(mainService.GetUsersCart(Program.currentUser)))
            {
                productCartInfos.Add(new ProductCartInfo() {
                    Product = mainService.GetProductById(connection.ProductId),
                    NrOfProducts = connection.NrOfProducts
                });
            }
            return View(new CartViewModel
            {
                ProductCartInfos = productCartInfos
            });
        }

        [HttpGet]
        public IActionResult DeleteProductFromCart(int Id)
        {
            mainService.DeleteCartProductConnection(Program.currentUser, Id);
            return Redirect(Url.Action("Cart", "Main"));
        }

        [HttpGet]
        public IActionResult AddProductFromCart(int Id)
        {
            mainService.AddProductToCart(Program.currentUser, Id);
            return Redirect(Url.Action("Cart", "Main"));
        }

        [HttpGet]
        public IActionResult CartCheckout()
        {
            mainService.DeleteCartProductConnection(Program.currentUser);
            return Redirect(Url.Action("Cart", "Main"));
        }
        
        [HttpGet]
        public IActionResult SeeProduct(int Id)
        {
            if (Program.currentUser != null)
            {
                Program.currentUserNoProducts = mainService.NoProductsInCart(Program.currentUser);
            }
            return View(new SeeProductViewModel
            {
                Product = mainService.GetProductById(Id)
            });
        }

        [HttpGet]
        public IActionResult AddProductToCartSeeProduct(int Id)
        {
            if (Program.currentUser != null)
            {
                mainService.AddProductToCart(Program.currentUser, Id);
                return Redirect(Url.Action("SeeProduct", "Main", new { Id }));
            }
            return Redirect(Url.Action("PleaseLogin", "Main"));
        }
    }
}

using DrumetiiShop.Models;
using DrumetiiShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrumetiiShop.Services
{
    public class MainService
    {
        //Repositories

        private readonly IUserRepository userRepository;
        private readonly ICartRepository cartRepository;
        private readonly ICartProductConnectionRepository cartProductConnectionRepository;
        private readonly IProductRepository productRepository;

        //Constructor

        public MainService(IUserRepository userRepository, ICartRepository cartRepository, ICartProductConnectionRepository cartProductConnectionRepository, IProductRepository productRepository)
        {
            this.userRepository = userRepository;
            this.cartRepository = cartRepository;
            this.cartProductConnectionRepository = cartProductConnectionRepository;
            this.productRepository = productRepository;
        }

        // Services

        public IEnumerable<Product> GetAllProducts()
        {
            return productRepository.GetAll();
        }

        public Product GetProductById(int id)
        {
            return productRepository.GetById(id);
        }

        public IEnumerable<string> GetAllProductCategories(IEnumerable<Product> products)
        {
            List<string> categories = new List<string>();
            foreach (Product product in products)
            {
                if (!categories.Contains(product.Category))
                {
                    categories.Add(product.Category);
                }
            }
            return categories;
        }
        
        public User RegisterUser(string email, string password)
        {
            var user = userRepository.Add( new User()
            {
                Id = Guid.NewGuid(),
                Email = email,
                Password = password,
                Role = "Client"
            });
            return user;
        }

        public User GetUserByEmail(string email)
        {
            var users = userRepository.GetAll();
            foreach (User user in users)
            {
                if(user.Email == email)
                {
                    return user;
                }
            }
            return null;
        }

        public Cart GetUsersCart(User user)
        {
            var carts = cartRepository.GetAll();
            foreach (Cart cart in carts)
            {
                if (cart.UserId == user.Id)
                {
                    return cart;
                }
            }
            return null;
        }

        public void CreateCartForUser(User user)
        {
            if (GetUsersCart(user)!=null)
            {
                return;
            }
            var newCart = cartRepository.Add(new Cart()
            {
                Id = Guid.NewGuid(),
                UserId = user.Id
            });
        }

        public void DeleteUsersCart(User user)
        {
            var cart = GetUsersCart(user);
            if (cart == null)
            {
                return;
            }
            var connections = GetAllProductConnectionsOfCart(cart);
            foreach(var connection in connections)
            {
                cartProductConnectionRepository.Delete(connection);
            }
            cartRepository.Delete(cart);
        }

        public List<CartProductConnection> GetAllProductConnectionsOfCart(Cart cart)
        {
            List<CartProductConnection> allCartProductConnections = cartProductConnectionRepository.GetAll().ToList();
            List<CartProductConnection> cartProductConnections = new List<CartProductConnection>();
            foreach (CartProductConnection connection in allCartProductConnections)
            {
                if (connection.CartId == cart.Id)
                {
                    cartProductConnections.Add(connection);
                }
            }
            return cartProductConnections;
        }

        public int NoProductsInCart(User user)
        {
            int noProducts=0;
            List<CartProductConnection> cartProductConnections = GetAllProductConnectionsOfCart(GetUsersCart(user));
            foreach(CartProductConnection connection in cartProductConnections)
            {
                noProducts += connection.NrOfProducts;
            }
            return noProducts;
        }

        public void AddProductToCart(User user, int productId)
        {
            var cart = GetUsersCart(user);
            List<CartProductConnection> cartProductConnections = GetAllProductConnectionsOfCart(cart);
            foreach (CartProductConnection connection in cartProductConnections)
            {
                if(connection.ProductId == productId)
                {
                    int noOfProductsInConnection = connection.NrOfProducts;
                    cartProductConnectionRepository.Delete(connection);
                    var newCartProductConnection1 = cartProductConnectionRepository.Add(new CartProductConnection()
                    {
                        Id = Guid.NewGuid(),
                        NrOfProducts = noOfProductsInConnection+1,
                        ProductId = productId,
                        CartId = cart.Id
                    });
                    return;
                }
            }
            var newCartProductConnection2 = cartProductConnectionRepository.Add(new CartProductConnection()
            {
                Id = Guid.NewGuid(),
                NrOfProducts = 1,
                ProductId = productId,
                CartId = cart.Id
            });
            return;
        }

        public void DeleteCartProductConnection(User user, int idProduct)
        {
            var connections = GetAllProductConnectionsOfCart(GetUsersCart(user));
            foreach (var connection in connections)
            {
                if(connection.ProductId == idProduct)
                {
                    cartProductConnectionRepository.Delete(connection);
                }
            }
        }
        
        public void DeleteCartProductConnection(Product product)
        {
            cartProductConnectionRepository.DeleteCartProductConnectionOfProduct(product.Id);
        }

        public void DeleteCartProductConnection(User user)
        {
            var connections = GetAllProductConnectionsOfCart(GetUsersCart(user));
            foreach (var connection in connections)
            {
                cartProductConnectionRepository.Delete(connection);
            }
        }
    }
}
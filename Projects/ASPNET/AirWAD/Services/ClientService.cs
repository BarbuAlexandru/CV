using AirWAD.Models.DataBase;
using AirWAD.Repository.Abstraction;
using AirWAD.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirWAD.Services
{
    public class ClientService
    {
        private readonly INewsRepository newsRepository;
        private readonly IUserRepository userRepository;
        private readonly IRentalRepository rentalRepository;
        private readonly IListingRepository listingRepository;
        private readonly IReservationRepository reservationRepository;

        public ClientService(INewsRepository newsRepository, IUserRepository userRepository,
            IRentalRepository rentalRepository, IListingRepository listingRepository, IReservationRepository reservationRepository)
        {
            this.newsRepository = newsRepository;
            this.userRepository = userRepository;
            this.rentalRepository = rentalRepository;
            this.listingRepository = listingRepository;
            this.reservationRepository = reservationRepository;
        }


        public void AddNews(string title, string content, string userId)
        {
            var news = newsRepository.Add(new News()
            {
                Id = Guid.NewGuid(),
                Title = title,
                Content =content,
                User = userRepository.GetUserById(userId)
            });
        }

        public IEnumerable<News> GetNews()
        {
            return newsRepository.GetAll();
        }

        public void DeleteNews(Guid id)
        {
            var news = newsRepository.GetById(id);
            var executed = newsRepository.Delete(news);
        }

        public void AddRental(string city, string address, DateTime startDate,
            DateTime endDate, string description, int price, string userId)
        {
            var rental = rentalRepository.Add(new Rental()
            {
                Id = Guid.NewGuid(),
                City = city,
                Address = address,
                Description = description
            });

            var listing = listingRepository.Add(new Listing()
            {
                Id = Guid.NewGuid(),
                StartDate = startDate,
                EndDate = endDate,
                Price = price,
                RentalID = rental.Id,
                User = userRepository.GetUserById(userId),
                Rental = rental
            });
        }

        public IEnumerable<Listing> GetListings()
        {
            IEnumerable<Listing> listings = listingRepository.GetListings();
            return listings;
        }

        public IEnumerable<Rental> GetRentals()
        {
            IEnumerable<Rental> rentals = rentalRepository.GetAll();
            return rentals;
        }

        public void DeleteRental(Guid id)
        {
            var rental = rentalRepository.GetById(id);
            var executed = rentalRepository.Delete(rental);
        }

        public void DeleteListing(Guid id)
        {
            var listing = listingRepository.GetById(id);
            var executed = listingRepository.Delete(listing);
        }

        public void AddReservation(Guid id)
        {
            var listing = listingRepository.GetById(id);

            var reservation = reservationRepository.Add(new Reservation
            {
                Id = Guid.NewGuid(),
                Price = listing.Price,
                StartDate=listing.StartDate,
                EndDate = listing.EndDate,
                Rental = listing.Rental,
                RentalID = listing.RentalID
            });
        }

        public IEnumerable<Reservation> GetReservations()
        {
            IEnumerable<Reservation> reservations = reservationRepository.GetReservations();
            return reservations;
        }

        public IEnumerable<Listing> GetListingsByPrice(string price)
        {
            IEnumerable<Listing> listings = listingRepository.GetListingByPrice(Int32.Parse(price));
            return listings;
        }

        public IEnumerable<Listing> GetListingsByCity(string city)
        {
            IEnumerable<Listing> listings = listingRepository.GetListingByCity(city);
            return listings;
        }

        public IEnumerable<Listing> GetAListing()
        {
            return listingRepository.GetAListing();
        }
    }
}

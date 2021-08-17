using AirWAD.Models.DataBase;
using AirWAD.Repository.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirWAD.Repository.Implementation
{
    public class ListingRepository : BaseRepository<Listing>, IListingRepository
    {
        public ListingRepository(AirWADContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Listing> GetListingByPrice(int price)
        {
            return dbContext.Listings
                .Where(x => x.Price <= price)
                .Include(flight => flight.Rental)
                .AsEnumerable();
        }

        public IEnumerable<Listing> GetListingByCity(string city)
        {
            return dbContext.Listings
                .Where(x => x.Rental.City==city)
                .Include(flight => flight.Rental)
                .AsEnumerable();
        }

        public IEnumerable<Listing> GetListings()
        {
            return dbContext.Listings.Where(x => x.Id != null)
                           .Include(listing => listing.Rental)
                           .AsEnumerable();
        }

        public IEnumerable<Listing> GetAListing()
        {
            return (IEnumerable<Listing>)dbContext.Listings.Where(x => x.Id != null)
                           .Include(listing => listing.Rental)
                           .AsEnumerable().FirstOrDefault();
        }
    }
}
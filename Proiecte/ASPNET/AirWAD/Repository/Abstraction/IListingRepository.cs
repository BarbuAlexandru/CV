using AirWAD.Models.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirWAD.Repository.Abstraction
{
    public interface IListingRepository : IRepository<Listing>
    {
        IEnumerable<Listing> GetListingByPrice(int price);

        IEnumerable<Listing> GetListingByCity(string city);

        IEnumerable<Listing> GetListings();

        IEnumerable<Listing> GetAListing();
    }
}

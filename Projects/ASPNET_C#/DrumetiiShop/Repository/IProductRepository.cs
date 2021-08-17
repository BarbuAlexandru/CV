using DrumetiiShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrumetiiShop.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        Product GetById(int Id);
    }
}

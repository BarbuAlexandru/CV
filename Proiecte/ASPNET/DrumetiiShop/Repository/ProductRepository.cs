using DrumetiiShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrumetiiShop.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DrumetiiShopDbContext dbContext) : base(dbContext)
        {

        }

        public Product GetById(int Id)
        {
            return dbContext.Set<Product>().Find(Id);
        }
    }
}

using DrumetiiShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrumetiiShop.Repository
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        public CartRepository(DrumetiiShopDbContext dbContext) : base(dbContext)
        {

        }
    }
}

using DrumetiiShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrumetiiShop.Repository
{
    public class CartProductConnectionRepository : Repository<CartProductConnection>, ICartProductConnectionRepository
    {
        public CartProductConnectionRepository(DrumetiiShopDbContext dbContext) : base(dbContext)
        {

        }

        public bool DeleteCartProductConnectionOfProduct(int Id)
        {
            var list = dbContext.CartProductConnections.Where(c => c.ProductId == Id).ToList();
            dbContext.RemoveRange(list);
            dbContext.SaveChanges();
            return true;
        }
    }
}

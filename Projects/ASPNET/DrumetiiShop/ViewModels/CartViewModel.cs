using DrumetiiShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrumetiiShop.ViewModels
{
    public class ProductCartInfo
    {
        public Product Product { get; set; }
        public int NrOfProducts { get; set; }

        public int TotalPrice()
        {
            return Product.Price * NrOfProducts;
        }
    }

    public class CartViewModel
    {
        public List<ProductCartInfo> ProductCartInfos { get; set; }

        public int TotalPrice()
        {
            int totalPrice = 0;
            foreach (var productCartInfo in ProductCartInfos)
            {
                totalPrice += productCartInfo.TotalPrice();
            }
            return totalPrice;
        }
    }
}

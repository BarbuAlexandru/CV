using DrumetiiShop.Models;
using System.Collections.Generic;

namespace DrumetiiShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<string> AllProductNames { get; set; }
        public IEnumerable<string> Categories { get; set; }
        public string SearchedText { get; set; }
    }
}

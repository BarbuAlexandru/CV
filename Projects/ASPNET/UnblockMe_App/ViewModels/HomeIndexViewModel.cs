using System.Collections.Generic;
using UnblockMe_App.Models;

namespace UnblockMe_App.ViewModels
{
    public class HomeIndexViewModel
    {
        public string SearchedText { get; set; }
        public List<Car> FoundCars { get; set; }
        public User CurrentUser { get; set; }

        public HomeIndexViewModel(string searchedText, List<Car> foundCars, User currentUser) {
            this.SearchedText = searchedText;
            this.FoundCars = foundCars;
            this.CurrentUser = currentUser;
        }
    }
}

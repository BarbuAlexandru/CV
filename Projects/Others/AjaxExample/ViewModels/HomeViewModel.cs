using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AjaxExample.ViewModels
{
    public class HomeViewModel
    {
        public string Location { get; set; }
        public string Booth { get; set; }

        public HomeViewModel(string location, string booth)
        {
            Location = location;
            Booth = booth;
        }
    }
}

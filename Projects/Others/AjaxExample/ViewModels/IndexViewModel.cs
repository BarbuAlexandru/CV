using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AjaxExample.ViewModels
{
    public class IndexViewModel
    {
        public List<string> Locations { get; set; }

        public IndexViewModel(List<string> Locations)
        {
            this.Locations = Locations;
        }
    }
}

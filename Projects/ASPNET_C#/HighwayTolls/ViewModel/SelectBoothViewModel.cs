using HighwayTolls.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HighwayTolls.ViewModel
{
    public class SelectBoothViewModel
    {
        public List<TollLocation> TollLocations { get; set; }

        public SelectBoothViewModel(List<TollLocation> TollLocations)
        {
            this.TollLocations = TollLocations;
        }
    }
}

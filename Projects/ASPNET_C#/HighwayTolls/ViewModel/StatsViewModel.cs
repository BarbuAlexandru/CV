using HighwayTolls.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HighwayTolls.ViewModel
{
    public class MonthInfo
    {
        public int year;
        public int month;
        public int income;

        public MonthInfo(int year, int month, int income)
        {
            this.year = year;
            this.month = month;
            this.income = income;
        }

        public MonthInfo(MonthInfo m)
        {
            this.year = m.year;
            this.month = m.month;
            this.income = m.income;
        }
    }

    public class StatsViewModel
    {
        public List<TollLocation> TollLocations { get; set; }
        public TollLocation SelectedLocation { get; set; }
        public int SelectedLocationBoothsNr { get; set; }
        public List<MonthInfo> MonthInfos { get; set; }

        public StatsViewModel(List<TollLocation> TollLocations, TollLocation SelectedLocation, int SelectedLocationBoothsNr, List<MonthInfo> MonthInfos)
        {
            this.TollLocations = TollLocations;
            this.SelectedLocation = SelectedLocation;
            this.SelectedLocationBoothsNr = SelectedLocationBoothsNr;
            this.MonthInfos = MonthInfos;
        }
    }
}

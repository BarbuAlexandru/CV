using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using UnblockMe_App.Models;

namespace UnblockMe_App.Services
{
    public class HomeService
    {
        private readonly UnblockMeContext dbContext;

        public HomeService(UnblockMeContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //Services

        public List<Car> SearchCarLicence(string licencePlate)
        {
            if (licencePlate == null)
            {
                return null;
            }
            var cars = new List<Car>();
            cars = dbContext.Car.Where(car => car.LicencePlate.Contains(licencePlate.ToUpper())).Include(car => car.Owner).ToList();
            return cars;
        }
    }
}

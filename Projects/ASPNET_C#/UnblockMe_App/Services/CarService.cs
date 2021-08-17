using Microsoft.EntityFrameworkCore;
using System.Linq;
using UnblockMe_App.Models;

namespace UnblockMe_App.Services
{
    public class CarService
    {
        private readonly UnblockMeContext dbContext;

        public CarService(UnblockMeContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //Services
        public void AddNewCar(User user, string licencePlate, string maker, string model, string color, string additionalInfo)
        {
            var car = new Car()
            {
                LicencePlate = licencePlate,
                OwnerId = user.Id,
                Owner = user,
                Maker = maker,
                Model = model,
                Color = color,
                AdditionalInfo = additionalInfo,
                BlockedLicencePlate = null,
                BlockedByLicencePlate = null
            };
            user.Car.Add(car);

            dbContext.User.Update(user);
            dbContext.Car.Add(car);
            dbContext.SaveChanges();
        }

        public void DeleteCarById(string licencePlate)
        {
            var car = dbContext.Car.FirstOrDefault(car => car.LicencePlate == licencePlate);
            dbContext.Car.Remove(car);
            dbContext.Car.Where(carBlockedBy => carBlockedBy.BlockedByLicencePlate == car.LicencePlate).ToList().ForEach(c=>c.BlockedByLicencePlate = null);
            dbContext.Car.Where(carBlocking => carBlocking.BlockedLicencePlate == car.LicencePlate).ToList().ForEach(c => c.BlockedLicencePlate = null);
            dbContext.SaveChanges();
        }

        public Car GetCarById(string licencePlate)
        {
            return dbContext.Car.Include(car => car.Owner).FirstOrDefault(car=>car.LicencePlate == licencePlate);
        }

        public void DeleteBlockedByInteraction(string licencePlate, string blockedByLicencePlate)
        {
            var car = GetCarById(licencePlate);
            var blockedByCar = GetCarById(blockedByLicencePlate);

            car.BlockedByLicencePlate = null;
            blockedByCar.BlockedLicencePlate = null;

            dbContext.Car.Update(car);
            dbContext.Car.Update(blockedByCar);

            dbContext.SaveChanges();
        }

        public void UpdateCar(Car car, string maker, string model, string color, string additionalInformation)
        {
            car.Maker = maker;
            car.Model = model;
            car.Color = color;
            car.AdditionalInfo = additionalInformation;
            dbContext.Car.Update(car);
            dbContext.SaveChanges();
        }

        public void DeleteBlockedInteraction(string licencePlate, string blockedLicencePlate)
        {
            var car = GetCarById(licencePlate);
            var blockedCar = GetCarById(blockedLicencePlate);

            car.BlockedLicencePlate = null;
            blockedCar.BlockedByLicencePlate = null;

            dbContext.Car.Update(car);
            dbContext.Car.Update(blockedCar);

            dbContext.SaveChanges();
        }

        public void AddInteraction(string blockingLicencePlate, string blockedLicencePlate)
        {
            var blockingCar = GetCarById(blockingLicencePlate);
            var blockedCar = GetCarById(blockedLicencePlate);

            if(blockingCar.BlockedByLicencePlate == blockedCar.LicencePlate || blockedCar.BlockedByLicencePlate == blockingCar.LicencePlate
                || blockingCar.BlockedLicencePlate != null || blockedCar.BlockedByLicencePlate != null)
            {
                return;
            }

            blockingCar.BlockedLicencePlate = blockedCar.LicencePlate;
            blockedCar.BlockedByLicencePlate = blockingCar.LicencePlate;

            dbContext.Car.Update(blockingCar);
            dbContext.Car.Update(blockedCar);

            dbContext.SaveChanges();
        }
    }
}

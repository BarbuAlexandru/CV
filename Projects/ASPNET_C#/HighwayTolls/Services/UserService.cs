using Microsoft.EntityFrameworkCore;
using HighwayTolls.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HighwayTolls.Services
{
    public class UserService
    {
        private readonly NetRomTestDbContext dbContext;
        private readonly TollLocationService tollLocationService;

        public UserService(NetRomTestDbContext dbContext, TollLocationService tollLocationService)
        {
            this.dbContext = dbContext;
            this.tollLocationService = tollLocationService;
        }

        //Services
        public Employee GetEmployeeById(string id)
        {
            return dbContext.Employees.Where(e => e.Id == id).FirstOrDefault();
        }

        public void ClearEmployeeBooth(Employee employee) {
            employee.TollBooth = null;
            employee.TollBoothId = null;

            dbContext.Employees.Update(employee);
            dbContext.SaveChanges();
        }

        public Employee GetUserByEmail(string email)
        {
            return dbContext.Employees.Where(e => e.Email == email).FirstOrDefault();
        }

        public bool CheckIfEmployeeHasBooth(Employee emplyee)
        {
            if (emplyee.TollBoothId != null)
            {
                return true;
            }
            return false;
        }

        public void UpdateLocation(Employee employee, string locationId, string boothId)
        {
            var tollLocation = tollLocationService.GetTollLocationById(Guid.Parse(locationId));
            var tollBooth = tollLocationService.GetTollBoothById(Guid.Parse(boothId));

            employee.TollBooth = tollBooth;
            employee.TollBoothId = tollBooth.Id;
            dbContext.Employees.Update(employee);
            dbContext.SaveChanges();
        }
    }
}
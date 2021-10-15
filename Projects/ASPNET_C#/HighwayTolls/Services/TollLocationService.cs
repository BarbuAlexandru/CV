using HighwayTolls.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace HighwayTolls.Services
{
    public class TollLocationService
    {

        private readonly NetRomTestDbContext dbContext;

        public TollLocationService(NetRomTestDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //Services
        public List<TollLocation> GetAllTollLocations()
        {
            return dbContext.TollLocations.ToList();
        }

        public List<TollLocation> GetAllTollLocations_Complete()
        {
            return dbContext.TollLocations.Include(t=>t.TollBooths).ToList();
        }

        public List<TollBooth> GetAllTollBooths()
        {
            return dbContext.TollBooths.ToList();
        }

        public TollLocation GetTollLocationById(Guid id)
        {
            return dbContext.TollLocations.Where(e => e.Id == id).FirstOrDefault();
        }

        public TollLocation GetTollLocationById_Complete(Guid id)
        {
            return dbContext.TollLocations.Include(t => t.TollBooths).Where(e => e.Id == id).FirstOrDefault();
        }

        public TollBooth GetTollBoothById(Guid id)
        {
            return dbContext.TollBooths.Where(e => e.Id == id).FirstOrDefault();
        }

        public List<TollBooth> GetBoothsOfLocations(Guid locationId)
        {
            return dbContext.TollBooths.Where(e => e.TollLocationId == locationId).ToList();
        }

        public TollLocation GetTollLocationByBoothId(Guid id)
        {
            var booth = GetTollBoothById(id);
            return GetTollLocationById(booth.TollLocationId);
        }

        public List<TollBooth> GetAllTollBoothsOfLocation(Guid id)
        {
            return dbContext.TollBooths.Where(b => b.TollLocationId == id).ToList();
        }
    }
}

using AirWAD.Models.DataBase;
using AirWAD.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirWAD.Repository.Implementation
{
    public class RentalRepository : BaseRepository<Rental>, IRentalRepository
    {
        public RentalRepository(AirWADContext dbContext) : base(dbContext)
        {

        }
    }
}
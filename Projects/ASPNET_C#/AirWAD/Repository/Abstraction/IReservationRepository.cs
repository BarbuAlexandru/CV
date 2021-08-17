﻿using AirWAD.Models.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirWAD.Repository.Abstraction
{
    public interface IReservationRepository : IRepository<Reservation>
    {
        IEnumerable<Reservation> GetReservations();
    }
}
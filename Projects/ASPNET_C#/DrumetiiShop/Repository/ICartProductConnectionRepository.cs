﻿using DrumetiiShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrumetiiShop.Repository
{
    public interface ICartProductConnectionRepository : IRepository<CartProductConnection>
    {
        bool DeleteCartProductConnectionOfProduct(int Id);
    }
}
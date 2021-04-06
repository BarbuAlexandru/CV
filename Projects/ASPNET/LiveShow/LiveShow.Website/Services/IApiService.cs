using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveShow.Website.Services
{
    public interface IApiService
    {
        void RegisterUser(string firstName, string lastName, string userName, string password, string userType);
    }
}

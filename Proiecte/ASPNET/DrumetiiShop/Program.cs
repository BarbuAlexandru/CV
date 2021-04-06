using DrumetiiShop.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrumetiiShop
{
    public class Program
    {
        //Global Static variables
        public static User currentUser = null;
        public static int currentUserNoProducts = 0;

        //Global Static Functions
        public static void ActualizeCurrentUser(User user)
        {
            if(currentUser == null)
            {
                currentUser = new User();
            }
            currentUser.Id = user.Id;
            currentUser.Email = user.Email;
            currentUser.Password = user.Password;
            currentUser.Role = user.Role;
        }

        public static void ClearCurrentUser()
        {
            currentUser = null;
        }

        public static string StandardizeText(string str)
        {
            string newStr = new string(str.ToCharArray().Where(c => !Char.IsWhiteSpace(c)).ToArray());
            //return newStr.ToLower();
            return newStr;
        }

        //Main Function

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using Common.Classes;
using DAL.MongoDB;
using DAL.MongoDB.Repositories;

namespace DB.Seed
{
    public class Program
    {

        /*
        public static AppSettings Settings { get; set; }
        public UserRepository userRepo;
        public RoleRepository roleRepo;
         */

        public static void Main(string[] args)
        {
            

            /*
            var settings = LoadConfig();
            userRepo = new UserRepository();
            roleRepo = new RoleRepository();

            SeedRolesAndClaims();
            SeedAdminUser();
             */
        }

        private void SeedRolesAndClaims()
        {

        }

        private void SeedAdminUser()
        {
            
        }

        private static AppSettings LoadConfig()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            var settings = configuration.GetSection("AppSettings");

            return new AppSettings
            {
                DatabaseName = settings["DatabaseName"],
                ConnectionString = settings["ConnectionString"]
            };
        }
    }
}

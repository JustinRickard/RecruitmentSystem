using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;  
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using DAL.MongoDB.Repositories;
using Common.Interfaces.Repositories;
using Common.Interfaces.Helpers;
using Common.Dto;
using Common.Classes;
using Common.Helpers;
using DB.Seed.MongoDB.Helpers;

namespace DB.Seed.MongoDB
{
    public class Program
    {
        public static IConfigurationRoot Configuration { get; set; }
        public static IServiceProvider ServiceProvider {get; set; }

        public static void Main(string[] args)
        {
            Configuration = ConfigurationHelper.BuildConfig();
            ServiceProvider = ConfigurationHelper.BuildServiceProvider(Configuration);            
            
            var logger = ServiceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();
            logger.LogDebug("Starting DB seeding...");

            var userRepository = ServiceProvider.GetService<IUserRepository>();
            var jsonHelper = ServiceProvider.GetService<IJsonHelper>();

            logger.LogDebug("ConnectionString:");
            logger.LogDebug(Configuration["AppSettings:ConnectionString"]);            


            logger.LogDebug("Adding users...");

            var user = new User(
                "Client 1",
                "User2",
                "Two",
                "userone@example.org",
                "UserTwo"
            );

            var maybeUserTask = userRepository.Add(user);
            var maybeUser = maybeUserTask.GetAwaiter().GetResult();

            if (maybeUser.HasValue) {
                logger.LogDebug("User added.");
            } else {
                logger.LogDebug("User not added.");
            }

            logger.LogDebug("Finished seeding");

        }
    }
}

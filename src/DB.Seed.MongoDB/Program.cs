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

namespace DB.Seed.MongoDB
{
    public class Program
    {
        public static IConfigurationRoot Configuration { get; set; }

        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                // .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            Configuration = builder.Build();

            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<IUserRepository, UserRepository>()
                .AddSingleton<IPasswordHelper, PasswordHelper>()
                .AddSingleton<IJsonHelper, JsonHelper>()
                .AddOptions()
                .Configure<AppSettings>(Configuration.GetSection("AppSettings"))                
                .BuildServiceProvider();
            

            serviceProvider
                .GetService<ILoggerFactory>()
                .AddConsole(LogLevel.Debug);
            
            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();
            logger.LogDebug("Starting DB seeding...");

            var userRepository = serviceProvider.GetService<IUserRepository>();
            var jsonHelper = serviceProvider.GetService<IJsonHelper>();

            logger.LogDebug("ConnectionString:");
            logger.LogDebug(Configuration["AppSettings:ConnectionString"]);            


            logger.LogDebug("Adding users...");

            var user = new User(
                "Client 1",
                "User",
                "One",
                "userone@example.org",
                "UserOne"
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

using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Common.Classes;
using Common.Helpers;
using Common.Interfaces.Repositories;
using Common.Interfaces.Helpers;
using DAL.MongoDB.Repositories;

namespace DB.Seed.MongoDB.Helpers
{
    public static class ConfigurationHelper
    {
        public static IConfigurationRoot BuildConfig () {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                    // .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            var configuration = builder.Build();

            return configuration;
        }

        public static IServiceProvider BuildServiceProvider(IConfigurationRoot config) {
                IServiceProvider serviceProvider = new ServiceCollection()
                    .AddLogging()
                    .AddSingleton<IUserRepository, UserRepository>()
                    .AddSingleton<IPasswordHelper, PasswordHelper>()
                    .AddSingleton<IJsonHelper, JsonHelper>()
                    .AddOptions()
                    .Configure<AppSettings>(config.GetSection("AppSettings"))                
                    .BuildServiceProvider();

                serviceProvider
                    .GetService<ILoggerFactory>()
                    .AddConsole(LogLevel.Debug);

                return serviceProvider;
        }
    }
}
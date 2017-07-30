using Common.Interfaces.Repositories;
using DAL.MongoDB.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace DAL.MongoDB.ExtensionMethods
{
    public static class IocExtensions
    {
        public static void BindRepositoriesAsSingleton(this IServiceCollection serviceProvider) {
            serviceProvider
                .AddSingleton<IUserRepository, UserRepository>();
        }

        public static void BindRepositoriesAsTransient(this IServiceCollection serviceProvider) {
            serviceProvider
                .AddTransient<IUserRepository, UserRepository>();
        }
    }
}
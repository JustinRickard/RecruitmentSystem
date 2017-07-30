using Common.Helpers;
using Common.Interfaces.Repositories;
using Common.Interfaces.Helpers;
using System;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Common.ExtensionMethods
{
    public static class IocExtensions
    {
        public static void BindCommonServicesAsSingleton(this IServiceCollection serviceProvider) {
            serviceProvider
                .AddSingleton<IPasswordHelper, PasswordHelper>()
                .AddSingleton<IJsonHelper, JsonHelper>();
        }
    }
}
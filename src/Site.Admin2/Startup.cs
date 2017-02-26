using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Common.Classes;
using Common.Interfaces.Repositories;
using Common.Interfaces.Services;
using Common.Interfaces.Helpers;
using Common.Services;
using DAL.MongoDB.Repositories;
using Microsoft.AspNetCore.Http;
using Common.Helpers;
using Microsoft.AspNetCore.Identity;
using Common.Dto;

namespace Site.Admin2
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            IUserStore<User> userStore = new UserStore();
            IRoleStore<Role> roleStore = new RoleStore();
            IUserClaimsPrincipalFactory<User> userPrincipalFactory = new UserPrincipalFactory();
            services.AddInstance<IUserStore<User>>(userStore);
            services.AddInstance<IRoleStore<ApplicationRole>>(roleStore);
            services.AddInstance<IUserClaimsPrincipalFactory<ApplicationUser>>(userPrincipalFactory);

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddDefaultTokenProviders();


            // Configure settings
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            // Add framework services.
            services.AddMvc();

            // Dependency bindings
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuditRepository, AuditRepository>();

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IJsonHelper, JsonHelper>();
            services.AddScoped<IPasswordHelper, PasswordHelper>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

                        // Configure cookie middleware
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationScheme = "MyCookieMiddlewareInstance",
                LoginPath = new PathString("/Account/Login/"),
                AccessDeniedPath = new PathString("/Account/Forbidden/"),
                AutomaticAuthenticate = true,
                AutomaticChallenge = true
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Common.Classes;
using Common.Interfaces;
using Common.Interfaces.Services;
using Site.Admin2.DtoConversions;
using Site.Admin2.ViewModels;

namespace Site.Admin2.Controllers
{
    public class UserController : ControllerBase
    {
        IAppSettings appSettings;
        IUserService userService;

        public UserController(
            IOptions<AppSettings> appSettings,
            IUserService userService
        )
        {
            this.appSettings = appSettings.Value;
            this.userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await userService.GetAll();
            var viewModel = new UsersVM {
                Users = users.ToViewModel()
            };
            return View(viewModel);
        }
    }
}
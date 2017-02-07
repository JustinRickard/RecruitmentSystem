using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Common.Dto;
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

        public IActionResult Create() 
        {
            return View(new UserVM());
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserVM user) {
            var userDto = user.ToDto();
            await userService.Add(userDto);

            return RedirectToAction("Index"); // TODO: Show user page
        }

        public async Task<IActionResult> Details(string id) 
        {
            var user = await userService.GetById(id);
            return View(user.ToViewModel());
        }

        public async Task<IActionResult> Edit(string id) 
        {
            var user = await userService.GetById(id);
            var userVM = user.ToViewModel();
            return View(userVM);
        }

        [HttpPost] 
        public async Task<IActionResult> Edit(UserVM user) {
            var userDto = user.ToDto();
            var dbUser = await userService.Update(userDto);

            return RedirectToAction("Details", dbUser.ToViewModel());
        }

        public async Task<IActionResult> Delete(string id) {
            var user = await userService.GetById(id);
            return View(user.ToViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UserVM user) 
        {
            var userDto = await userService.GetById(user.Id);
            if (userDto != null)
            {
                await userService.Delete(user.Id);
                ViewBag.Message = string.Format("{0} has been deleted.", user.Username);
                
            } else {
                ViewBag.Message = string.Format("User could not be found with the ID specified: {0}", user.Id);
            }
            return RedirectToAction("Index");
        }
    }
}
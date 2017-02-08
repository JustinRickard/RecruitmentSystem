using Common.Dto;
using Common.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Site.Admin2.Controllers
{
    public class AccountController : ControllerBase
    {
        private IUserService userService;

        public AccountController(
            IUserService userService
        ) 
        {
            this.userService = userService;
        }

        public IActionResult Login () {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginCredentials credentials) {
            var user = userService.GetByLoginCredentials(credentials);
            if (user!= null) {
                // cookieAuthenticationHelper.Authenticate
            }
        }
    }
}
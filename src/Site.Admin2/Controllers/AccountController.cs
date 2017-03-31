using System.Threading.Tasks;
using Common.Dto;
using Common.Enums;
using Common.Interfaces.Helpers;
using Common.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Site.Admin2.ViewModels.Account;

namespace Site.Admin2.Controllers
{
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IUserService userService;

        public AccountController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IAuditHelper auditHelper,
            IUserService userService
        ) : base (auditHelper)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.userService = userService;
        }

        public async Task<IActionResult> Logout() { 
            await signInManager.SignOutAsync(); 
            return RedirectToAction("Login", "Account"); 
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginCredentials model, string returnUrl = null)
        {
            await Audit(AuditType.AdminLogin, string.Format("Attempting to log in with username {0}", model.Username));

            var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, true, false);

            await Audit(AuditType.AdminLogin, string.Format("Log in with username {0} completed.", model.Username));

            if (result.Succeeded)
            {
                await Audit(AuditType.AdminLogin, string.Format("Successful login for user with username {0}. returnUrl {1}.", model.Username, returnUrl));
                return RedirectToLocal(returnUrl);
            }
            else if (result.RequiresTwoFactor)
            {
                await Audit(AuditType.AdminLogin, string.Format("Login failure for user with username {0} - requires two factor authentication", model.Username));
                ModelState.AddModelError(string.Empty, "User requires two factor authentication");
            }
            else if (result.IsLockedOut)
            {
                await Audit(AuditType.AdminLogin, string.Format("Login failure for user with username {0} - user is locked out", model.Username));
                ModelState.AddModelError(string.Empty, "Your user is locked out.");
            }
            else
            {
                await Audit(AuditType.AdminLogin, string.Format("Login failure for user with username {0} - incorrect credentials entered", model.Username));
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return View(model);
        }

        public IActionResult Register()
        {                                    
            return View(new RegisterUserVM());
        }
        
        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserVM model)
        {
            await Audit(AuditType.AdminLogin, "Attempting to register user: {0}");
            var existingUserResult = await userService.GetByUsername(model.Username);
            if (existingUserResult.IsSuccess)
            {
                ModelState.AddModelError(nameof(model.Username), "This username already exists");
            }

            if (model.Password != model.RePassword)
            {
                ModelState.AddModelError(string.Empty, "Passwords don't match");
                return View(model);
            }

            var user = new User 
            {
                Username = model.Username,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            var userCreationResult = await userManager.CreateAsync(user, model.Password);
            if (!userCreationResult.Succeeded)
            {
                foreach(var error in userCreationResult.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
                return View(model);
            }

            var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
            await Audit(AuditType.AdminLogin, token);
            var dbUserResult = await userService.GetByUsername(user.Username);
            await userManager.AddPasswordAsync(dbUserResult.Value, model.Password);

            return View("RegisterComplete");
        }         
    }
}
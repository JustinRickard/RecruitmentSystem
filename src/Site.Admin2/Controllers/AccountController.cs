using System.Threading.Tasks;
using Common.Dto;
using Common.Enums;
using Common.Interfaces.Repositories;
using Common.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
            IAuditRepository auditRepository,
            IUserService userService
        ) : base (auditRepository)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.userService = userService;
        }

        // TEMPORARY: REMOVE ONCE AUTHENTICATION WORKS
        public async Task<IActionResult> TempAddAdmin() {
            
            var user = new User 
            {
                Username = "admin",
                FirstName = "admin",
                LastName = "admin",
                Email = "admin@example.org"
            };
            
            await userManager.CreateAsync(user);
            var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
            var dbUserResult = await userService.GetByUsername(user.Username);
            var dbUser = dbUserResult.Value;
            await userManager.ResetPasswordAsync(dbUser, dbUser.Token, "admin");
            // await userManager.AddPasswordAsync(dbUserResult.Value, "admin");

            return View("Login");
        }

        public IActionResult Register()
        {                                    
            return View();
        }

        [HttpPost] 
        public async Task<IActionResult> Logout() { 
            await signInManager.SignOutAsync(); 
            return RedirectToAction("Index", "Home"); 
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginCredentials model, string returnUrl = null)
        {
            var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, true, false);

            if (result.Succeeded)
            {
                Audit(AuditType.AdminLogin, string.Format("Successful login for user with username {0}", model.Username));
                return RedirectToHome();
            }
            else if (result.RequiresTwoFactor)
            {
                Audit(AuditType.AdminLogin, string.Format("Login failure for user with username {0} - requires two factor authentication", model.Username));
                ModelState.AddModelError(string.Empty, "User requires two factor authentication");
            }
            else if (result.IsLockedOut)
            {
                Audit(AuditType.AdminLogin, string.Format("Login failure for user with username {0} - user is locked out", model.Username));
                ModelState.AddModelError(string.Empty, "Your user is locked out.");
            }
            else
            {
                Audit(AuditType.AdminLogin, string.Format("Login failure for user with username {0} - incorrect credentials entered", model.Username));
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return View(model);
        }

        
        [HttpPost]
        public async Task<IActionResult> Register(string email, string password, string repassword)
        {
            if (password != repassword)
            {
                ModelState.AddModelError(string.Empty, "Passwords don't match");
                return View();
            }

            var newUser = new User 
            {
                Username = email,
                Email = email
            };

            var userCreationResult = await userManager.CreateAsync(newUser, password);
            if (!userCreationResult.Succeeded)
            {
                foreach(var error in userCreationResult.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
                return View();
            }

            /*

            var emailConfirmationToken = await userManager.GenerateEmailConfirmationTokenAsync(newUser);
            var tokenVerificationUrl = Url.Action("VerifyEmail", "Account", new {id = newUser.Id, token = emailConfirmationToken}, Request.Scheme);

            // await messageService.Send(email, "Verify your email", $"Click <a href=\"{tokenVerificationUrl}\">here</a> to verify your email");

            return Content("Check your email for a verification link");
            */

            return View("RegisterComplete");
        }         
    }
}
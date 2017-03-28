using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Common.Classes;
using Microsoft.AspNetCore.Authorization;

namespace Site.Admin2.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly AppSettings appSettings;

        public HomeController(IOptions<AppSettings> appSettings)
        {
            this.appSettings = appSettings.Value;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

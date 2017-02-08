using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Common.Classes;

namespace Site.Admin2.Controllers
{    
    public class ControllerBase : Controller
    {
        internal protected void ShowMessage(string message) {
            ViewBag.Message = message;
        }
    }
}
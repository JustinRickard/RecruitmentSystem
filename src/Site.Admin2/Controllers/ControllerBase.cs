using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Common.Classes;
using Common.Interfaces.Repositories;
using Common.Enums;

namespace Site.Admin2.Controllers
{    
    public class ControllerBase : Controller
    {
        protected internal IAuditRepository auditRepository;

        public ControllerBase (
            IAuditRepository auditRepository
        )
        {
            this.auditRepository = auditRepository;
        }

        internal protected IActionResult RedirectToHome()
        {
            return RedirectToAction("Index", "Home");
        }

        internal protected void ShowMessage(string message) {
            ViewBag.Message = message;
        }

        internal protected void Audit(AuditType type, string message) {
            auditRepository.Add(type, message);
        }
    }
}
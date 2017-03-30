using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Common.Classes;
using Common.Interfaces.Repositories;
using Common.Enums;
using Common.Interfaces.Helpers;

namespace Site.Admin2.Controllers
{    
    public class ControllerBase : Controller
    {
        protected internal IAuditHelper auditHelper;

        public ControllerBase (
            IAuditHelper auditHelper
        )
        {
            this.auditHelper = auditHelper;
        }

        internal protected IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToHome();
            }
        }

        internal protected IActionResult RedirectToHome()
        {
            return RedirectToAction("Index", "Home");
        }

        internal protected void ShowMessage(string message) {
            ViewBag.Message = message;
        }

        public async Task Audit(AuditType type, string message)
        {
            await auditHelper.Audit(type, message);
        }

        public async Task Audit<T>(AuditType type, string prefix, T objectToSerialize)
        {
            await auditHelper.Audit<T>(type, prefix, objectToSerialize);
        }

        public async Task Audit<T1,T2>(AuditType type, string prefix, T1 objectToSerialize, T2 parameters)
        {
            await auditHelper.Audit<T1,T2>(type, prefix, objectToSerialize, parameters);
        }
    }
}
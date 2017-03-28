using System.Threading.Tasks;
using Common.Classes;
using Common.Interfaces;
using Common.Interfaces.Repositories;
using Common.SearchFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Site.Admin2.DtoConversions;
using Site.Admin2.ViewModels;

namespace Site.Admin2.Controllers
{
    [Authorize]
    public class AuditController : ControllerBase
    {
        IAppSettings appSettings;
        public AuditController(
            IOptions<AppSettings> appSettings,
            IAuditRepository auditRepository
        ) : base (auditRepository)
        {
            this.appSettings = appSettings.Value;
        }

        public async Task<IActionResult> Index()
        {
            var logs = await auditRepository.Get(new AuditFilter());
            var viewModel = logs.ToViewModel();
            
            return View(viewModel);
        }
    }
}
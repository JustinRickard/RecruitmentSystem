using System.Collections.Generic;
using Common.Dto;

namespace Site.Admin2.ViewModels
{
    public class AuditsVM
    {
        public IEnumerable<Audit> Logs { get; set; }
    }
}
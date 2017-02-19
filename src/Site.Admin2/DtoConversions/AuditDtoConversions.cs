using System.Collections.Generic;
using Common.Dto;
using Site.Admin2.ViewModels;

namespace Site.Admin2.DtoConversions
{
    public static class AuditDtoConversions
    {
        public static AuditsVM ToViewModel(this IEnumerable<Audit> auditRecords) {
            return new AuditsVM {
                Logs = auditRecords
            };
        }
    }
}
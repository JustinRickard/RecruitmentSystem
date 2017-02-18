using System.Collections.Generic;
using System.Linq;
using Common.Dto;
using DAL.MongoDB.Models;

namespace DAL.MongoDB.DtoConversions
{
    public static class AuditDtoConversion
    {
        public static Audit ToDto(this DbAudit audit) {
            return new Audit {
                Id = audit.Id.ToString(),
                Type = audit.Type,
                Message = audit.Message,
                DateCreated = audit.DateCreated
            };
        }

        public static IEnumerable<Audit> ToDto(this IEnumerable<DbAudit> auditRecords) {
            return auditRecords.Select(audit => audit.ToDto());
        }
    }
}
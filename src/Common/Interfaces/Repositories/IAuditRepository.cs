using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Dto;
using Common.Enums;
using Common.SearchFilters;

namespace Common.Interfaces.Repositories
{
    public interface IAuditRepository
    {
        Task Add(AuditType type, string message);

        Task<IEnumerable<Audit>> Get(AuditFilter filter);
    }
}
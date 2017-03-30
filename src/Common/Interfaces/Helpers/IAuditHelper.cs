using System.Threading.Tasks;
using Common.Enums;

namespace Common.Interfaces.Helpers
{
    public interface IAuditHelper
    {
        Task Audit(AuditType type, string message);
        Task Audit<T>(AuditType type, string prefix, T objectToSerialize);
        Task Audit<T1,T2>(AuditType type, string prefix, T1 objectToSerialize, T2 parameters);
        
    }
}
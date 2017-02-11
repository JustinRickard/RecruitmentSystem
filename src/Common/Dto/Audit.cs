using Common.Classes;
using Common.Enums;

namespace Common.Dto
{
    public class Audit : DbRecordBase
    {
        public AuditType Type { get; set; }
        public string Message { get; set; }
    }
}
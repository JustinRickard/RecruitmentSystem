using System;
using Common.Enums;

namespace Common.SearchFilters
{
    public class AuditFilter
    {
        public AuditType? Type { get; set; }

        public string Message { get; set; }

        public DateTimeOffset? From { get; set; }

        public DateTimeOffset? To { get; set; }
    }
}
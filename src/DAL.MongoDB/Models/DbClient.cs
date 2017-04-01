using Common.Dto;

namespace DAL.MongoDB.Models
{
    public class DbClient : DbRecordBase
    {
        public string ParentId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public ClientSettings Settings { get; set; }

    }
}
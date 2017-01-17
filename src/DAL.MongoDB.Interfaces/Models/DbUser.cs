using System;
using DAL.MongoDB.Interfaces;

namespace DAL.MongoDB.Interfaces.Models
{
    public class DbUser : DbRecordBase, IDbRecord
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
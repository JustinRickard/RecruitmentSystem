using Common.Interfaces;

namespace Common.Classes
{
    public class AppSettings : IAppSettings
    {
        public string DatabaseName { get; set;}
        public string ConnectionString { get; set; }
    }
}
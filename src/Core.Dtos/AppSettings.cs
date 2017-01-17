using Core.Interfaces;

namespace Core.Dtos
{
    public class AppSettings : IAppSettings
    {
        public string DatabaseName { get; set;}
        public string ConnectionString { get; set; }
    }
}
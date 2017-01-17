namespace Core.Interfaces
{
    public class IAppSettings
    {
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
    }
}
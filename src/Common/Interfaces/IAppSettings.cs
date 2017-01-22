namespace Common.Interfaces
{
    public interface IAppSettings
    {
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
    }
}
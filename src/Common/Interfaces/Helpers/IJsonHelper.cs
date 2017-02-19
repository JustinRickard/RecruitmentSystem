using Common.Classes;

namespace Common.Interfaces.Helpers
{
    public interface IJsonHelper
    {
        Result<string> Serialize<T>(T input);
    }
}
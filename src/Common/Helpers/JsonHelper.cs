using Common.Classes;
using Common.Enums;
using Common.Interfaces.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Common.Helpers
{
    public class JsonHelper : IJsonHelper
    {
        public Result<string> Serialize<T> (T input) {
            try {
                var result = JsonConvert.SerializeObject(input, new StringEnumConverter());
                return Result<string>.Succeed(result);
            }
            catch {
                return Result<string>.Fail(ResultCode.CouldNotSerialize);
            }
            
        }
    }
}
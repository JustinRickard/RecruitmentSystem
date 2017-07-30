using Common.Classes;
using Common.Interfaces.Helpers;
using Common.Interfaces.Repositories;

namespace DB.Seed.Common.Seeders
{
    public static class UserSeeder
    {
        public static Result Seed(
            IJsonHelper jsonHelper, 
            IUserRepository repository
        )
        {
            // Get user data and deserialize
            // Add user data to DB using repository
            // Return result
            return Result.Succeed();
        }
    }
}
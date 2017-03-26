namespace Common
{
    public static class Constants
    {
        public static class Resources {
            public static class Keycodes {
                public static class Generic 
                {

                }
                public static class User 
                {
                    public const string AttemptAdd = "UserAttemptAdd";
                    public const string AddComplete = "AddComplete";
                    public const string AttemptEdit = "UserAttemptEdit";
                    public const string  EditComplete = "UserEditComplete";
                    public const string AttemptEditUsername = "AttemptEditUsername";
                    public const string AttemptEditNormalizedUsername = "AttemptEditNormalizedUsername";
                    public const string EditUsernameComplete = "EditUsernameComplete";
                    public const string EditNormalizedUsernameComplete = "EditNormalizedUsernameComplete";
                    public const string AttemptUpdatePassword = "AttemptUpdatePassword";
                    public const string UpdatePasswordComplete = "UpdatePasswordComplete";

                }

                public static class UserStore
                {
                    public const string AttemptCreateAsync = "AttemptCreateAsync";
                    public const string CreateAsyncComplete = "CreateAsyncComplete";
                    public const string AttemptFindByNameAsync = "AttemptFindByNameAsync";
                    public const string FindByNameAsyncComplete = "FindByNameAsyncComplete";
                    public const string AttemptGetNormalizedUserNameAsync = "AttemptGetNormalizedUserNameAsync";
                    public const string GetNormalizedUserNameAsyncComplete = "GetNormalizedUserNameAsyncComplete";
                    public const string AttemptFindByIdAsync = "AttemptFindByIdAsync";
                    public const string FindByIdAsyncComplete = "FindByIdAsyncComplete";
                    public const string AttemptGetUserIdAsync = "AttemptGetUserIdAsync";
                    public const string AttemptGetUserNameAsync = "AttemptGetUserNameAsync";
                    public const string AttemptSetNormalizedUserNameAsync = "AttemptSetNormalizedUserNameAsync";
                    public const string SetNormalizedUserNameAsyncComplete = "SetNormalizedUserNameAsyncComplete";
                    public const string AttemptDeleteAsync = "AttemptDeleteAsync";
                    public const string DeleteAsyncComplete = "AttemptDeleteAsync";
                    public const string AttemptSetUserNameAsync = "AttemptSetUserNameAsync";
                    public const string SetUserNameAsyncComplete = "SetUserNameAsyncComplete";
                    public const string AttemptUpdateAsync = "AttemptUpdateAsync";
                    public const string UpdateAsyncComplete = "UpdateAsyncComplete";
                    public const string AttemptGetPasswordHashAsync = "AttemptGetPasswordHashAsync";
                    public const string GetPasswordHashAsyncComplete = "GetPasswordHashAsyncComplete";
                    public const string AttemptHasPasswordAsync = "AttemptHasPasswordAsync";
                    public const string HasPasswordAsyncComplete = "HasPasswordAsyncComplete";
                    public const string AttemptSetPasswordHashAsync = "AttemptSetPasswordHashAsync";
                    public const string SetPasswordHashAsyncComplete = "SetPasswordHashAsyncComplete";
                    public const string AttemptRemoveLoginAsync = "AttemptRemoveLoginAsync";
                    public const string RemoveLoginAsyncComplete = "RemoveLoginAsyncComplete";

                }
            }
        }

        public static class Errors {

            public const string MaybeValueIsNull = "Maybe value accessed but is null";

            public const string ResultCodeSuccessOnFail = "Result.Fail called with ResultCode Success";

        }
    }
}
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

                }
            }
        }

        public static class Errors {

            public const string MaybeValueIsNull = "Maybe value accessed but is null";

            public const string ResultCodeSuccessOnFail = "Result.Fail called with ResultCode Success";

        }
    }
}
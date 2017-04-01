namespace Common
{
    public static class Constants
    {
        public static class Authorization
        {
            public static class Roles {
                public const string SuperAdmin = "SuperAdmin";
                public const string UserAdmin = "UserAdmin";
                public const string UserReadOnly = "UserReadOnly";
                public const string AuditReadonly = "AuditReadonly";
                public const string ProjectAdmin = "ProjectAdmin";
                public const string ProjectReadOnly = "ProjectReadOnly";
                public const string WorkflowAdmin = "WorkflowAdmin";
                public const string WorkflowReadOnly = "WorkflowReadOnly";
                public const string WorkflowStepAdmin = "WorkflowStepAdmin";
                public const string WorkflowStepReadOnly = "WorkflowStepReadOnly";
            }
            public static class Permissions
            {
                public const string Client_Create = "Client_Create";
                public const string Client_View = "Client_View";
                public const string Client_Edit = "Client_Edit";
                public const string Client_Delete = "Client_Delete";
                public const string Client_Obliterate = "Client_Obliterate";
                public const string User_Create = "User_Create";
                public const string User_View = "User_View";
                public const string User_Edit = "User_Edit";
                public const string User_Delete = "User_Delete";
                public const string User_Obliterate = "User_Obliterate";
                public const string Project_Create = "Project_Create";
                public const string Project_View = "Project_View";
                public const string Project_Edit = "Project_Edit";
                public const string Project_Delete = "Project_Delete";
                public const string Project_Obliterate = "Project_Obliterate";
                public const string Workflow_Create = "Workflow_Create";
                public const string Workflow_View = "Workflow_View";
                public const string Workflow_Edit = "Workflow_Edit";
                public const string Workflow_Delete = "Workflow_Delete";
                public const string Workflow_Obliterate = "Workflow_Obliterate";
                public const string WorkflowStep_Create = "WorkflowStep_Create";
                public const string WorkflowStep_View = "WorkflowStep_View";
                public const string WorkflowStep_Edit = "WWorkflowStep_Editorkflow_Edit";
                public const string WorkflowStep_Delete = "WorkflowStep_Delete";
                public const string WorkflowStep_Obliterate = "WorkflowStep_Obliterate";
                public const string Workflow_Take = "Workflow_Take";

            }
        }

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
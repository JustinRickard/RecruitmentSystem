using Common.Classes;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Common.ExtensionMethods
{
    public static class SecurityExtensions
    {
        public static IdentityError ToIdentityError(this Result result) 
        {
            return new IdentityError() {
                Code = result.ResultCode.ToString(),
                Description = string.Join(",", result.ErrorParams)
            };
        }
        public static IdentityError ToIdentityError<T>(this Result<T> result) 
        {
            return new IdentityError() {
                Code = result.ResultCode.ToString(),
                Description = string.Join(",", result.ErrorParams)
            };
        }

        public static IdentityError[] ToIdentityErrors(this Result result) 
        {
            return new List<IdentityError> { result.ToIdentityError() }.ToArray();
        }

        public static IdentityError[] ToIdentityErrors<T>(this Result<T> result) 
        {
            return new List<IdentityError> { result.ToIdentityError() }.ToArray();
        }

        public static IdentityResult ToIdentityResult(this Result result) {
            if (result.IsFailure)
            {
                return IdentityResult.Failed(result.ToIdentityErrors());
            }

            return IdentityResult.Success;
        }

        public static IdentityResult ToIdentityResult<T>(this Result<T> result) {
            if (result.IsFailure)
            {
                return IdentityResult.Failed(result.ToIdentityErrors());
            }

            return IdentityResult.Success;
        }
    }
}
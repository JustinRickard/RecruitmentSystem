using System;
using Common.Enums;

namespace Common.Classes
{
    public class Result
    {
        public bool IsSuccess => ResultCode == ResultCode.Success;
        public bool IsFailure => !IsSuccess;

        public ResultCode ResultCode { get; private set; }
        public string[] ErrorParams { get; private set; }

        private Result(ResultCode resultCode) {
            ResultCode = resultCode;
        }

        private Result(ResultCode resultCode, params string[] errorParams) {
            ResultCode = resultCode;
            ErrorParams = errorParams;
        }

        public static Result Succeed() {
            return new Result(ResultCode.Success);
        }

        public static Result Fail(ResultCode resultCode) {

            ThrowExceptionIfResultCodeIsSuccess(resultCode);
            return new Result(resultCode);
        }

        public static Result Fail(ResultCode resultCode, params string[] errorParams) {

            ThrowExceptionIfResultCodeIsSuccess(resultCode);
            return new Result(resultCode, errorParams);
        }

        private static void ThrowExceptionIfResultCodeIsSuccess (ResultCode resultCode) {
            if (resultCode == ResultCode.Success) {
                throw new InvalidOperationException(Constants.Errors.ResultCodeSuccessOnFail);
            }
        }


    }

    public class Result<T>
    {
        public bool IsSuccess => value != null && ResultCode == ResultCode.Success;
        public bool IsFailure => !IsSuccess;

        public T Value { 
            get {
                return value;
            }
        }

        private T value;
        public ResultCode ResultCode;
        public string[] ErrorParams;

        private Result (T value) {
            this.value = value;
            this.ResultCode = ResultCode.Success;
        }

        private Result(ResultCode resultCode) {
            this.ResultCode = resultCode;
        }
        private Result(ResultCode resultCode, params string[] errorParams) {
            this.ResultCode = resultCode;
            this.ErrorParams = errorParams;
        }

        public static Result<T> Succeed (T value) {
            return new Result<T>(value);
        }

        public static Result<T> Fail (ResultCode resultCode) {
            return new Result<T> (resultCode);
        }

        public static Result<T> Fail (ResultCode resultCode, params string[] errorParams) {
            return new Result<T> (resultCode, errorParams);
        }
    }
}
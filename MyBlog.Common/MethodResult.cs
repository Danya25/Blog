using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace MyBlog.Common
{
    public class MethodResult<T>
    {
        public T Value { get; set; }
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
        public string Message { get; set; }
        public string ExceptionMessage { get; set; }

        private Exception _exception { get; set; }

        public MethodResult()
        {
            Success = false;
            Message = "Undefined";
        }

        public MethodResult<T> SetException(Exception ex)
        {
            _exception = ex;
            GetFullExceptionMessage();
            return this;
        }
        public MethodResult<T> SetValue(T value)
        {
            Value = value;
            return this;
        }
        public Exception GetException()
        {
            return _exception;
        }
        private string GetFullExceptionMessage(Exception ex)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (ex == null)
                return stringBuilder.ToString();
            stringBuilder.AppendFormat("Message: {0}; Error body: {1}", Message, ex.Message);
            if (ex.InnerException != null)
                stringBuilder.AppendFormat("\r\nInner exception: {0}", GetFullExceptionMessage(ex.InnerException));
            return stringBuilder.ToString();
        }
        public string GetFullExceptionMessage()
        {
            if (_exception == null)
                return string.Format("Message: {0}; Exception missing", Message);
            return string.Format("Description:{0}\r\nTrace:{1}", GetFullExceptionMessage(_exception), _exception.StackTrace);
        }

        public MethodResult<T> SetSuccess(T value, string message = "")
        {
            _exception = null;
            Success = true;
            Message = message;
            Value = value;
            return this;
        }
        public MethodResult<T> SetError(string message, Exception ex = null)
        {
            _exception = ex;
            Success = false;
            Message = message;
            GetFullExceptionMessage();
            return this;
        }

        public MethodResult<T> SetErrorList(List<string> listErrors)
        {
            Errors = listErrors;
            return this;
        }

        public void ThrowExceptionIfNotOk()
        {
            if (Success)
                return;
            ThrowException();
        }

        public void ThrowException()
        {
            throw _exception == null ? new Exception() : new Exception(Message);
        }

        public static MethodResult<T> GetErrorResult(string message = "", Exception ex = null)
        {
            MethodResult<T> methodResult = new MethodResult<T>();
            methodResult._exception = ex;
            methodResult.Success = false;
            methodResult.Message = message;
            methodResult.GetFullExceptionMessage();
            return methodResult;
        }

        public static MethodResult<T> GetExceptionResult(string message, Exception ex)
        {
            MethodResult<T> methodResult = new MethodResult<T>();
            methodResult._exception = ex;
            methodResult.Success = false;
            methodResult.Message = message;
            methodResult.Errors = TryGetErrors(ex);
            methodResult.ExceptionMessage = ex.Message;
            methodResult.GetFullExceptionMessage();
            return methodResult;
        }

        public static MethodResult<T> GetSuccessResult(T value, string message = "")
        {
            return new MethodResult<T>()
            {
                _exception = null,
                Success = true,
                Message = message,
                Value = value
            };
        }

        private static List<string> TryGetErrors(Exception ex)
        {
            if (ex is ValidationException newException)
            {
                return newException.Errors.Select(it => it.ErrorMessage).ToList();
            }
            else
            {
                return new List<string>();
            }
        }
    }
}

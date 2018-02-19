using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities
{
    public class Result
    {
        protected Result(bool isSuccess, string error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        public bool IsSuccess { get; }
        public string Error { get;  }
        public bool IsFailure => !IsSuccess;

        public static Result Fail(string message)
        {
            return new Result(false, message);
        }

        public static Result<T> Fail<T>(string message)
        {
            return new Result<T>(default(T), false, message);
        }

        public static Result OK()
        {
            return new Result(true, string.Empty);
        }

        public static Result<T> OK<T>(T value)
        {
            return new Result<T>(value, true, string.Empty);
        }

        public static Result Combine(params Result[] results)
        {
            foreach(var r in results)
            {
                if (r.IsFailure)
                    return r;
            }

            return OK();
        }
    }

    public class Result<T>: Result
    {
        private readonly T _value;

        public T Value
        {
            get
            {
                if (!IsSuccess)
                    throw new InvalidOperationException();
                return _value;
            }
        }

        protected internal Result(T value, bool isSuccess, string message)
            :base(isSuccess,message)
        {
            _value = value; 
        }
    }
}

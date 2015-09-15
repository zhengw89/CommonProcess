using System;
using CommonProcess.Error;

namespace CommonProcess
{
    public abstract class CoreProcess
    {
        public bool HasError { get; set; }
        
        public int ErrorCode { get; set; }
        
        public string ErrorMessage { get; set; }
        
        protected void CacheError(int errorCode, string errorMessage)
        {
            this.HasError = true;

            this.ErrorCode = errorCode;
            this.ErrorMessage = errorMessage;
        }

        protected void CacheError(ErrorCode errorCode, params object[] args)
        {
            this.HasError = true;

            this.ErrorCode = (int)errorCode;
            var msg = ErrorCodeExtension.GetErrorCodeDescription(errorCode).ErrorCodeDescription;

            if (args.Length == 0)
            {
                this.ErrorMessage = msg;
            }
            else
            {
                string placeholder = string.Empty;
                for (int i = 0; i < args.Length; i++)
                {
                    placeholder += "{" + i + "}";
                }
                this.ErrorMessage = String.Format(msg + "，Detail：" + placeholder, args);
            }
        }

        protected void ResetError()
        {
            this.HasError = false;
            this.ErrorCode = 0;
            this.ErrorMessage = null;
        }

        protected void CacheArgumentError(string errorMessage)
        {
            CacheError(-100, errorMessage);
        }

        protected void CacheArgumentIsNullError(string agumentName)
        {
            CacheError(-100, string.Format("argument {0} is null", agumentName));
        }

        protected void CacheNotExistsError(string agumentName, string key)
        {
            CacheError(-100, string.Format("{0} doesn't exist:{1}", agumentName, key));
        }

        protected void CacheEnumAgumentError(string agumentName, int value)
        {
            CacheError(-100, string.Format("enum {0} is error, value is {1}", agumentName, value));
        }

        protected void CacheEnumAgumentError(string agumentName, int? value)
        {
            CacheError(-100, string.Format("enum {0} is error, value is {1}", agumentName, value));
        }

        protected void CacheSubError(CoreProcess process)
        {
            CacheError(process.GetError().Code, process.GetError().Message);
        }

        public ProcessError GetError()
        {
            if (!HasError)
            {
                return null;
            }

            return new ProcessError(ErrorCode, ErrorMessage);
        }
    }
}

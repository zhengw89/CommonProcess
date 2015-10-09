using System;
using CommonProcess.Error;

namespace CommonProcess
{
    /// <summary>
    /// 底层核心操作类
    /// </summary>
    public abstract class CoreProcess
    {
        private bool _hasError;
        /// <summary>
        /// 是否捕捉错误
        /// </summary>
        public bool HasError { get { return this._hasError; } }

        private int? _errorCode;
        /// <summary>
        /// 错误编码
        /// </summary>
        public int? ErrorCode { get { return this._errorCode; } }

        private string _errorMessage;
        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMessage { get { return this._errorMessage; } }

        /// <summary>
        /// 捕捉错误相关信息
        /// </summary>
        /// <param name="errorCode">错误编码</param>
        /// <param name="errorMessage">错误信息</param>
        protected void CacheError(int errorCode, string errorMessage)
        {
            this._hasError = true;

            this._errorCode = errorCode;
            this._errorMessage = errorMessage;
        }

        /// <summary>
        /// 捕捉错误相关信息
        /// </summary>
        /// <param name="errorCode">错误编码枚举</param>
        protected void CacheError(ErrorCode errorCode)
        {
            this._hasError = true;

            this._errorCode = (int)errorCode;
            this._errorMessage = ErrorCodeExtension.GetErrorCodeDescription(errorCode).ErrorCodeDescription;
        }

        /// <summary>
        /// 捕捉错误相关信息
        /// </summary>
        /// <param name="errorCode">错误编码枚举</param>
        /// <param name="message">错误信息</param>
        protected void CacheError(ErrorCode errorCode, string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                CacheError(errorCode);
            }
            else
            {
                this._hasError = true;
                this._errorCode = (int)errorCode;
                this._errorMessage = message;
            }
        }

        /// <summary>
        /// 重置错误相关信息
        /// </summary>
        protected void ResetError()
        {
            this._hasError = false;
            this._errorCode = null;
            this._errorMessage = null;
        }

        /// <summary>
        /// 捕捉子流程错误
        /// </summary>
        /// <param name="process"></param>
        protected void CacheSubError(CoreProcess process)
        {
            CacheError(process.GetError().Code, process.GetError().Message);
        }

        /// <summary>
        /// 获取错误信息
        /// </summary>
        /// <returns></returns>
        public ProcessError GetError()
        {
            if (HasError)
            {
                if (!this._errorCode.HasValue || string.IsNullOrEmpty(this._errorMessage))
                {
                    throw new ArgumentNullException();
                }
                return new ProcessError(this._errorCode.Value, this._errorMessage);
            }

            return null;
        }
    }
}

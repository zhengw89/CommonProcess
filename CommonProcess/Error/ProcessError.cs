namespace CommonProcess.Error
{
    /// <summary>
    /// 流程错误信息
    /// </summary>
    public class ProcessError
    {
        private readonly int _code;
        /// <summary>
        /// 错误编码
        /// </summary>
        public int Code { get { return this._code; } }

        private readonly string _message;
        /// <summary>
        /// 错误信息
        /// </summary>
        public string Message { get { return this._message; } }

        /// <summary>
        /// 构造函数
        /// </summary>
        public ProcessError() { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="errorCode">错误编码</param>
        /// <param name="errorMessage">错误信息</param>
        public ProcessError(int errorCode, string errorMessage)
        {
            this._code = errorCode;
            this._message = errorMessage;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="errorCode">错误编码枚举</param>
        public ProcessError(ErrorCode errorCode)
        {
            this._code = (int)errorCode;
            this._message = ErrorCodeExtension.GetErrorCodeDescription(errorCode).ErrorCodeDescription;
        }

        public override string ToString()
        {
            return string.Format("Code:{0},Message:{1}", Code, Message);
        }
    }
}

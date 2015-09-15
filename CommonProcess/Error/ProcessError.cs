namespace CommonProcess.Error
{
    public class ProcessError
    {
        public int Code { get; set; }

        public string Message { get; set; }

        public ProcessError() { }
        public ProcessError(int errorCode, string errorMessage)
        {
            this.Code = errorCode;
            this.Message = errorMessage;
        }
        public ProcessError(ErrorCode errorCode)
        {
            this.Code = (int)errorCode;
            this.Message = ErrorCodeExtension.GetErrorCodeDescription(errorCode).ErrorCodeDescription;
        }

        public override string ToString()
        {
            return string.Format("Code:{0},Message:{1}", Code, Message);
        }
    }
}

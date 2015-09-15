using CommonProcess.Error;

namespace CommonProcess
{
    public class ProcessResult<T>
    {
        public ProcessError Error { get; set; }
        public T Data { get; set; }

        public ProcessResult() { }
        public ProcessResult(T data)
            : this(data, null)
        {
        }
        public ProcessResult(ProcessError error)
            : this(default(T), error)
        {
        }
        public ProcessResult(T data, ProcessError error)
        {
            this.Data = data;
            this.Error = error;
        }
    }
}

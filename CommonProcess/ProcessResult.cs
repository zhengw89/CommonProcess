using CommonProcess.Error;

namespace CommonProcess
{
    /// <summary>
    /// 执行业务结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ProcessResult<T>
    {
        private readonly ProcessError _error;
        /// <summary>
        /// 执行流程错误信息
        /// </summary>
        public ProcessError Error { get { return this._error; } }

        private readonly T _data;
        /// <summary>
        /// 执行流程结果信息
        /// </summary>
        public T Data { get { return this._data; } }

        /// <summary>
        /// 构造函数
        /// </summary>
        public ProcessResult() { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="data">执行结果</param>
        public ProcessResult(T data)
            : this(data, null)
        {
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="error">错误信息</param>
        public ProcessResult(ProcessError error)
            : this(default(T), error)
        {
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="data">执行结果</param>
        /// <param name="error">错误信息</param>
        public ProcessResult(T data, ProcessError error)
        {
            this._data = data;
            this._error = error;
        }
    }
}

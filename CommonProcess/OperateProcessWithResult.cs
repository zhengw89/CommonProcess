namespace CommonProcess
{
    /// <summary>
    /// 操作业务带返回之底层基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class OperateProcessWithResult<T> : CoreOperateProcess
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="config"></param>
        protected OperateProcessWithResult(IDataProcessConfig config)
            : base(config)
        {
        }

        /// <summary>
        /// 返回执行结果
        /// </summary>
        /// <returns></returns>
        protected abstract T GetResult();

        /// <summary>
        /// 操作主体业务逻辑
        /// </summary>
        /// <returns></returns>
        public T ExecuteProcess()
        {
            return base.ExecuteCoreProcess() ? GetResult() : default(T);
        }
    }
}

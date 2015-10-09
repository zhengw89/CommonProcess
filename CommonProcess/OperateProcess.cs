namespace CommonProcess
{
    /// <summary>
    /// 操作业务底层基类
    /// </summary>
    public abstract class OperateProcess : CoreOperateProcess
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="config"></param>
        protected OperateProcess(IDataProcessConfig config)
            : base(config)
        {
        }

        /// <summary>
        /// 操作主体业务逻辑
        /// </summary>
        /// <returns></returns>
        public bool ExecuteProcess()
        {
            return base.ExecuteCoreProcess();
        }
    }
}

namespace CommonProcess
{
    public abstract class OperateProcessWithResult<T> : CoreOperateProcess
    {
        protected OperateProcessWithResult(IDataProcessConfig config)
            : base(config)
        {
        }

        protected abstract T GetResult();

        public T ExecuteProcess()
        {
            return base.ExecuteCoreProcess() ? GetResult() : default(T);
        }
    }
}

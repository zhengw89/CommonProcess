namespace CommonProcess
{
    public abstract class OperateProcess : CoreOperateProcess
    {
        protected OperateProcess(IDataProcessConfig config)
            : base(config)
        {
        }

        public bool ExecuteProcess()
        {
            return base.ExecuteCoreProcess();
        }
    }
}

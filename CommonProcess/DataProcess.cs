using System;
using CommonProcess.DependentProvider;

namespace CommonProcess
{
    public abstract class DataProcess : CoreProcess
    {
        protected readonly IDataProcessConfig ProcessConfig;

        protected DataProcess(IDataProcessConfig config)
        {
            this.ProcessConfig = config;
        }

        protected abstract bool PreCheckProcessDataLegal();

        protected virtual bool RecordLogInfo()
        {
            return true;
        }

        public virtual void ResetTempData()
        {
            base.ResetError();
        }

        protected T ResolveDependency<T>()
        {
            if (this.ProcessConfig.DependentProvider == null) throw new ArgumentNullException();
            return this.ProcessConfig.DependentProvider.Resolve<T>();
        }

        protected void CacheIdIsNotExists(string type = null)
        {
            base.CacheError(-100, type + "Id not exist");
        }

        protected void CacheParameterIsNull()
        {
            base.CacheError(-100, "arg is null");
        }
    }

    public interface IDataProcessConfig
    {
        IDependentProvider DependentProvider { get; set; }
    }

    public class DataProcessConfig : IDataProcessConfig
    {
        public IDependentProvider DependentProvider { get; set; }
    }
}

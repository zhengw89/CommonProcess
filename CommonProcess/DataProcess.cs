using System;
using CommonProcess.DependentProvider;

namespace CommonProcess
{
    /// <summary>
    /// 数据相关底层核心操作类
    /// </summary>
    public abstract class DataProcess : CoreProcess
    {
        protected readonly IDataProcessConfig ProcessConfig;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="config"></param>
        protected DataProcess(IDataProcessConfig config)
        {
            this.ProcessConfig = config;
        }

        /// <summary>
        /// 检查流程参数方法
        /// </summary>
        /// <returns></returns>
        protected abstract bool PreCheckProcessDataLegal();

        /// <summary>
        /// 记录相关日志信息方法
        /// </summary>
        /// <returns></returns>
        protected virtual bool RecordLogInfo()
        {
            return true;
        }

        /// <summary>
        /// 重置方法
        /// </summary>
        public virtual void ResetTempData()
        {
            base.ResetError();
        }

        /// <summary>
        /// 依赖解析
        /// </summary>
        /// <typeparam name="T">依赖类型</typeparam>
        /// <returns></returns>
        protected T ResolveDependency<T>()
        {
            if (this.ProcessConfig.DependentProvider == null) throw new ArgumentNullException();
            return this.ProcessConfig.DependentProvider.Resolve<T>();
        }

        #region 捕捉基本错误辅助方法

        /// <summary>
        /// 捕捉参数错误信息
        /// </summary>
        /// <param name="errorMessage">错误信息</param>
        protected void CacheArgumentError(string errorMessage)
        {
            CacheError(Error.ErrorCode.ParameterError, errorMessage);
        }

        /// <summary>
        /// 捕捉参数为空错误信息
        /// </summary>
        /// <param name="agumentName">参数名称</param>
        protected void CacheArgumentIsNullError(string agumentName)
        {
            CacheError(Error.ErrorCode.ParameterError, string.Format("argument {0} is null", agumentName));
        }

        #endregion
    }

    /// <summary>
    /// 数据相关底层核心操作类配置定义
    /// </summary>
    public interface IDataProcessConfig
    {
        /// <summary>
        /// 依赖容器对象
        /// </summary>
        IDependentProvider DependentProvider { get; set; }
    }

    /// <summary>
    /// 数据相关底层核心操作类配置实现
    /// </summary>
    public class DataProcessConfig : IDataProcessConfig
    {
        public IDependentProvider DependentProvider { get; set; }
    }
}

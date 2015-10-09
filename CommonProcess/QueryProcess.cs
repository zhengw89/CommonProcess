using System;

namespace CommonProcess
{
    /// <summary>
    /// 查询业务基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class QueryProcess<T> : DataProcess
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="config"></param>
        protected QueryProcess(IDataProcessConfig config)
            : base(config)
        {
        }

        /// <summary>
        /// 查询主体业务
        /// </summary>
        /// <returns></returns>
        protected abstract T Query();

        /// <summary>
        /// 执行查询业务
        /// </summary>
        /// <returns></returns>
        public T ExecuteQueryProcess()
        {
            try
            {
                if (!PreCheckProcessDataLegal())
                {
                    if (!HasError)
                    {
                        throw new InvalidOperationException();
                    }
                }
                else if (HasError)
                {
                    throw new InvalidOperationException();
                }
                return this.Query();
            }
            catch (Exception ex)
            {
                base.CacheError(Error.ErrorCode.UnknownError, "QueryProcess error:" + ex.Message);
                return default(T);
            }
        }
    }
}

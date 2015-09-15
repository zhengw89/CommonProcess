using System;

namespace CommonProcess
{
    public abstract class QueryProcess<T> : DataProcess
    {
        protected QueryProcess(IDataProcessConfig config) : base(config)
        {
        }

        protected abstract T Query();
        
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
                base.CacheError(-100, "QueryProcess error:" + ex.Message);
                return default(T);
            }
        }
        
        protected void CachePagedAgumentIllegal()
        {
            base.CacheError(-100, "value of pageIndex or pageSize is wrong,please check the value");
        }
    }
}

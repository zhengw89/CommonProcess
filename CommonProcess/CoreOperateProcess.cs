using System;
using System.Collections.Generic;
using System.Linq;

namespace CommonProcess
{
    /// <summary>
    /// 操作流程底层类
    /// </summary>
    public abstract class CoreOperateProcess : DataProcess
    {
        private delegate bool SubProcess();

        private readonly List<SubProcess> _subProcessesChain;

        private bool _directSuccessProcess = false;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="config"></param>
        protected CoreOperateProcess(IDataProcessConfig config)
            : base(config)
        {
            this._subProcessesChain = new List<SubProcess>();
        }

        /// <summary>
        /// 主体业务处理方法
        /// </summary>
        /// <returns></returns>
        protected abstract bool ProcessMainData();

        /// <summary>
        /// 相关业务处理方法
        /// </summary>
        /// <returns></returns>
        protected virtual bool ProcessRelationData()
        {
            return true;
        }

        /// <summary>
        /// 直接成功完成所有流程
        /// </summary>
        protected void DirectSuccessProcess()
        {
            _directSuccessProcess = true;
        }

        /// <summary>
        /// 执行业务流程
        /// </summary>
        /// <returns></returns>
        protected bool ExecuteCoreProcess()
        {
            if (!this._subProcessesChain.Any())
            {
                RegistSubProcessChain();
            }

            try
            {
                OnProcessStart();

                foreach (var subProcess in this._subProcessesChain)
                {
                    if (!subProcess.Invoke())
                    {
                        if (!HasError)
                        {
                            throw new InvalidOperationException();
                        }
                        return false;
                    }
                    if (this._directSuccessProcess)
                    {
                        break;
                    }
                }

                OnProcessSuccess();
                return true;
            }
            catch (Exception ex)
            {
                base.CacheError(-100, "OperateProcess error:" + ex.Message);
                OnCacheException(ex);
                return false;
            }
            finally
            {
                OnProcessComplete();
            }
        }

        /// <summary>
        /// 注册
        /// </summary>
        private void RegistSubProcessChain()
        {
            this._subProcessesChain.Add(BeforeCheck);
            this._subProcessesChain.Add(PreCheckProcessDataLegal);
            this._subProcessesChain.Add(AfterCheck);

            this._subProcessesChain.Add(BeforeMainProcess);
            this._subProcessesChain.Add(ProcessMainData);
            this._subProcessesChain.Add(AfterMainProcess);

            this._subProcessesChain.Add(BeforeRelationProcess);
            this._subProcessesChain.Add(ProcessRelationData);
            this._subProcessesChain.Add(AfterRelationProcess);

            this._subProcessesChain.Add(BeforeRecordLog);
            this._subProcessesChain.Add(RecordLogInfo);
            this._subProcessesChain.Add(AfterRecordLog);
        }

        #region 钩子

        #region 流程生命周期钩子
        /// <summary>
        /// 流程开始执行
        /// </summary>
        protected virtual void OnProcessStart()
        {

        }
        /// <summary>
        /// 流程执行成功
        /// </summary>
        protected virtual void OnProcessSuccess()
        {

        }
        /// <summary>
        /// 流程执行完成，不论成功失败
        /// </summary>
        protected virtual void OnProcessComplete()
        {

        }
        /// <summary>
        /// 流程捕捉到异常
        /// </summary>
        /// <param name="ex"></param>
        protected virtual void OnCacheException(Exception ex)
        {

        }

        #endregion

        #region 子流程钩子
        /// <summary>
        /// 检查参数环节之前
        /// </summary>
        /// <returns></returns>
        protected virtual bool BeforeCheck()
        {
            return true;
        }
        /// <summary>
        /// 检查参数环节之后
        /// </summary>
        /// <returns></returns>
        protected virtual bool AfterCheck()
        {
            return true;
        }
        /// <summary>
        /// 主体业务流程之前
        /// </summary>
        /// <returns></returns>
        protected virtual bool BeforeMainProcess()
        {
            return true;
        }
        /// <summary>
        /// 主体业务流程之后
        /// </summary>
        /// <returns></returns>
        protected virtual bool AfterMainProcess()
        {
            return true;
        }
        /// <summary>
        /// 相关业务流程之前
        /// </summary>
        /// <returns></returns>
        protected virtual bool BeforeRelationProcess()
        {
            return true;
        }
        /// <summary>
        /// 相关业务流程之后
        /// </summary>
        /// <returns></returns>
        protected virtual bool AfterRelationProcess()
        {
            return true;
        }
        /// <summary>
        /// 记录日志之前
        /// </summary>
        /// <returns></returns>
        protected virtual bool BeforeRecordLog()
        {
            return true;
        }
        /// <summary>
        /// 记录日志之后
        /// </summary>
        /// <returns></returns>
        protected virtual bool AfterRecordLog()
        {
            return true;
        }

        #endregion

        #endregion
    }
}

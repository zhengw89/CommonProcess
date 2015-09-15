using System;
using System.Collections.Generic;
using System.Linq;

namespace CommonProcess
{
    public abstract class CoreOperateProcess : DataProcess
    {
        private delegate bool SubProcess();

        private readonly List<SubProcess> _subProcessesChain;

        private bool _directSuccessProcess = false;

        protected CoreOperateProcess(IDataProcessConfig config)
            : base(config)
        {
            this._subProcessesChain = new List<SubProcess>();
        }

        protected abstract bool ProcessMainData();

        protected virtual bool ProcessRelationData()
        {
            return true;
        }

        protected void DirectSuccessProcess()
        {
            _directSuccessProcess = true;
        }

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

        #region Hook

        #region Process Lifecyle Hook

        protected virtual void OnProcessStart()
        {

        }

        protected virtual void OnProcessSuccess()
        {

        }

        protected virtual void OnProcessComplete()
        {

        }

        protected virtual void OnCacheException(Exception ex)
        {

        }

        #endregion

        #region Sub Process Hook

        protected virtual bool BeforeCheck()
        {
            return true;
        }

        protected virtual bool AfterCheck()
        {
            return true;
        }

        protected virtual bool BeforeMainProcess()
        {
            return true;
        }

        protected virtual bool AfterMainProcess()
        {
            return true;
        }

        protected virtual bool BeforeRelationProcess()
        {
            return true;
        }

        protected virtual bool AfterRelationProcess()
        {
            return true;
        }

        protected virtual bool BeforeRecordLog()
        {
            return true;
        }

        protected virtual bool AfterRecordLog()
        {
            return true;
        }

        #endregion

        #endregion
    }
}

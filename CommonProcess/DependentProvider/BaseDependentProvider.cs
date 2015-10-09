using System;
using System.Collections.Generic;

namespace CommonProcess.DependentProvider
{
    /// <summary>
    /// 基础依赖容器
    /// </summary>
    public abstract class BaseDependentProvider : IDependentProvider
    {
        private bool _registCompleted;
        private readonly Dictionary<Type, object> _dependentDictionary;

        /// <summary>
        /// 基础依赖容器构造函数
        /// </summary>
        protected BaseDependentProvider()
        {
            this._dependentDictionary = new Dictionary<Type, object>();
        }

        /// <summary>
        /// 注册默认方法
        /// </summary>
        protected abstract void RegistDefault();

        /// <summary>
        /// 注册辅助方法
        /// </summary>
        /// <typeparam name="T">注册类型</typeparam>
        /// <param name="obj">注册对象</param>
        protected void RegisterDependent<T>(T obj)
        {
            if (!this._dependentDictionary.ContainsKey(typeof(T)))
            {
                this._dependentDictionary.Add(typeof(T), obj);
            }
            else
            {
                this._dependentDictionary[typeof(T)] = obj;
            }
        }

        /// <summary>
        /// 解析依赖对象
        /// </summary>
        /// <typeparam name="T">依赖对象类型</typeparam>
        /// <returns></returns>
        public T Resolve<T>()
        {
            if (!this._registCompleted)
            {
                this.RegistDefault();
                this._registCompleted = true;
            }

            if (!this._dependentDictionary.ContainsKey(typeof(T)))
            {
                throw new ArgumentOutOfRangeException("unknow dependency");
            }

            return (T)this._dependentDictionary[typeof(T)];
        }
    }
}

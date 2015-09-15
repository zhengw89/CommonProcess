using System;
using System.Collections.Generic;

namespace CommonProcess.DependentProvider
{
    public abstract class BaseDependentProvider : IDependentProvider
    {
        private bool _registCompleted;
        private readonly Dictionary<Type, object> _dependentDictionary;

        protected BaseDependentProvider()
        {
            this._dependentDictionary = new Dictionary<Type, object>();
        }

        protected abstract void RegistDefault();

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

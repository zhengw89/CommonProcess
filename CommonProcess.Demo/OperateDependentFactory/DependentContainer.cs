using System;
using System.Collections.Concurrent;
using CommonProcess.DependentProvider;

namespace CommonProcess.Demo.OperateDependentFactory
{
    internal class DependentContainer : IDependentContainer
    {
        private readonly ConcurrentDictionary<Type, object> _factories;

        public DependentContainer()
        {
            _factories = new ConcurrentDictionary<Type, object>();
        }

        public void Register<TDependentSource>(Func<BaseDependentProvider> factory)
        {
            Type key = typeof(TDependentSource);
            _factories[key] = factory;
        }

        public BaseDependentProvider Resolve<TDependentSource>()
        {
            object factory;

            if (_factories.TryGetValue(typeof(TDependentSource), out factory))
                return ((Func<BaseDependentProvider>)factory)();

            throw new ArgumentOutOfRangeException();
        }
    }
}

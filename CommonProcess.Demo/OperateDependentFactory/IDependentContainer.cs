using System;
using CommonProcess.DependentProvider;

namespace CommonProcess.Demo.OperateDependentFactory
{
    internal interface IDependentContainer
    {
        void Register<TDependentSource>(Func<BaseDependentProvider> factory);

        BaseDependentProvider Resolve<TDependentSource>();
    }
}

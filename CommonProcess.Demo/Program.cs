using System;
using CommonProcess.Demo.OperateDependentFactory;
using CommonProcess.DependentProvider;

namespace CommonProcess.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var creator = new BookCreator(new DataProcessConfig()
            {
                DependentProvider = ResolveOperateDependent<BookCreator>()
            }, "C# book");
            Console.WriteLine(!creator.ExecuteProcess() ? creator.GetError().ToString() : "Success");
        }

        private static IDependentProvider ResolveOperateDependent<T>()
        {
            return OperateDependentLocator.Container.Resolve<T>();
        }
    }
}

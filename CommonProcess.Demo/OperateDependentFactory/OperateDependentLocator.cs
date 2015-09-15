namespace CommonProcess.Demo.OperateDependentFactory
{
    internal class OperateDependentLocator
    {
        private static readonly OperateDependentLocator Instance = new OperateDependentLocator();

        private readonly IDependentContainer _container;
        public static IDependentContainer Container { get { return Instance._container; } }

        private OperateDependentLocator()
        {
            _container = new DependentContainer();
            RegisterDefaults(_container);
        }

        private void RegisterDefaults(IDependentContainer container)
        {
            container.Register<BookCreator>(() => new BookCreatorDependentProvider());
        }
    }
}

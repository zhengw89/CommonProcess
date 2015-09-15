namespace CommonProcess.DependentProvider
{
    public interface IDependentProvider
    {
        T Resolve<T>();
    }
}

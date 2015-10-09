namespace CommonProcess.DependentProvider
{
    /// <summary>
    /// 依赖容器
    /// </summary>
    public interface IDependentProvider
    {
        /// <summary>
        /// 解析依赖
        /// </summary>
        /// <typeparam name="T">依赖类型</typeparam>
        /// <returns>依赖类型对象</returns>
        T Resolve<T>();
    }
}

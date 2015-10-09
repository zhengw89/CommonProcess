namespace CommonProcess.Error
{
    /// <summary>
    /// 错误类型枚举
    /// </summary>
    public enum ErrorCode
    {
        /// <summary>
        /// 未知错误
        /// </summary>
        [ErrorCodeDescription("Unknow error")]
        UnknownError = 1,

        /// <summary>
        /// 系统错误
        /// </summary>
        [ErrorCodeDescription("System error")]
        SystemError = 10001,

        /// <summary>
        /// 参数错误
        /// </summary>
        [ErrorCodeDescription("Argument error")]
        ParameterError = 20001,

        /// <summary>
        /// 数据库错误
        /// </summary>
        [ErrorCodeDescription("Database error")]
        DbError = 20002,

        /// <summary>
        /// 数据不存在
        /// </summary>
        [ErrorCodeDescription("Not exist")]
        NoData = 20003,
    }
}

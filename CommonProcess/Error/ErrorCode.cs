namespace CommonProcess.Error
{
    public enum ErrorCode
    {
        [ErrorCodeDescription("Unknow error")]
        UnknownError = 1,

        [ErrorCodeDescription("System error")]
        SystemError = 10001,

        [ErrorCodeDescription("Argument error")]
        ParameterError = 20001,

        [ErrorCodeDescription("Database error")]
        DbError = 20002,

        [ErrorCodeDescription("Not exist")]
        NoData = 20003,

        [ErrorCodeDescription("Database save error")]
        SaveDbChangesFailed = 20004,

        [ErrorCodeDescription("File save error")]
        SaveFileFailed = 20005
    }
}

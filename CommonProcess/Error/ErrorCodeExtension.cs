using System.Collections.Generic;
using System.Reflection;

namespace CommonProcess.Error
{
    internal static class ErrorCodeExtension
    {
        static readonly Dictionary<ErrorCode, ErrorCodeDescriptionAttribute> DescriptionMap = new Dictionary<ErrorCode, ErrorCodeDescriptionAttribute>();

        public static ErrorCodeDescriptionAttribute GetErrorCodeDescription(ErrorCode errorCode)
        {
            if (DescriptionMap.ContainsKey(errorCode))
            {
                return DescriptionMap[errorCode];
            }

            FieldInfo provider = errorCode.GetType().GetField(errorCode.ToString());
            var attributes = (ErrorCodeDescriptionAttribute[])provider.GetCustomAttributes(typeof(ErrorCodeDescriptionAttribute), false);

            ErrorCodeDescriptionAttribute errorCodeDescription = attributes[0];

            DescriptionMap[errorCode] = errorCodeDescription;

            return errorCodeDescription;
        }
    }
}

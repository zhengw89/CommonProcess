using System;

namespace CommonProcess.Error
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ErrorCodeDescriptionAttribute : Attribute
    {
        public string ErrorCodeDescription { get; set; }

        public ErrorCodeDescriptionAttribute(string errorCodeDescription)
        {
            this.ErrorCodeDescription = errorCodeDescription;
        }
    }
}

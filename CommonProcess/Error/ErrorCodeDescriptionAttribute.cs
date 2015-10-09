using System;

namespace CommonProcess.Error
{
    /// <summary>
    /// 枚举错误信息属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class ErrorCodeDescriptionAttribute : Attribute
    {
        /// <summary>
        /// 错误枚举描述信息
        /// </summary>
        public string ErrorCodeDescription { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="errorCodeDescription"></param>
        public ErrorCodeDescriptionAttribute(string errorCodeDescription)
        {
            this.ErrorCodeDescription = errorCodeDescription;
        }
    }
}

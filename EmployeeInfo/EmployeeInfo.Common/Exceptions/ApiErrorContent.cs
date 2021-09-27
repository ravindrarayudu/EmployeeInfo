using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeInfo.Common.Exceptions
{
    public class ApiErrorContent
    {
        public ApiErrorContent() { }
        public ApiErrorContent(string errorMessage, int errroCode, string exceptionIdentifier,
            Dictionary<string, object> validationErrors, Dictionary<string, object> additionalData)
        {
            ErrorMessage = errorMessage;
            ErrorCode = errroCode;
            ExceptionIdentifier = exceptionIdentifier;
            ValidationErrors = validationErrors;
            AdditionalData = additionalData;
        }

        /// <summary>
        /// 
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ExceptionIdentifier { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, object> ValidationErrors { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, object> AdditionalData { get; set; }
    }
}

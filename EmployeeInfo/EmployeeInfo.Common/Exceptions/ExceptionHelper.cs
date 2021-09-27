using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace EmployeeInfo.Common.Exceptions
{
    public static class ExceptionHelper
    {
        #region Constants
        public const int FatalErrorCode = 100;
        public const int GeneralExceptionCode = 101;
        public const int DbExceptionCode = 102;
        public const int ApplicationErrorCode = 103;
        public const int BrokerApiErrorCode = 104;
        public const int UserProfileApiErrorCode = 105;
        public const int CarrierApiErrorCode = 106;
        public const int EmployerApiErrorCode = 107;
        public const int ValidationErrorCode = 108;
        public const int DomainDataErrorCode = 109;
        #endregion

        #region Constants

        public const string FatalErrorMessage = "Fatal Error.";
        public const string EmptyErrorMessage = "{0} should not be empty.";
        public const string DateFormatErrorMessage = "{0} is not in correct format. the format should be in yyyy-mm-dd format";

        #endregion

        private const string ExceptionDetailsFormat = @"Message:{1}{0}StackTrace:{2}{0}InnerException:{3}";

        private static readonly Dictionary<ApiExceptionCategory, ExceptionTypeMapping> ExceptionMappings =
           new Dictionary<ApiExceptionCategory, ExceptionTypeMapping>();



        static ExceptionHelper()
        {
            LoadExceptionCodeMapping();
        }

        public static void HandleLibraryException(this Exception e, string title = "VBCApis")
        {
            var message = PrepareExceptionDetails(e);

            //log exception TODO
        }
        public static string PrepareExceptionDetails(Exception exception)
        {
            var innerExceptionDetails = String.Empty;
            if (null != exception)
            {
                if (null != exception.InnerException)
                    innerExceptionDetails = exception.InnerException.Message + "\r\n" +
                                            exception.InnerException.StackTrace;
                string ExceptionDetailsFormat = @"Message:{1}{0}StackTrace:{2}{0}InnerException:{3}";
                return string.Format(ExceptionDetailsFormat, Environment.NewLine, exception.Message,
                                     exception.StackTrace, innerExceptionDetails);

            }
            return String.Empty;
        }

        public static Dictionary<ApiExceptionCategory, ExceptionTypeMapping> ExceptionCategoryMapping { get { return ExceptionMappings; } }

        private static void LoadExceptionCodeMapping()
        {
            ExceptionMappings.Add(ApiExceptionCategory.BusinessException,
                                      new ExceptionTypeMapping(ApiExceptionCategory.BusinessException,
                                                                1000, HttpStatusCode.BadRequest,
                                                                TraceEventType.Warning));

            ExceptionMappings.Add(ApiExceptionCategory.ValidationException,
                                      new ExceptionTypeMapping(ApiExceptionCategory.ValidationException,
                                                                1001, HttpStatusCode.BadRequest,
                                                                TraceEventType.Warning));

            ExceptionMappings.Add(ApiExceptionCategory.DbException,
                                      new ExceptionTypeMapping(ApiExceptionCategory.DbException,
                                                                1002, HttpStatusCode.InternalServerError,
                                                                TraceEventType.Error));


            ExceptionMappings.Add(ApiExceptionCategory.Configuration,
                                       new ExceptionTypeMapping(ApiExceptionCategory.Configuration,
                                                                 1003, HttpStatusCode.InternalServerError,
                                                                 TraceEventType.Error));

            ExceptionMappings.Add(ApiExceptionCategory.CommonLibrary,
                                     new ExceptionTypeMapping(ApiExceptionCategory.CommonLibrary,
                                                               1004, HttpStatusCode.InternalServerError,
                                                               TraceEventType.Error));


            ExceptionMappings.Add(ApiExceptionCategory.UnhandledError,
                                      new ExceptionTypeMapping(ApiExceptionCategory.UnhandledError,
                                                                1005, HttpStatusCode.InternalServerError,
                                                                TraceEventType.Error));

            ExceptionMappings.Add(ApiExceptionCategory.Critical,
                                      new ExceptionTypeMapping(ApiExceptionCategory.Critical,
                                                                1006, HttpStatusCode.InternalServerError,
                                                                TraceEventType.Critical));

            ExceptionMappings.Add(ApiExceptionCategory.Application,
                                     new ExceptionTypeMapping(ApiExceptionCategory.Application,
                                                               1007, HttpStatusCode.InternalServerError,
                                                               TraceEventType.Error));          
        }


        public static ApiErrorContent PrepareHttpError(int exceptionCode, string exceptionIdentifier, string exceptionMessage)
        {
            var resp = new ApiErrorContent
            {
                ErrorMessage = exceptionMessage,
                ExceptionIdentifier = exceptionIdentifier,
                ErrorCode = exceptionCode
            };

            return resp;
        }       
        
        public static HttpStatusCode GetHttpStatusCode(ApiExceptionCategory exceptionType)
        {
            return ExceptionMappings[exceptionType].MappingHttpStatusCode;
        }
    }
    public class ExceptionTypeMapping
    {
        public ApiExceptionCategory ExceptionCategory { get; private set; }
        public int MappingEventId { get; private set; }
        public HttpStatusCode MappingHttpStatusCode { get; private set; }
        public TraceEventType Severity { get; set; }

        public ExceptionTypeMapping(ApiExceptionCategory category, int mappingLogEventId,
                                   HttpStatusCode mappingHttpStatusCode, TraceEventType severity)
        {
            ExceptionCategory = category;
            MappingEventId = mappingLogEventId;
            MappingHttpStatusCode = mappingHttpStatusCode;
            Severity = severity;
        }
    }

    [Serializable]
    public class ApiException : Exception
    {
        public ApiExceptionCategory ExceptionType { get; set; }
        public int ExceptionCode { get; set; }

        public string ExceptionMessage { get; set; }

        public ApiException(string message, Exception exceptionCaught, ApiExceptionCategory exceptionType, int exceptionCode)
            : base(message, exceptionCaught)
        {
            ExceptionType = exceptionType;
            ExceptionCode = exceptionCode;
            ExceptionMessage = message;
        }

        public ApiException(string message, ApiExceptionCategory exceptionType, int exceptionCode)
            : base(message)
        {
            ExceptionType = exceptionType;
            ExceptionCode = exceptionCode;
            ExceptionMessage = message;
        }
    }
    public enum ApiExceptionCategory
    {
        UnhandledError,
        DbException,
        BusinessException,
        ValidationException,
        Critical,
        CommonLibrary,
        Configuration,
        Application    

    }
}

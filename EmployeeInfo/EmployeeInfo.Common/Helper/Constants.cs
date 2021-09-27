using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeInfo.Common.Helper
{
    public class Constants
    {

        #region Global Constants
                
        public static string VBCDBConnection = "VbcDBConnection";

        #endregion
        public static class ErrorMessageConstants
        {
            #region Generic Error Messages

            public const string MandatoryField = "{0} field is mandatory for this action";
            public const string ErrorInMethod = "An error occured in method {0} of layer {1}";
            public const string ErrorInLength = "Field is of {0} character";

            #endregion

            #region Broker Error Messages

            public static string BrokerControllerError = "An error occurred in method {0} of Broker controller";
            public static string BrokerRepositoryError = "An error occurred in method {0} of Broker repository";
            public static string BrokerRepositoryDbError = "Db exception occurred in method {0} of Borker repository";
            public static string BrokerValidationError = "Validation errors occured on the request";

            public static string BrokerRepositoryUpdateValidationErrorCanNotFoundRecord = "Can not found a record with id : {0}";
            public static string BrokerRepositoryUpdateNonProjectValidationErrorNothingtoUpdate = "No new changes to udpate";

            public static string NullorEmptyValidationError = "The input parameter(s) {0} cannot be null or empty";          
            public static string GetDetailedBrokerDbError = "An error occurred while fetching Broker details from Db";
            public static string GetDetailedBrokerError = "An error occurred";
          

            public static string NullResultError = "The results values {0} should not be null";
            public static string NotFoundInDatabase = "Entity with id {0} could not be fetched from the DB in {1}";
            public static string EnumTypeNotFound = "{0} is not a valid value for type {1}";

            public static string RequiredIfValidationError = "Parameter cannot be null or empty";          

            public static string InvalidResource = "Not a valid user";

            public static string UnauthorizedAccess = "Authorization has been denied for this request";
            #endregion
          
            #region Domain Error Messages 

            public static string DomainRepositoryError = "An error occured in the method {0} of domain repository";
            public static string DomainControllerErrorMessage = "An error occured in the method {0} of domain controller";
            public static string DomainDataValidationError = "Validation errors occured on the request";
            #endregion
            
        }
    
    }
}

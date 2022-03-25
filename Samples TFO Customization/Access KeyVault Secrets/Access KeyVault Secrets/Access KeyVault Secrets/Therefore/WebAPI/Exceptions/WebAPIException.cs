using System;
using System.Net;
using Therefore.WebAPI.Service.Contract.Exceptions;

namespace Therefore.WebAPI.Exceptions
{
    /// <summary>
    /// Represents exception in WepAPI/API.
    /// </summary>
    public class WebAPIException : Exception
    {
        public WSErrorSource ErrorSource { get; set; }

        public long? ErrorCode { get; set; }

        public WebAPIException()
            : base() { }

        public WebAPIException(string message, WSErrorSource errorSource, long? errorCode)
            : base(message)
        {
            ErrorCode = errorCode;
            ErrorSource = errorSource;
        }

        public WebAPIException(string message, Exception inner, WSErrorSource errorSource, long? errorCode)
            : base(message, inner)
        {
            ErrorCode = errorCode;
            ErrorSource = errorSource;
        }

        public static bool TryDecodeWebAPIException(HttpStatusCodeException httpException, out WebAPIException decodedAPIException)
        {
            WSFaultDetails wsFaultDetails;
            if ((httpException.StatusCode == (int)HttpStatusCode.BadRequest || httpException.StatusCode == (int)HttpStatusCode.InternalServerError)
                && WebAPIRestFault.TryDeserialize(httpException.ResponseContent, out wsFaultDetails))
            {
                decodedAPIException = new WebAPIException(wsFaultDetails.WSError.ErrorMessage, httpException.InnerException, wsFaultDetails.WSError.ErrorSource, wsFaultDetails.WSError.ErrorCode);
                return true;
            }

            decodedAPIException = null;
            return false;
        }
    }
}

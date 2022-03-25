using System;

namespace Therefore.WebAPI.Exceptions
{
    public class HttpStatusCodeException : Exception
    {
        public int StatusCode { get; private set; }
        public string ResponseContent { get; private set; }
        public HttpStatusCodeException(int statusCode, string message, string responseContent) : base(message)
        {
            StatusCode = statusCode;
            ResponseContent = responseContent;
        }
    }
}

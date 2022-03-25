using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using Therefore.WebAPI.Exceptions;

namespace Therefore.WebAPI
{
    public class WebApiClient
    {
        private string _userName;
        private string _key;
        private WebAPIClientPlatformCode.KeyType _keyType;
        private string _serviceUrl;
        private string _tenant;
        private string _language;
        private TimeSpan _requestTimeout;
        private string _timezoneIANA;

        public WebApiClient(string userName, string key, bool isToken, string serviceUrl,
            string tenant, string language, TimeSpan requestTimeout, string timezoneIANA)
        {
            _userName = userName;
            _key = key;
            if (isToken)
                _keyType = WebAPIClientPlatformCode.KeyType.defaultToken;
            else
                _keyType = WebAPIClientPlatformCode.KeyType.password;
            Init(serviceUrl, tenant, language, requestTimeout, timezoneIANA);
        }

        public WebApiClient(string bearerToken, string serviceUrl,
            string tenant, string language, TimeSpan requestTimeout, string timezoneIANA)
        {
            _userName = String.Empty;
            _key = bearerToken;
            _keyType = WebAPIClientPlatformCode.KeyType.bearerToken;
            Init(serviceUrl, tenant, language, requestTimeout, timezoneIANA);
        }

        private void Init(string serviceUrl, string tenant, string language, TimeSpan requestTimeout, string timezoneIANA)
        {
            _serviceUrl = serviceUrl;
            _tenant = tenant;
            _language = language;
            _requestTimeout = requestTimeout;
            _timezoneIANA = timezoneIANA;
        }

        /// <summary>
        /// Executes request and returns response from the server by using the user name/key.
        /// </summary>
        /// <remarks>Throws exceptions for all the errors.</remarks>
        public async Task<string> RetrieveToken(string userName, string password, bool moveLicense = false)
        {
            GetConnectionTokenResponse getTokenResponse = null;
            MoveUserLicenseResponse moveLicenseResponse = null;

            if (moveLicense)
            {
                moveLicenseResponse = await SendRequest<MoveUserLicenseRequest, MoveUserLicenseResponse>(new MoveUserLicenseRequest());
            }

            getTokenResponse = await SendRequest<GetConnectionTokenParams, GetConnectionTokenResponse>(new GetConnectionTokenParams());
            return getTokenResponse?.Token;
        }

        /// <summary>
        /// Executes request and returns response from the server by using the user name/key.
        /// </summary>
        /// <remarks>Throws exceptions for all the errors.</remarks>
        public async Task<GetWebAPIServerVersionResponse> GetWebAPIServerVersion()
        {
            return await SendRequest<GetWebAPIServerVersionParams, GetWebAPIServerVersionResponse>(new GetWebAPIServerVersionParams());
        }

        public async Task<GetConnectedUserResponse> GetConnectedUser()
        {
            return await SendRequest<GetConnectedUserParams, GetConnectedUserResponse>(new GetConnectedUserParams());
        }


        /// <summary>
        /// Executes request and returns response from the server by using the user token.
        /// Message can be sent to the runtime coordinator in case of error.
        /// </summary>
        /// <remarks>Uses IMessagingService to notify about wrong credentials. For all the other errors throws exceptions.</remarks>
        public async Task<TResp> SendRequest<TReq, TResp>(TReq requestData)
            where TReq : class
            where TResp : class
        {
            return await SendRequest<TReq, TResp>(requestData, _requestTimeout);
        }

        /// <summary>
        /// Executes request and returns response from the server by using the user token.
        /// Message can be sent to the runtime coordinator in case of error.
        /// </summary>
        /// <remarks>Uses IMessagingService to notify about wrong credentials. For all the other errors throws exceptions.</remarks>
        public async Task<TResp> SendRequest<TReq, TResp>(TReq requestData, TimeSpan timeout)
            where TReq : class
            where TResp : class
        {
            return await WebAPIClientPlatformCode.SendRequestRaw<TReq, TResp>(_serviceUrl, requestData, _userName, _key, _keyType, _tenant, _language, timeout, _timezoneIANA);
        }
    }
}
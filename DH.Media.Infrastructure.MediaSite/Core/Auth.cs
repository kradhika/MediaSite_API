using System;
using System.Text;
using RestSharp;
using RestSharp.Authenticators;
using DH.Media.Core.Enterprise.Common;

namespace DH.Media.Infrastructure.Media.Core
{
    public class Auth : IAuthenticator, IAuth
    {
        #region Fields

        private readonly string _userName;
        private readonly string _password;
        private readonly string _apiKey;

        #endregion

        #region Public Methods
        /// <summary>
        /// Constructor for authentication
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="apiKey"></param>
        public Auth(string userName, string password, string apiKey)
        {
            _userName = userName;
            _password = password;
            _apiKey = apiKey;
        }

        /// <summary>
        /// Request For Authentication Client
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        public void Authenticate(IRestClient client, IRestRequest request)
        {
            var basicAuthHeaderValue = string.Format(Constants.BasicHolder, 
                                                     Convert.ToBase64String(Encoding.UTF8.GetBytes(
                                                                string.Format(Constants.PlaceHolder, _userName, _password))));
            request.AddHeader(Constants.HeaderAuthorization, basicAuthHeaderValue);
            request.AddHeader(Constants.Sfapikey, _apiKey);
        }
        #endregion
    }
}

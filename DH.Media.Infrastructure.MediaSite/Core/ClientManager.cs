using System;
using RestSharp;
using DH.Media.Core.Enterprise.Common;
using DH.Media.Infrastructure.Media.Mappings;

namespace DH.Media.Infrastructure.Media.Core
{
    public class ClientManager : IClientManager
    {
        #region Public Properites
        public RestClient Client => GetClient();

        #endregion

        #region Private Fields

        private static RestClient _client;
        private readonly ConnectMap _mediasiteConn;
        private readonly Uri _baseUri;

        #endregion

        #region Public Methods
        public ClientManager(ConnectMap mediasiteConn)
        {
            _mediasiteConn = mediasiteConn;
            _baseUri = new Uri(mediasiteConn.EndpointAddress);
        }

        #endregion

        #region Private Methods
        private RestClient GetClient()
        {
            return _client ?? (_client = new RestClient(new Uri(_baseUri, Constants.BaseUri).ToString())
            {
                Authenticator = new Auth(_mediasiteConn.UserName, _mediasiteConn.Password, _mediasiteConn.ApiKey)
            });
        }

        #endregion
    }
}

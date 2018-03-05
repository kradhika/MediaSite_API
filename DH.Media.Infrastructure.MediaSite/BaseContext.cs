using DH.Media.Core.Enterprise.Common;
using DH.Media.Infrastructure.Media.Core;
using DH.Media.Infrastructure.Media.Mappings;

namespace DH.Media.Infrastructure.Media
{
    /// <summary>
    /// Provides Media Base Context
    /// </summary>
    public class BaseContext
    {
        #region Connection Object 

        private readonly ConnectMap _mediasiteConn = new ConnectMap();

        #endregion

        #region Fields

        private IClientManager _clientManagerField;

        #endregion

        #region Interface
        protected IClientManager ClientManager => _clientManagerField ?? (_clientManagerField = new ClientManager(_mediasiteConn));

        #endregion

        #region Constructor 

        /// <summary>
        /// Base Context Constructor
        /// </summary>
        protected BaseContext()
        {
            var username = KeyVaultValues.MsUserName;
            var password = KeyVaultValues.MsPassword;
            var apikey = KeyVaultValues.MsApiKey;

            _mediasiteConn.UserName = username;
            _mediasiteConn.Password = password;
            _mediasiteConn.ApiKey = apikey;
            _mediasiteConn.EndpointAddress = ConfigurationHelper.MsEndPointUri;
        }

        #endregion
    }
}

using System;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Azure.KeyVault;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using NLog;
using System.Security.Cryptography;

namespace DH.Media.Core.Enterprise.Common
{
    public static class KeyVaultValues
    {
        #region Data Members

        /// <summary>
        /// Blob Storage Access Policy Name   
        /// </summary>
        public static string AccessPolicyName => GetKeyValue(ConfigurationHelper.AccessPolicyName);

        /// <summary>
        /// Account Sid
        /// </summary>
        public static string AccountSid => GetKeyValue(ConfigurationHelper.AccountSid);

        /// <summary>
        /// Twilio Authentication Token
        /// </summary>
        public static string AuthToken => GetKeyValue(ConfigurationHelper.AuthToken);

        /// <summary>
        /// Media Site API Key
        /// </summary>
        public static string MsApiKey => GetKeyValue(ConfigurationHelper.MsApiKey);

        /// <summary>
        /// Media Site UserName
        /// </summary>
        public static string MsUserName => GetKeyValue(ConfigurationHelper.MsUserName);

        /// <summary>
        /// Media Site Password
        /// </summary>
        public static string MsPassword => GetKeyValue(ConfigurationHelper.MsPassword);

        #endregion;

        #region Public Methods

        /// <summary>
        /// Get value for the secret key
        /// </summary>
        /// <param name="secretKey"></param>
        /// <returns></returns>
        public static string GetKeyValue(string secretKey)
        {
            try
            {
                var keyVaultClient = new KeyVaultClient(GetAccessToken);

                var secret = keyVaultClient.GetSecretAsync(secretKey).GetAwaiter().GetResult();

                var storagePrimaryAccessKey = secret?.Value;

                return storagePrimaryAccessKey;
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets certificate
        /// </summary>
        public static class CertificateHelper
        {
            public static X509Certificate2 FindCertificateByThumbprint(string findValue)
            {
                var store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                try
                {
                    store.Open(OpenFlags.ReadOnly);
                    var col = store.Certificates.Find(X509FindType.FindByThumbprint,
                        findValue, false);
                    if (col.Count == 0)
                    {
                        throw new CryptographicException();
                    }
                    return col[0];
                }
                finally
                {
                    store.Close();
                }
            }
        }

        /// <summary>
        /// Gets JWT from Azure KeyVault
        /// </summary>
        /// <param name="authority"></param>
        /// <param name="resource"></param>
        /// <param name="scope"></param>
        /// <returns></returns>
        public static async Task<string> GetAccessToken(string authority, string resource, string scope)
        {  
            var clientAssertionCertPfx = CertificateHelper.FindCertificateByThumbprint(ConfigurationHelper.ThumbPrint);  
                     
            var assertionCert = new ClientAssertionCertificate(ConfigurationHelper.ClientId, clientAssertionCertPfx);
            var context = new AuthenticationContext(authority, TokenCache.DefaultShared);
            var result = await context.AcquireTokenAsync(resource, assertionCert);

            return result.AccessToken;
        }

        #endregion
    }
}

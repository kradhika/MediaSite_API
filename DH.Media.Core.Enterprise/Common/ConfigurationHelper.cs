using System;
using System.Configuration;

namespace DH.Media.Core.Enterprise.Common
{
    public interface IConfigurationProxy
    {

    }

    public class ConfigurationProxy : IConfigurationProxy
    {

    }

    /// <summary>
    /// Gets configuration related settings
    /// </summary>
    public static class ConfigurationHelper
    {
        #region Fields

        /// <summary>
        /// Gets Cors Origin
        /// </summary>
        public static string CorsOrigin => GetAppSetting<string>(Constants.CorsOrigin);

        /// <summary>
        /// Gets Cors Headers
        /// </summary>
        public static string CorsHeaders => GetAppSetting<string>(Constants.CorsHeaders);

        /// <summary>
        /// Gets Cors Methods
        /// </summary>
        public static string CorsMethods => GetAppSetting<string>(Constants.CorsMethods);

        /// <summary>
        /// Gets AppInsightsInstrumentationKey
        /// </summary>
        public static string AppInsightsInstrumentationKey => GetAppSetting<string>(Constants.AppInsightsInstrumentationKey);

        /// <summary>
        /// Gets AudienceKey
        /// </summary>
        public static string Audience => GetAppSetting<string>(Constants.Audience);

        /// <summary>
        /// Gets Consumer AudienceKey
        /// </summary>
        public static string ConsumerAudience => GetAppSetting<string>(Constants.ConsumerAudience);

        /// <summary>
        /// Gets IssuerKey
        /// </summary>
        public static string Issuer => GetAppSetting<string>(Constants.Issuer);

        /// <summary>
        /// Gets IssuerKey
        /// </summary>
        public static string ConsumerIssuer => GetAppSetting<string>(Constants.ConsumerIssuer);

        /// <summary>
        /// Gets IssuerMetadataEndpointKey
        /// </summary>
        public static string IssuerMetadataEndpoint => GetAppSetting<string>(Constants.IssuerMetadataEndpoint);

        /// <summary>
        /// Gets EnableTraceKey
        /// </summary>
        public static bool EnableTrace => GetAppSetting<bool>(Constants.EnableTrace);
        
        /// <summary>
        /// Gets MediaSite Playback Url
        /// </summary>
        public static string MediaSitePlaybackUrl => GetAppSetting<string>(Constants.MediaSitePlaybackUrl);

        /// <summary>
        /// Thumb print for azure key vault
        /// </summary>
        public static string ThumbPrint => GetAppSetting<string>(Constants.ThumbPrint);

        /// <summary>
        /// Client Id
        /// </summary>
        public static string ClientId => GetAppSetting<string>(Constants.ClientId);

        /// <summary>
        /// Gets Access Policy Name
        /// </summary>
        public static string AccessPolicyName => GetAppSetting<string>(Constants.AccessPolicyName);

        /// <summary>
        /// Gets MS_UserName
        /// </summary>
        public static string MsUserName => GetAppSetting<string>(Constants.MsUserName);

        /// <summary>
        /// Get MS_Password
        /// </summary>
        public static string MsPassword => GetAppSetting<string>(Constants.MsPassword);

        /// <summary>
        /// Gets MS_APIKey
        /// </summary>
        public static string MsApiKey => GetAppSetting<string>(Constants.MsApiKey);

        /// <summary>
        /// Gets MS_EndPointURI
        /// </summary>
        public static string MsEndPointUri => GetAppSetting<string>(Constants.MsEndPointUri);

        /// <summary>
        /// Gets AccountSid
        /// </summary>
        public static string AccountSid => GetAppSetting<string>(Constants.AccountSid);

        /// <summary>
        /// Gets AuthToken
        /// </summary>
        public static string AuthToken => GetAppSetting<string>(Constants.AuthToken);

        /// <summary>
        /// Configuration
        /// </summary>
        public static IConfigurationProxy Configuration { get; set; } = new ConfigurationProxy();

        #endregion

        #region Getting values from Web.Config file

        /// <summary>
        /// Generic version of GetAppSetting()
        /// </summary>
        /// <typeparam name="T">Type parameter</typeparam>
        /// <param name="key">The key</param>
        /// <returns></returns>
        public static T GetAppSetting<T>(string key)
        {
            var value = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ConfigurationErrorsException($"{key} " + Constants.AppSettingMissing);
            }

            var theType = typeof(T);
            if (theType.IsEnum)
            {
                return (T)Enum.Parse(theType, value, true);
            }
            return (T)Convert.ChangeType(value, theType);
        }


        #endregion
    }
}




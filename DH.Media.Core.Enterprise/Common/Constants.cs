namespace DH.Media.Core.Enterprise.Common
{
    /// <summary>
    /// Constants Class
    /// </summary>
    public class Constants
    {
        #region Constants Fields

        /// <summary>
        /// Cors-Origin
        /// </summary>
        public const string CorsOrigin = "CorsOrigin";

        /// <summary>
        /// Cors-Headers
        /// </summary>
        public const string CorsHeaders = "CorsHeaders";

        /// <summary>
        /// Cors-Methods
        /// </summary>
        public const string CorsMethods = "CorsMethods";

        /// <summary>
        /// App Setting
        /// </summary>
        public const string AppSettingMissing = "app setting is missing";

        // <summary>
        /// <summary>
            /// Order by created on date
        /// </summary>
        public const string CreatedOnOrder = "CreatedOn ";
        
        /// <summary>
        /// Presentation Id
        /// </summary>
        public const string QueryParamPresentationId = "presentationId";

        /// <summary>
        /// Minutes To Live
        /// </summary>
        public const string QueryParamMinutesToLive = "minutesToLive";

        /// <summary>
        /// Autofac Json File Name
        /// </summary>
        public const string AutofacJsonFileName = "autofac.json";

        /// <summary>
        /// AppInsightsInstrumentationKey
        /// </summary>
        public const string AppInsightsInstrumentationKey = "AppInsightsInstrumentationKey";

        /// <summary>
        /// Audience
        /// </summary>
        public const string Audience = "Audience";

        /// <summary>
        /// ConsumerAudience
        /// </summary>
        public const string ConsumerAudience = "ConsumerAudience";

        /// <summary>
        ///Issuer
        /// </summary>
        public const string Issuer = "Issuer";

        /// <summary>
        ///ConsumerIssuer
        /// </summary>
        public const string ConsumerIssuer = "ConsumerIssuer";

        /// <summary>
        /// EnableTrace
        /// </summary>
        public const string EnableTrace = "EnableTrace";

        /// <summary>
        /// Media Site Playback Url
        /// </summary>
        public const string MediaSitePlaybackUrl = "MediaSitePlaybackUrl";

        /// <summary>
        /// Issuer Metadata Endpoint
        /// </summary>
        public const string IssuerMetadataEndpoint = "IssuerMetadataEndpoint";

        /// <summary>
        /// Audience Token Validation Parameter
        /// </summary>
        public const string AudienceTokenValidationParameter = "aud";

        /// <summary>
        /// Issuer Token Validation Parameter
        /// </summary>
        public const string IssuerTokenValidationParameter = "iss";

        /// <summary>
        /// Presentation Url
        /// </summary>
        public const string PresentationUrl = "Presentations?search=ParentFolderId:52dc2798ff184bcea08c8aee6943a55714";

        /// <summary>
        /// AuthorizationTickets
        /// </summary>
        public const string AuthorizationTickets = "AuthorizationTickets";

        /// <summary>
        /// PresentationsPart
        /// </summary>
        public const string PresentationsPart = "Presentations('";

        /// <summary>
        /// SelectPart
        /// </summary>
        public const string SelectPart = "')?$select=full";

        /// <summary>
        /// One Space
        /// </summary>
        public const string OneSpace = " ";

        /// <summary>
        /// Select
        /// </summary>
        public const string Select = "$select";

        /// <summary>
        /// Orderby
        /// </summary>
        public const string Orderby = "$orderby";

        /// <summary>
        /// RecordDate Order
        /// </summary>
        public const string RecordDateOrder = " RecordDate ";

        /// <summary>
        /// Skip
        /// </summary>
        public const string Skip = "$skip";

        /// <summary>
        /// Top
        /// </summary>
        public const string Top = "$top";

        /// <summary>
        /// Full
        /// </summary>
        public const string Full = "full";

        /// <summary>
        /// ThumbPrint
        /// </summary>
        public const string ThumbPrint = "ThumbPrint";

        /// <summary>
        /// ClientId
        /// </summary>
        public const string ClientId = "ClientId";

        /// <summary>
        /// MS_UserName
        /// </summary>
        public const string MsUserName = "MS_UserName";

        /// <summary>
        /// MS_Password
        /// </summary>
        public const string MsPassword = "MS_Password";

        /// <summary>
        /// MS_APIKey
        /// </summary>
        public const string MsApiKey = "MS_APIKey";

        /// <summary>
        /// MS_EndPointURI
        /// </summary>
        public const string MsEndPointUri = "MS_EndPointURI";

        /// <summary>
        /// AccessPolicyName
        /// </summary>
        public const string AccessPolicyName = "AccessPolicyName";

        /// <summary>
        /// AccountSid
        /// </summary>
        public const string AccountSid = "AccountSid";

        /// <summary>
        /// Sfapikey
        /// </summary>
        public const string Sfapikey = "sfapikey";

        /// <summary>
        /// BaseUri
        /// </summary>
        public const string BaseUri = "api/v1";

        /// <summary>
        /// Header Authorization
        /// </summary>
        public const string HeaderAuthorization = "Authorization";

        /// <summary>
        /// AuthToken
        /// </summary>
        public const string AuthToken = "AuthToken";

        /// <summary>
        /// Basic {0}
        /// </summary>
        public const string BasicHolder = "Basic {0}";

        /// <summary>
        /// {0}:{1}
        /// </summary>
        public const string PlaceHolder = "{0}:{1}";

        /// <summary>
        /// Authorization 
        /// </summary>
        public const string Authorization = "Authorization";

        /// <summary>
        /// Auth Header
        /// </summary>
        public const string AuthHeader = "header";

        /// <summary>
        /// Auth Type
        /// </summary>
        public const string AuthType = "string";

        /// <summary>
        /// Auth Description
        /// </summary>
        public const string AuthDescription = "Authorization Access Token. Bearer {access_token}.";

        /// <summary>
        /// X-Unauthorized-Status
        /// </summary>
        public const string UnauthorizedHeader = "X-Unauthorized-Status";

        /// <summary>
        /// Display message "Invalid access token"
        /// </summary>
        public const string InvalidAccessTokenMessage = "Invalid access token";

        /// <summary>
        /// MVP version
        /// </summary>
        public const string V1Version = "1.0";

        #endregion

        #region Constant Fields for Response codes

        /// <summary>
        /// Success
        /// </summary>
        public const string SuccessMessage = "Success";

        /// <summary>
        /// Display message "Request Process Successfully"
        /// </summary>
        public const string RequestProcessSuccessMessage = "The request was processed successfully";

        /// <summary>
        /// Display message "Invalid Or missing parameters"
        /// </summary>
        public const string InvalidParametersMessage = "Invalid Or missing parameters :";

        /// <summary>
        /// Display message "Unauthorized access"
        /// </summary>
        public const string UnauthorizedAccessMessage = "Unauthorized access";

        /// <summary>
        /// Display message "Resource not found with the given details"
        /// </summary>
        public const string ResourceNotFoundMessage = "Resource not found with the given details";

        /// <summary>
        /// Display message "Invalid state token"
        /// </summary>
        public const string InvalidStateTokenMessage = "Invalid state token";

        /// <summary>
        /// Sort fields are not valid
        /// </summary>
        public const string InvalidOrderByField = "Order By field is not valid";

        /// <summary>
        /// Display message "Presentation video not found"
        /// </summary>
        public const string PresentationVideoNotFoundMessage = "Presentation video not found";

        /// <summary>
        /// Access token expired
        /// </summary>
        public const string AccessTokenExpiredMessage = "Access token expired";

        /// <summary>
        /// NoAccessToken
        /// </summary>
        public const string NoAccessTokenMessage = "Access token not found with request headers";

        /// <summary>
        /// Insufficient user privileges
        /// </summary>
        public const string InsufficientUserPrivilegesMessage = "Insufficient user privileges";

        /// <summary>
        /// Unauthorized access token
        /// </summary>
        public const string UnauthorizedAccessTokenMessage = "Unauthorized access token";

        /// <summary>
        /// Given invalid Id(s)
        /// </summary>
        public const string InvalidRequestIdMessage = "Given Invalid Id(s)";

        /// <summary>
        /// Display message "An unexpected error occurred. Please contact administrator"
        /// </summary>
        public const string InternalServerErrorMessage = "An unexpected error occurred. Please contact administrator";

        #endregion
    }
}

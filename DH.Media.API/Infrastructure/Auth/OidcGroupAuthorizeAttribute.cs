using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Controllers;
using DH.Media.Core.Enterprise.Common;

namespace DH.Media.API.Infrastructure.Auth
{
    /// <summary>
    /// Authorize Attribute that verifies user groups before action gets executed
    /// </summary>
    public class OidcGroupAuthorizeAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// Verifies request is authorized
        /// </summary>
        /// <param name="actionContext">HttpActionContext Object</param>
        /// <returns></returns>
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            if (!base.IsAuthorized(actionContext))
            {
                return false;
            }                

            return Thread.CurrentPrincipal != null;
        }

        /// <summary>
        /// Handles request with unauthorized context
        /// </summary>
        /// <param name="actionContext"></param>
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            base.HandleUnauthorizedRequest(actionContext);

            if (string.IsNullOrEmpty(actionContext.Request.Headers.Authorization?.Parameter))
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized,
                    ServiceResponse.Instance.BuildResponse(ResponseCodes.NoAccessToken));
                return;
            }

            var owinContext = actionContext.Request.GetOwinContext();
            if (owinContext.Response.Headers.ContainsKey(Constants.UnauthorizedHeader))
            {
                actionContext.Response = actionContext.Request.CreateResponse(
                    HttpStatusCode.Unauthorized
                    , ServiceResponse.Instance.BuildResponse(ResponseCodes.InvalidAccesstoken));
                if (owinContext.Response.Headers[Constants.UnauthorizedHeader] == ((int)ResponseCodes.AccessTokenExpired).ToString())
                {
                    actionContext.Response = actionContext.Request.CreateResponse(
                        HttpStatusCode.Unauthorized
                        , ServiceResponse.Instance.BuildResponse(ResponseCodes.AccessTokenExpired));
                    return;
                }
                if (owinContext.Response.Headers[Constants.UnauthorizedHeader] == ((int)ResponseCodes.UnauthorizedAccessToken).ToString())
                {
                    actionContext.Response = actionContext.Request.CreateResponse(
                        HttpStatusCode.Unauthorized
                        , ServiceResponse.Instance.BuildResponse(ResponseCodes.UnauthorizedAccessToken));
                }
                return;
            }

            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized,
                owinContext.Authentication.User != null
                    ? ServiceResponse.Instance.BuildResponse(ResponseCodes.InsufficientPrivileges)
                    : ServiceResponse.Instance.BuildResponse(ResponseCodes.UnauthorizedAccessToken));
        }
    }
}
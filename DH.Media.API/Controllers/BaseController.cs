using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DH.Media.API.Infrastructure.Auth;
using DH.Media.Core.Enterprise.Common;
using DH.Media.Core.Enterprise.Enums;

namespace DH.Media.API.Controllers
{
    /// <summary>
    /// Base class for all the controllers
    /// </summary>
    [OidcGroupAuthorize]
    public class BaseController : ApiController
    {
        /// <summary>
        /// Returns success response
        /// </summary>
        /// <param name="resultValue">Result</param>
        /// <returns>HttpResponseMessage object</returns>
        protected HttpResponseMessage BuildResponse<T>(T resultValue)
        {
            var propValue = resultValue.GetType().GetProperty("Code")?.GetValue(resultValue);
            var responseCode = (ResponseCodes)Enum.Parse(typeof(ResponseCodes), propValue?.ToString());
            var httpStatusCode = EnumManager.Instance.GetAttributeValue<ResponseCodes, HttpStatusAttribute, HttpStatusCode>(responseCode);
            return Request.CreateResponse(httpStatusCode, resultValue);
        }
    }
}
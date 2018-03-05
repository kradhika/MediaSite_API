using System.Net.Http;
using System.Net;
using System.Web.Http.Filters;
using DH.Media.Core.Enterprise.Common;

namespace DH.Media.API.Infrastructure.Filters
{
    /// <summary>
    ///  Handles all exceptions
    /// </summary>
    public class HandleApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// Process all Exceptions in current context
        /// </summary>
        /// <param name="actionExecutedContext">HttpActionExecutedContext Object</param>
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is System.Linq.Dynamic.ParseException)
            {
                actionExecutedContext.Response = actionExecutedContext.ActionContext.Request.CreateResponse(HttpStatusCode.BadRequest
                    , ServiceResponse.Instance.BuildResponse(ResponseCodes.InvalidSortOrderByField));
            }
            else
            {
                actionExecutedContext.Response = actionExecutedContext.ActionContext.Request.CreateResponse(HttpStatusCode.InternalServerError
                   , ServiceResponse.Instance.BuildResponse(ResponseCodes.InternalServerError));
            }

            base.OnException(actionExecutedContext);
        }
    }
}
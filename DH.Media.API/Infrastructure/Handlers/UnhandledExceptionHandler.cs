using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;
using DH.Media.Core.Enterprise.Common;

namespace DH.Media.API.Infrastructure.Handlers
{
    /// <summary>
    /// Handles all unhandled exceptions
    /// </summary>
    public class UnhandledExceptionHandler : IExceptionHandler
    {
        /// <summary>
        /// Handles Async
        /// </summary>
        /// <param name="context">ExceptionHandlerContext Object</param>
        /// <param name="cancellationToken">CancellationToken Object</param>
        /// <returns></returns>
        public Task HandleAsync(ExceptionHandlerContext context
                              , CancellationToken cancellationToken)
        {
            context.Result = new ResponseMessageResult(context.Request.CreateResponse(HttpStatusCode.InternalServerError
               , ServiceResponse.Instance.BuildResponse(ResponseCodes.InternalServerError)));
            return Task.FromResult(0);
        }
    }
}
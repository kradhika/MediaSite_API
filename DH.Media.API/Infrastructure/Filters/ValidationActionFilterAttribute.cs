using System.Text;
using System.Net;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net.Http;
using DH.Media.Core.Enterprise.Common;

namespace DH.Media.API.Infrastructure.Filters
{
    /// <summary>
    /// Handles all request validation
    /// </summary>
    public class ValidationActionFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Process all request validation in current context
        /// </summary>
        /// <param name="actionContext">HttpActionContext object</param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var modelState = actionContext.ModelState;
            if (modelState.IsValid)
            {
                return;
            }                

            var errorParameters = new StringBuilder();
            foreach (var item in modelState.Keys)
            {
                var itemVal = modelState[item];
                if (itemVal.Errors.Count <= 0)
                {
                    continue;
                }                    
                if (string.IsNullOrEmpty(itemVal.Errors[0].ErrorMessage) && itemVal.Errors[0].Exception == null)
                {
                    continue;
                }

                if (itemVal.Errors[0].Exception != null)
                {
                    errorParameters.Append(itemVal.Errors[0].Exception.Message.Substring(itemVal.Errors[0].Exception.Message.IndexOf('\'') + 1, itemVal.Errors[0].Exception.Message.Length-68));
                }
                else
                {
                    errorParameters.Append(item.Substring(item.IndexOf('.') + 1));
                }
                errorParameters.Append(',');
            }
            var errors = errorParameters.ToString().Substring(0, errorParameters.Length - 1);
            var serviceResponse = ServiceResponse.Instance.BuildResponse(ResponseCodes.InvalidMissingInputs);
            serviceResponse.Message = string.Concat(serviceResponse.Message, Constants.OneSpace, errors);
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest, serviceResponse);
        }
    }
}
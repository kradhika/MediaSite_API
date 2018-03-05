using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using Swashbuckle.Swagger;
using DH.Media.Core.Enterprise.Common;

namespace DH.Media.API.Infrastructure.Handlers
{
    /// <summary>
    /// Required Header Parameter
    /// </summary>
    public class RequiredHeaderParameter : IOperationFilter
    {
        /// <summary>
        /// Applying Header parameters to Swagger UI
        /// </summary>
        /// <param name="operation">Operation Object</param>
        /// <param name="schemaRegistry">SchemaRegistry Object</param>
        /// <param name="apiDescription">ApiDescription Object</param>
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (apiDescription.GetControllerAndActionAttributes<AuthorizeAttribute>().Any() &&
                !apiDescription.GetControllerAndActionAttributes<AllowAnonymousAttribute>().Any())
            {
                operation.parameters.Add(new Parameter
                {
                    name = Constants.Authorization,
                    @in = Constants.AuthHeader,
                    type = Constants.AuthType,
                    description = Constants.AuthDescription,
                    required = true
                });
            }
        }
    }
}
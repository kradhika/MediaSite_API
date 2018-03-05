using System;
using System.IO;
using System.Web.Http;
using System.Web.Http.Description;
using Swashbuckle.Application;
using DH.Media.API.Infrastructure.Handlers;

namespace DH.Media.API
{
    /// <summary>
    /// Swagger Configuration
    /// </summary>
    public static class SwaggerConfig
    {
        /// <summary>
        /// Register Method
        /// </summary>
        public static void Register(HttpConfiguration configuration)
        {
            // Swagger API Multiple Versions
            configuration.AddApiVersioning(apiVersionInfo => apiVersionInfo.AssumeDefaultVersionWhenUnspecified = true);
            var apiExplorer = configuration.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
            });

            configuration
                .EnableSwagger("swagger/docs/{apiVersion}", swagger =>
                {
                    {
                        swagger.MultipleApiVersions(
                            (apiDescription, version) => apiDescription.GetGroupName() == version,
                            info =>
                            {
                                foreach (var group in apiExplorer.ApiDescriptions)
                                {
                                    info.Version(group.Name, $"DH.Media.API v{group.ApiVersion}");
                                }
                            });
                    }
                    swagger.OperationFilter<RequiredHeaderParameter>();
                    swagger.IncludeXmlComments(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data\\MediaApiDoc.xml"));
                    swagger.DescribeAllEnumsAsStrings();
                    swagger.SchemaId(x => x.FullName);
                })
                .EnableSwaggerUi(swaggerUi =>
                {
                    swaggerUi.EnableDiscoveryUrlSelector();
                });
        }
    }
}
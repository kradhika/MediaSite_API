using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.Configuration;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http;
using System.Reflection;
using System.Collections.Generic;
using System.Web.Http.ExceptionHandling;
using Autofac;
using Autofac.Integration.WebApi;
using Autofac.Configuration;
using Owin;
using DH.Media.API.Infrastructure.Auth;
using DH.Media.API.Infrastructure.Handlers;
using DH.Media.Core.Enterprise.Common;

[assembly: OwinStartup(typeof(DH.Media.API.Startup))]
namespace DH.Media.API
{
    /// <summary>
    /// Startup Class
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configuration
        /// </summary>
        /// <param name="app">AppBuilder Interface</param>
        public void Configuration(IAppBuilder app)
        {
            var httpConfig = new HttpConfiguration();
            httpConfig.Services.Add(typeof(IExceptionLogger), new MediaExceptionLogger());

            if (ConfigurationHelper.EnableTrace)
            {
                httpConfig.EnableSystemDiagnosticsTracing();
            }

            ConfigureAuth(app);
            httpConfig.Services.Replace(typeof(IExceptionHandler), new UnhandledExceptionHandler());

            DiConfiguration(httpConfig);
            WebApiConfig.Register(httpConfig);
            SwaggerConfig.Register(httpConfig);

            TelemetryConfiguration.Active.InstrumentationKey = ConfigurationHelper.AppInsightsInstrumentationKey;

            app.UseWebApi(httpConfig);
        }

        /// <summary>
        /// Configure Auth to trust the access token
        /// </summary>
        /// <param name="app"></param>
        private static void ConfigureAuth(IAppBuilder app)
        {
            string[] audiences = { ConfigurationHelper.Audience, ConfigurationHelper.ConsumerAudience };
            string[] issuer = { ConfigurationHelper.Issuer, ConfigurationHelper.ConsumerIssuer };

            var additionalTokenValidationParameters = new List<IReadOnlyDictionary<string, string>> {
                // Validate Client ID claim
                new Dictionary<string, string>
                {
                    [Constants.AudienceTokenValidationParameter] = audiences[0],
                    [Constants.IssuerTokenValidationParameter] = issuer[0]
                },
                new Dictionary<string, string>
                {
                    [Constants.AudienceTokenValidationParameter] = audiences[1],
                    [Constants.IssuerTokenValidationParameter] = issuer[1]
                }
            };

            var securityTokenProvider = new OpenIdConnectCachingSecurityTokenProvider($"{issuer[0]}{ConfigurationHelper.IssuerMetadataEndpoint}");

            var consumerSecurityTokenProvider = new OpenIdConnectCachingSecurityTokenProvider($"{issuer[1]}{ConfigurationHelper.IssuerMetadataEndpoint}");

            IEnumerable<OpenIdConnectCachingSecurityTokenProvider> tokenProviders =
                new List<OpenIdConnectCachingSecurityTokenProvider>
                {
                    securityTokenProvider,
                    consumerSecurityTokenProvider
                };

            var jwtFormat = new AuthJwtFormat(audiences, additionalTokenValidationParameters, tokenProviders);

            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions
            {
                AccessTokenFormat = jwtFormat,
                AuthenticationMode = AuthenticationMode.Active
            });
        }

        /// <summary>
        /// DI Configuration
        /// </summary>
        /// <param name="config">HttpConfiguration Object</param>
        private static void DiConfiguration(HttpConfiguration config)
        {
            //Load Autofac json
            var configBuilder = new ConfigurationBuilder();
            configBuilder.AddJsonFile(Constants.AutofacJsonFileName);

            var containerBuilder = new ContainerBuilder();

            // Register autofac configuration to container
            var module = new ConfigurationModule(configBuilder.Build());
            containerBuilder.RegisterModule(module);

            // Register your Web API controllers.
            containerBuilder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var container = containerBuilder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}

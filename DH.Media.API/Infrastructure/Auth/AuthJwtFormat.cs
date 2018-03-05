using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using DH.Media.Core.Enterprise.Common;

namespace DH.Media.API.Infrastructure.Auth
{
    /// <summary>
    /// Media Custom Jwt Token Validation Format Implementor
    /// </summary>
    public class AuthJwtFormat : JwtFormat, ISecureDataFormat<AuthenticationTicket>
    {
        private readonly List<IReadOnlyDictionary<string, string>> _additionalTokenValidationParamters;

        /// <summary>
        /// Validation Token Format
        /// </summary>
        /// <param name="audiences">TokenValidationParameters Object</param>
        /// <param name="additionalTokenValidationParamters">ReadOnlyDictionary Interface</param>
        /// <param name="securityTokenProvider">OpenIdConnectCachingSecurityTokenProvider Object</param>
        public AuthJwtFormat(IEnumerable<string> audiences
                           , List<IReadOnlyDictionary<string, string>> additionalTokenValidationParamters
                           , IEnumerable<OpenIdConnectCachingSecurityTokenProvider> securityTokenProvider)
            : base(audiences, securityTokenProvider)
        {
            if (_additionalTokenValidationParamters == null)
            {
                _additionalTokenValidationParamters = new List<IReadOnlyDictionary<string, string>>();
            }

            _additionalTokenValidationParamters = additionalTokenValidationParamters;
        }

        /// <summary>
        /// Validate the JWT Token and generate the Auth ticket
        /// </summary>
        /// <param name="protectedText">Protected Text</param>
        /// <returns></returns>
        public new AuthenticationTicket Unprotect(string protectedText)
        {
            try
            {
                var result = base.Unprotect(protectedText);

                ThrowIfValidationFails(result, _additionalTokenValidationParamters);

                return result;
            }
            catch (SecurityTokenExpiredException)
            {
                HttpContext.Current.GetOwinContext().Response.Headers[Constants.UnauthorizedHeader] = ((int)ResponseCodes.AccessTokenExpired).ToString();
            }
            catch (UnauthorizedAccessException)
            {
                HttpContext.Current.GetOwinContext().Response.Headers[Constants.UnauthorizedHeader] = ((int)ResponseCodes.UnauthorizedAccessToken).ToString();
            }
            return null;
        }

        #region Private Methods

        /// <summary>
        /// Throws parameters mismatch exception
        /// </summary>
        /// <param name="ticket">AuthenticationTicket Object</param>
        /// <param name="customParameters">ReadOnlyDictionary Interface</param>
        private static void ThrowIfValidationFails(AuthenticationTicket ticket
                                                 , IEnumerable<IReadOnlyDictionary<string, string>> customParameters)
        {
            var i = 0;
            foreach (var claimPair in customParameters)
            {
                i++;
                var isMatched = false;
                foreach (var pair in claimPair)
                {
                    var claimInTicket = ticket.Identity.Claims.SingleOrDefault(c => c.Type == pair.Key);
                    if (claimInTicket?.Value != pair.Value)
                    {
                        isMatched = false;
                        if (customParameters.Count() == i)
                        {
                            throw new UnauthorizedAccessException();
                        }
                    }
                    else
                    {
                        isMatched = true;
                    }
                }
                if (isMatched)
                {
                    break;
                }
            }
        }

        #endregion
    }
}
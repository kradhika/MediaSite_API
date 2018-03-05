using System;
using System.Net;

namespace DH.Media.Core.Enterprise.Enums
{
    /// <summary>
    /// Custom attribute to declare HttpStatus.
    /// </summary>
    public sealed class HttpStatusAttribute : Attribute, IEnumAttribute<HttpStatusCode>
    {
        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="value">HttpStatusCode value</param>
        public HttpStatusAttribute(HttpStatusCode value) { Value = value; }

        /// <summary>
        /// Gets HttpStatusCode value.
        /// </summary>
        public HttpStatusCode Value { get; }
    }
}

using System;using System.Web.Mvc;using Microsoft.ApplicationInsights;namespace DH.Media.API{
    /// <summary>
    /// AiHandleErrorAttribute Class
    /// </summary>    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]     public class AiHandleErrorAttribute : HandleErrorAttribute    {        /// <summary>
        /// Provides Exception on AiHandle
        /// </summary>
        /// <param name="filterContext"></param>        public override void OnException(ExceptionContext filterContext)        {            if (filterContext?.HttpContext != null && filterContext.Exception != null &&                filterContext.HttpContext.IsCustomErrorEnabled)            {                var ai = new TelemetryClient();                ai.TrackException(filterContext.Exception);            }            base.OnException(filterContext);        }    }}
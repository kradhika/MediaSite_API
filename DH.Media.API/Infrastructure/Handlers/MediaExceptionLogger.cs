using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;
using NLog;

namespace DH.Media.API.Infrastructure.Handlers
{
    /// <summary>
    /// Media Exception Logger Class
    /// </summary>
    public class MediaExceptionLogger : IExceptionLogger
    {
        /// <summary>
        /// Logs Async
        /// </summary>
        /// <param name="context">ExceptionHandlerContext Object</param>
        /// <param name="cancellationToken">CancellationToken Object</param>
        /// <returns></returns>
        public Task LogAsync(ExceptionLoggerContext context, CancellationToken cancellationToken)
        {
             LogManager.GetCurrentClassLogger().Error(context.Exception, context.Exception.Message);
            return Task.FromResult(0);
        }
    }
}
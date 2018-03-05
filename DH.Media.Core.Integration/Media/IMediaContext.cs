using System.Collections.Generic;
using DH.Media.Core.Integration.Media.ViewModels;
using DH.Media.Core.Enterprise.Common;

namespace DH.Media.Core.Integration.Media
{
    /// <summary>
    /// BNI Media context interface
    /// </summary>
    public interface IMediaContext
    {
        #region Interface Methods
        /// <summary>
        /// Gets filtered Presentations 
        /// </summary>
        /// <param name="searchPresentation"></param>
        /// <param name="skip"></param>
        /// <param name="top"></param>
        /// <param name="sortDirection"></param>
        /// <returns></returns>
        List<Presentation> GetPresentations(string searchPresentation, int skip, int top, SortOrderType sortDirection);

        /// <summary>
        /// Gets Authentication Ticket
        /// </summary>
        /// <param name="presentationId"></param>
        /// <param name="minutesToLive"></param>
        /// <returns></returns>
        string RequestAuthTicket(string presentationId, int minutesToLive);

        /// <summary>
        /// Gets Single Presentation Information
        /// </summary>
        /// <param name="presentationId"></param>
        /// <returns></returns>
        Presentation GetPresentation(string presentationId);
        #endregion
    }
}

using System.Collections.Generic;
using DH.Media.Core.Integration.Media.ViewModels;
using DH.Media.Core.Enterprise.Common;

namespace DH.Media.Core.Application.V1.Media.ViewModels
{
    /// <summary>
    /// BNI media model
    /// </summary>
    public class MediaResponse : SearchModel
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public MediaResponse()
        {
            VideoPresentation = new List<Presentation>();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Video Presentations Information
        /// </summary>
        public IList<Presentation> VideoPresentation { get; set; }

        #endregion
    }
}

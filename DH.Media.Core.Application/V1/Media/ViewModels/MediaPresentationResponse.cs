using DH.Media.Core.Integration.Media.ViewModels;

namespace DH.Media.Core.Application.V1.Media.ViewModels
{
    /// <summary>
    /// BNI Media Model
    /// </summary>
    public class MediaPresentationResponse
    {
        #region Constructor

        /// <summary>
        /// BNI Media Constructor
        /// </summary>
        public MediaPresentationResponse()
        {
            VideoPresentation = new Presentation();
        }

        #endregion

        /// <summary>
        /// Video Presentation
        /// </summary>
        public Presentation VideoPresentation { get; set; }
    }
}

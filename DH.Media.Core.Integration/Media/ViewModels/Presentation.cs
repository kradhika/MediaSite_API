using System;
using DH.Media.Core.Enterprise.Common;

namespace DH.Media.Core.Integration.Media.ViewModels
{
    /// <summary>
    /// Presentation related properties
    /// </summary>
    public class Presentation
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Primary Presenter
        /// </summary>
        public string PrimaryPresenter { get; set; }

        /// <summary>
        /// Owner
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Thumbnail Url
        /// </summary>
        public string ThumbnailUrl { get; set; }

        /// <summary>
        /// Duration
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// Record Date
        /// </summary>
        public DateTime? RecordDate { get; set; }

        /// <summary>
        /// Authorization Ticket
        /// </summary>
        public string AuthorizationTicket { get; set; }

        /// <summary>
        /// Playback Url
        /// </summary>
        public string PlaybackUrl => string.Concat(ConfigurationHelper.MediaSitePlaybackUrl, Id);
    }
}

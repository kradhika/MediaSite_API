using System;

namespace DH.Media.Core.Integration.Media.ViewModels
{
    /// <summary>
    ///Response for Authentication 
    /// </summary>
    public class AuthResponse
    {
        /// <summary>
        /// Ticket Id
        /// </summary>
        public string TicketId { get; set; }
        
        /// <summary>
        /// User name
        /// </summary>
        public string Username { get; set; }
        
        /// <summary>
        /// Client Ip Address
        /// </summary>
        public string ClientIpAddress { get; set; }

        /// <summary>
        /// Owner
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Resource Id
        /// </summary>
        public string ResourceId { get; set; }

        /// <summary>
        /// Minutes to Live
        /// </summary>
        public int MinutesToLive { get; set; }

        /// <summary>
        /// Creation time
        /// </summary>
        public DateTime? CreationTime { get; set; }

        /// <summary>
        /// Expiration time
        /// </summary>
        public DateTime? ExpirationTime { get; set; }

    }
}

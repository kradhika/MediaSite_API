namespace DH.Media.Core.Enterprise.Common
{
    /// <summary>
    /// Search Model
    /// </summary>
    public class SearchModel
    {
        #region Properties
        /// <summary>
        /// Page Number
        /// </summary>      
        public int Offset { get; set; }

        /// <summary>
        /// Page Size
        /// </summary>      
        public int Limit { get; set; }

        /// <summary>
        /// Total Records Count
        /// </summary>      
        public int Total { get; set; }

        #endregion
    }
}

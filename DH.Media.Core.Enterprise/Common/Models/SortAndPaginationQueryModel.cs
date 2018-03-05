using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DH.Media.Core.Enterprise.Common.Models
{
    /// <summary>
    /// Pagination Query Model
    /// </summary> 
    public class SortAndPaginationQueryModel
    {
        /// <summary>
        /// SortAndPaginationQueryModel Constructor
        /// </summary>
        public SortAndPaginationQueryModel()
        {
            Offset = 0;
            Limit = 10;
        }

        #region Properties
        /// <summary>
        /// Accepts 'ASC' or 'DESC'. If not sent, defaults to 'DESC'
        /// </summary>
        [EnumDataType(typeof(SortOrderType))]
        public SortOrderType SortDirection { get; set; }

        /// <summary>
        /// Number of records to skip. If not sent, defaults to 0.
        /// </summary>
        [Range(0, int.MaxValue)]
        [DefaultValue(0)]
        public int Offset { get; set; }

        /// <summary>
        /// Number of records to return. If not sent, defaults to 10.
        /// </summary>
        [Range(0, int.MaxValue)]
        [DefaultValue(10)]
        public int Limit { get; set; }

        /// <summary>
        /// Order by field on fetched result. If not sent, defaults to CreatedOn.
        /// </summary>
        public string OrderByField { get; set; } = Constants.CreatedOnOrder;

        #endregion
    }
}

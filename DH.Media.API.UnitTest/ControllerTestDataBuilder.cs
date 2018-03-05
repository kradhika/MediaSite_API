using DH.Media.Core.Enterprise.Common;
using DH.Media.Core.Enterprise.Common.Models;

namespace DH.Media.API.UnitTest
{
    /// <summary>
    /// Controller Test Data Builder
    /// </summary>
    public static class ControllerTestDataBuilder
    {
        public const string TenantId = "80C641E8-E12F-406A-BB31-9557CE7D9F66";
        public static readonly SortAndPaginationQueryModel SortAndPaginationQueryModel = new SortAndPaginationQueryModel
        {
            Limit = 10,
            Offset = 0,
            SortDirection = SortOrderType.Asc
        };

        #region MediaController Test Data

        public const string SearchCriteria = "SomeCriteria";
        public const string PresentationId = "SomeId";
        public const string ReqUrl = "http://www.sampleurl.com/";
        public static string Query { get; set; } = "SomeQuery";
        public static readonly string TicketTestData = "TicketData";

        #endregion
    }
}

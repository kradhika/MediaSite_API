using System;
using System.Web;
using DH.Media.Core.Application.V1.Media.ViewModels;
using DH.Media.Core.Enterprise.Common;
using DH.Media.Core.Enterprise.Common.Models;
using DH.Media.Core.Integration.Media;

namespace DH.Media.Core.Application.V1.Media
{
    /// <summary>
    /// MediaApplication Class
    /// </summary>
    public class MediaApplication : IMediaApplication
    {
        #region Variables
        private readonly IMediaContext _mediaContext;
        #endregion

        #region Constructor

        /// <summary>
        /// MediaApplication Constructor
        /// </summary>
        /// <param name="mediaContext">MediaContext Interface</param>
        public MediaApplication(IMediaContext mediaContext)
        {
            _mediaContext = mediaContext;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Get list of media videos
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="searchCriteria"></param>
        /// <param name="sortAndPaginationQueryModel"></param>
        /// <returns></returns>
        public MediaResponse<ViewModels.MediaResponse> GetMediaVideos(string tenantId, string searchCriteria, SortAndPaginationQueryModel sortAndPaginationQueryModel)
        {
            var videoList = _mediaContext.GetPresentations(searchCriteria, sortAndPaginationQueryModel.Offset,
                                                           sortAndPaginationQueryModel.Limit, sortAndPaginationQueryModel.SortDirection);
            var mediaResponse = new ViewModels.MediaResponse
            {
                Offset = sortAndPaginationQueryModel.Offset,
                Limit = sortAndPaginationQueryModel.Limit
            };
            if (videoList == null)
            {
                return ServiceResponse.Instance.BuildResponse(ResponseCodes.Ok, mediaResponse);
            }
            mediaResponse.VideoPresentation = videoList;
            return ServiceResponse.Instance.BuildResponse(ResponseCodes.Ok, mediaResponse);
        }

        /// <summary>
        /// Get Authorization Ticket
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public MediaResponse<string> GetAuthorizationTicket(string query)
        {
            var queryStringParams = HttpUtility.ParseQueryString(query);
            var presentationId = string.Empty;
            var minutesToLive = 0;
            if (queryStringParams.Count <= 0)
            {
                return ServiceResponse.Instance.BuildResponse(ResponseCodes.Ok, _mediaContext.RequestAuthTicket(presentationId, minutesToLive));
            }
            if (!string.IsNullOrEmpty(queryStringParams[Constants.QueryParamPresentationId]))
            {
                presentationId = queryStringParams[Constants.QueryParamPresentationId];
            }
            if (!string.IsNullOrEmpty(queryStringParams[Constants.QueryParamMinutesToLive]))
            {
                minutesToLive = Convert.ToInt32(queryStringParams[Constants.QueryParamMinutesToLive]);
            }

            return ServiceResponse.Instance.BuildResponse(ResponseCodes.Ok, _mediaContext.RequestAuthTicket(presentationId, minutesToLive));
        }

        /// <summary>
        /// Get Presentation
        /// </summary>
        /// <param name="presentationId">Presentation Id</param>
        /// <returns>PresentationModel Object</returns>
        public MediaResponse<MediaPresentationResponse> GetPresentation(string presentationId)
        {
            var videoPresentation = _mediaContext.GetPresentation(presentationId);
            if (videoPresentation == null)
            {
                return ServiceResponse.Instance.BuildErrorResponse<MediaPresentationResponse>(ResponseCodes.PresentationVideoNotfound);
            }

            return ServiceResponse.Instance.BuildResponse(ResponseCodes.Ok, new MediaPresentationResponse
            {
                VideoPresentation = videoPresentation
            });
        }

        #endregion
    }
}

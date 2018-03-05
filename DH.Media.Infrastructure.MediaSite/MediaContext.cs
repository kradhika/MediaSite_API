using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using DH.Media.Core.Integration.Media;
using DH.Media.Core.Integration.Media.ViewModels;
using DH.Media.Infrastructure.Media.Mappings;
using DH.Media.Core.Enterprise.Common;

namespace DH.Media.Infrastructure.Media
{
    public class MediaContext : BaseContext, IMediaContext
    {
        #region Public Methods

        /// <summary>
        /// Get Presentations
        /// </summary>
        /// <param name="searchPresentation">Search Presentation</param>
        /// <param name="skip">Records to skip</param>
        /// <param name="top">Records Count</param>
        /// <param name="sortDirection">Sort Direction</param>
        /// <returns></returns>
        public List<Presentation> GetPresentations(string searchPresentation, int skip, int top, SortOrderType sortDirection)
        {
            List<Presentation> presentationList = null;
            var presentationUrl = Constants.PresentationUrl;
            if (!string.IsNullOrEmpty(searchPresentation))
            {
                presentationUrl += string.Concat(Constants.OneSpace, searchPresentation);
            }
            var request = new RestRequest(presentationUrl, Method.GET);
            request.AddParameter(Constants.Select, Constants.Full);
            request.AddParameter(Constants.Orderby, string.Concat(Constants.RecordDateOrder, sortDirection.ToString().ToLower()));
            request.AddParameter(Constants.Skip, skip);
            request.AddParameter(Constants.Top, top > 0 ? top : 2000);
            var presentations = ClientManager.Client.Execute<GenericResponse<PresentationFullRepresentation>>(request);
            if (presentations.Data?.Value != null)
            {
                presentationList = presentations.Data.Value.Select(MapToModel).ToList();
            }
            return presentationList;
        }

        /// <summary>
        /// Request Auth Ticket
        /// </summary>
        /// <param name="presentationId">Resource Id</param>
        /// <param name="minutesToLive">Minutes To Live</param>
        /// <returns></returns>
        public string RequestAuthTicket(string presentationId, int minutesToLive)
        {
            var username = KeyVaultValues.MsUserName;
            var ticket = new AuthorizationTicket
            {
                Username = username,
                ResourceId = presentationId,
                MinutesToLive = minutesToLive
            };
            var request = new RestRequest(Constants.AuthorizationTickets, Method.POST)
            {
                RequestFormat = DataFormat.Json
            };
            request.AddJsonBody(ticket);
            var ticketResponse = ClientManager.Client.Execute<GenericResponse<AuthResponse>>(request);
            var obj = JObject.Parse(ticketResponse.Content);
            var authResponse = JsonConvert.DeserializeObject<AuthResponse>(obj.ToString());
            return authResponse.TicketId;
        }

        /// <summary>
        /// Get single object of presentation
        /// </summary>
        /// <param name="presentationId">Presentation Id</param>        
        /// <returns>Presentation Object</returns>
        public Presentation GetPresentation(string presentationId)
        {
            //Get Auth info
            var authTicketInfo = RequestAuthTicket(presentationId, 1);
            var request = new RestRequest(string.Concat(Constants.PresentationsPart, presentationId, Constants.SelectPart), Method.GET);
            var presentationData = ClientManager.Client.Execute<GenericResponse<PresentationFullRepresentation>>(request);
            //Convert json to Object
            var jsSerializer = new JavaScriptSerializer();
            var presentationFullDetails = jsSerializer.Deserialize<PresentationFullRepresentation>(presentationData.Content);
            var presentation = MapToModel(presentationFullDetails);
            if (presentation.Id == null)
            {
                return null;
            }
            presentation.AuthorizationTicket = authTicketInfo;
            return presentation;
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Map to model
        /// </summary>
        /// <param name="presentationDetails">PresentationFullRepresentation Object</param>
        /// <returns></returns>
        private static Presentation MapToModel(PresentationFullRepresentation presentationDetails)
        {
            return new Presentation
            {
                Id = presentationDetails.Id,
                Name = presentationDetails.Title,
                Description = presentationDetails.Description,
                ThumbnailUrl = presentationDetails.ThumbnailUrl,
                Duration = presentationDetails.Duration,
                RecordDate = presentationDetails.RecordDate,
                PrimaryPresenter = presentationDetails.PrimaryPresenter,
                Owner = presentationDetails.Owner
            };
        }
        #endregion
    }
}

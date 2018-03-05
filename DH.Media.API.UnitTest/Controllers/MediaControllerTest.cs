using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json.Linq;
using DH.Media.API.Controllers;
using DH.Media.Core.Application.V1.Media;
using DH.Media.Core.Application.V1.Media.ViewModels;
using DH.Media.Core.Enterprise.Common;

namespace DH.Media.API.UnitTest.Controllers
{
    [TestClass]
    public class MediaControllerTest
    {
        #region Variables

        private MediaController _mediaController;
        private Mock<IMediaApplication> _mediaApplicationMock;

        #endregion

        #region Test Initializer

        [TestInitialize]
        public void TestInit()
        {
            _mediaApplicationMock = new Mock<IMediaApplication>();
            _mediaController =
                new MediaController(_mediaApplicationMock.Object) { Request = new System.Net.Http.HttpRequestMessage() };
            _mediaController.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey,
                                              new HttpConfiguration());
            _mediaController.Request.RequestUri = new Uri(ControllerTestDataBuilder.ReqUrl);
            ControllerTestDataBuilder.Query = _mediaController.Request.RequestUri.Query;
        }

        #endregion

        #region Get Media Videos

        /// <summary>
        /// Test method for unhandled exception
        /// </summary>
        [TestMethod]
        public void VerifyGetMediaVideosUnhandledException()
        {
            _mediaApplicationMock.Setup
                (
                u => u.GetMediaVideos(ControllerTestDataBuilder.TenantId, ControllerTestDataBuilder.SearchCriteria, ControllerTestDataBuilder.SortAndPaginationQueryModel))
               .Returns(new MediaResponse<Core.Application.V1.Media.ViewModels.MediaResponse>
               {
                   Code = (int)ResponseCodes.ResourceNotfound,
                   Message = Constants.ResourceNotFoundMessage,
                   Data = new Core.Application.V1.Media.ViewModels.MediaResponse()
               });
            var result = _mediaController.GetMediaVideos(ControllerTestDataBuilder.TenantId, ControllerTestDataBuilder.SortAndPaginationQueryModel, ControllerTestDataBuilder.SearchCriteria);
            var resultString = result.Content.ReadAsStringAsync();
            var objectsResult = JObject.Parse(resultString.Result);
            var resultStatusCode = result.StatusCode;
            Assert.AreEqual(HttpStatusCode.NotFound, resultStatusCode,
                                                "Expected status is not equal to actual");
            Assert.AreEqual(((int)ResponseCodes.ResourceNotfound).ToString(), objectsResult["Code"].ToString(),
                                                "Expected response code is not matching with actual result");
            Assert.AreEqual(Constants.ResourceNotFoundMessage, (string)objectsResult["Message"],
                                                "Expected Message is not matching with actual message");
        }

        /// <summary>
        /// Test method for getting media videos for valid data
        /// </summary>
        [TestMethod]
        public void VerifyGetMediaVideosForValidData()
        {
            _mediaApplicationMock.Setup(u => u.GetMediaVideos(ControllerTestDataBuilder.TenantId, ControllerTestDataBuilder.SearchCriteria, ControllerTestDataBuilder.SortAndPaginationQueryModel))
                .Returns(new MediaResponse<Core.Application.V1.Media.ViewModels.MediaResponse>
                {
                    Code = (int)ResponseCodes.Ok,
                    Message = Constants.SuccessMessage,
                    Data = new Core.Application.V1.Media.ViewModels.MediaResponse()
                });
            var result = _mediaController.GetMediaVideos(ControllerTestDataBuilder.TenantId, ControllerTestDataBuilder.SortAndPaginationQueryModel,
                                                ControllerTestDataBuilder.SearchCriteria);
            var resultString = result.Content.ReadAsStringAsync();
            var objectsResult = JObject.Parse(resultString.Result);
            var resultStatusCode = result.StatusCode;
            Assert.AreEqual(HttpStatusCode.OK, resultStatusCode,
                                                "Expected status is not equal to actual");
            Assert.AreEqual(((int)ResponseCodes.Ok).ToString(), objectsResult["Code"].ToString(),
                                                "Expected response code is not matching with actual result");
            Assert.AreEqual(Constants.SuccessMessage, (string)objectsResult["Message"],
                                                "Expected Message is not matching with actual message");
        }

        #endregion

        #region GetMediaAuthTicket

        /// <summary>
        /// Test method for unhandled exception
        /// </summary>
        [TestMethod]
        public void VerifyGetMediaAuthTicketUnhandledException()
        {
            _mediaApplicationMock.Setup
              (
              u => u.GetAuthorizationTicket(ControllerTestDataBuilder.Query))
             .Returns(new MediaResponse<string>
             {
                 Code = (int)ResponseCodes.ResourceNotfound,
                 Message = Constants.ResourceNotFoundMessage,
                 Data = null
             });
            var result = _mediaController.GetMediaAuthTicket(ControllerTestDataBuilder.TenantId);
            var resultString = result.Content.ReadAsStringAsync();
            var objectsResult = JObject.Parse(resultString.Result);
            var resultStatusCode = result.StatusCode;
            Assert.AreEqual(HttpStatusCode.NotFound, resultStatusCode,
                                                "Expected status is not equal to actual");
            Assert.AreEqual(((int)ResponseCodes.ResourceNotfound).ToString(), objectsResult["Code"].ToString(),
                                                "Expected response code is not matching with actual result");
            Assert.AreEqual(Constants.ResourceNotFoundMessage, (string)objectsResult["Message"],
                                                "Expected Message is not matching with actual message");
        }

        /// <summary>
        /// Test method for getting media auth ticket for valid data
        /// </summary>
        [TestMethod]
        public void VerifyGetMediaAuthTicketForValidData()
        {
            _mediaApplicationMock.Setup(u => u.GetAuthorizationTicket(ControllerTestDataBuilder.Query))
                .Returns(new MediaResponse<string>
                {
                    Code = 2000,
                    Message = Constants.SuccessMessage,
                    Data = ControllerTestDataBuilder.TicketTestData
                });
            var result = _mediaController.GetMediaAuthTicket(ControllerTestDataBuilder.TenantId);
            var resultString = result.Content.ReadAsStringAsync();
            var objectsResult = JObject.Parse(resultString.Result);
            var resultStatusCode = result.StatusCode;
            Assert.AreEqual(HttpStatusCode.OK, resultStatusCode,
                                                "Expected status is not equal to actual");
            Assert.AreEqual(((int)ResponseCodes.Ok).ToString(), objectsResult["Code"].ToString(),
                                                "Expected response code is not matching with actual result");
            Assert.AreEqual(Constants.SuccessMessage, (string)objectsResult["Message"],
                                                "Expected Message is not matching with actual message");
        }

        #endregion

        #region GetMediaPresentation

        /// <summary>
        /// Test method for unhandled exception
        /// </summary>        
        [TestMethod]
        public void VerifyGetMediaPresentationUnhandledException()
        {
            _mediaApplicationMock.Setup(u => u.GetPresentation(ControllerTestDataBuilder.PresentationId))
                .Returns(new MediaResponse<MediaPresentationResponse>
                {
                    Code = (int)ResponseCodes.PresentationVideoNotfound,
                    Message = Constants.PresentationVideoNotFoundMessage,
                    Data = null
                });

            var result = _mediaController.GetMediaPresentation(ControllerTestDataBuilder.PresentationId);
            var resultString = result.Content.ReadAsStringAsync();
            var objectsResult = JObject.Parse(resultString.Result);
            var resultStatusCode = result.StatusCode;
            Assert.AreEqual(HttpStatusCode.NotFound, resultStatusCode,
                                               "Expected status is not equal to actual");
            Assert.AreEqual(((int)ResponseCodes.PresentationVideoNotfound).ToString(), objectsResult["Code"].ToString(), 
                                                       "Expected code is not matching with actual code");
            Assert.AreEqual(Constants.PresentationVideoNotFoundMessage, (string)objectsResult["Message"],
                                                       "Expected Message is not matching with actual message");
        }

        /// <summary>
        /// Test method for video presentation not available exception
        /// </summary>
        [TestMethod]
        public void VerifyGetMediaPresentationVideoPresentationNotAvailableException()
        {
            _mediaApplicationMock.Setup
                (
                u => u.GetPresentation(ControllerTestDataBuilder.PresentationId))
                .Returns(new MediaResponse<MediaPresentationResponse>
                {
                    Code = (int)ResponseCodes.ResourceNotfound,
                    Message = Constants.ResourceNotFoundMessage,
                    Data = null
                });
            var result = _mediaController.GetMediaPresentation(ControllerTestDataBuilder.PresentationId);
            var resultString = result.Content.ReadAsStringAsync();
            var objectsResult = JObject.Parse(resultString.Result);
            var resultStatusCode = result.StatusCode;
            Assert.AreEqual(HttpStatusCode.NotFound, resultStatusCode,
                                                "Expected status is not equal to actual");
            Assert.AreEqual(((int)ResponseCodes.ResourceNotfound).ToString(), objectsResult["Code"].ToString(),
                                                "Expected response code is not matching with actual result");
            Assert.AreEqual(Constants.ResourceNotFoundMessage, (string)objectsResult["Message"],
                                                "Expected Message is not matching with actual message");
        }

        /// <summary>
        /// Test method to get media presentation for valid data
        /// </summary>
        [TestMethod]
        public void VerifyGetMediaPresentationForValidData()
        {
            _mediaApplicationMock.Setup(u => u.GetPresentation(ControllerTestDataBuilder.PresentationId)).
                Returns(new MediaResponse<MediaPresentationResponse>
                {
                    Code = 2000,
                    Message = Constants.SuccessMessage,
                    Data = new MediaPresentationResponse()
                });
            var result = _mediaController.GetMediaPresentation(ControllerTestDataBuilder.PresentationId);
            var resultString = result.Content.ReadAsStringAsync();
            var objectsResult = JObject.Parse(resultString.Result);
            var resultStatusCode = result.StatusCode;
            Assert.AreEqual(HttpStatusCode.OK, resultStatusCode,
                                                "Expected status is not equal to actual");
            Assert.AreEqual(((int)ResponseCodes.Ok).ToString(), objectsResult["Code"].ToString(),
                                                "Expected response code is not matching with actual result");
            Assert.AreEqual(Constants.SuccessMessage, (string)objectsResult["Message"],
                                                "Expected Message is not matching with actual message");
        }
        #endregion       
    }
}


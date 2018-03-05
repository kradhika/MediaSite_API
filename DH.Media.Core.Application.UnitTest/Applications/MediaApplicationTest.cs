using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DH.Media.Core.Application.V1.Media;
using DH.Media.Core.Enterprise.Common;
using DH.Media.Core.Enterprise.Common.Models;
using DH.Media.Core.Integration.Media;
using DH.Media.Core.Integration.Media.ViewModels;

namespace DH.Media.Core.Application.UnitTest.Applications
{
    [TestClass]
    public class MediaApplicationTest
    {
        #region Data Preparation Variables

        private MediaApplication _mediaApplication;
        private Mock<IMediaContext> _mediaContextMock;

        #endregion

        #region Test Initializer

        [TestInitialize]
        public void TestInitialize()
        {
            _mediaContextMock = new Mock<IMediaContext>();
            _mediaApplication = new MediaApplication(_mediaContextMock.Object);
        }

        #endregion

        #region Get Media Videos

        /// <summary>
        /// Test method to get media videos for valid data
        /// </summary>
        [TestMethod]
        public void VerifyGetMediaVideosForValidData()
        {
            var sortAndPaginationQueryModel = new SortAndPaginationQueryModel
            {
                Limit = 10,
                Offset = 0,
                SortDirection = SortOrderType.Asc
            };

            _mediaContextMock
                .Setup(x => x.GetPresentations(TestDataBuilder.SearchCriteria, 0, 0, sortAndPaginationQueryModel.SortDirection))
                .Returns(TestDataBuilder.PresentationLst);
            _mediaContextMock
                .Setup(x => x.GetPresentations(TestDataBuilder.SearchCriteria, 0, 10, sortAndPaginationQueryModel.SortDirection))
                .Returns(TestDataBuilder.PresentationsObj);
            var userInfo = _mediaApplication.GetMediaVideos(TestDataBuilder.TenantIdTest1,
                                                            TestDataBuilder.SearchCriteria, sortAndPaginationQueryModel);
            Assert.IsNotNull(userInfo, "Expected result should not null");
        }

        #endregion

        #region Get Authorization Ticket

        /// <summary>
        /// Test method to get authorization ticket for valid data
        /// </summary>
        [TestMethod]
        public void VerifyGetAuthorizationTicketForValidData()
        {
            _mediaContextMock
                .Setup(x => x.RequestAuthTicket(TestDataBuilder.PresentationId, TestDataBuilder.MinutesToLive))
                .Returns("SomeAuthTicket");

            var userInfo = _mediaApplication.GetAuthorizationTicket(TestDataBuilder.Query);
            Assert.IsNotNull(userInfo, "Expected result should not null");
        }

        #endregion

        #region Get Presentation

        /// <summary>
        /// Test method to get presentations if exception occurs
        /// </summary>
        [TestMethod]
        public void VerifyGetPresentationForUnhandledException()
        {
            var userInfo = _mediaApplication.GetPresentation(TestDataBuilder.PresentationId);
            Assert.AreEqual((int)ResponseCodes.PresentationVideoNotfound, userInfo.Code);
        }

        /// <summary>
        /// Test method to get presentation for valid data
        /// </summary>
        [TestMethod]
        public void VerifyGetPresentationForValidData()
        {
            _mediaContextMock
                .Setup(x => x.GetPresentation(TestDataBuilder.PresentationId))
                .Returns(new Presentation { Id = "1", Name = "Test" });

            var userInfo = _mediaApplication.GetPresentation(TestDataBuilder.PresentationId);
            Assert.IsNotNull(userInfo, "Expected result should not null");
        }

        #endregion
    }
}




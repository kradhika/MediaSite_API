using System.Collections.Generic;
using DH.Curbside.API.RegressionTest.API.WhitelistUser;
using DH.Curbside.API.RegressionTest.DataAccess;
using DH.Curbside.Core.Enterprise.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace DH.Curbside.API.RegressionTest.Steps
{
    [Binding]
    public sealed class StepDefinitionuser
    {
        UserCaller _whitelistUser;
        List<UserModel> _whitelistUserInformation;
        readonly DbConnection _dbConnect = new DbConnection();

        /// <summary>
        /// Get Users
        /// </summary>

        [Given(Constants.AccessUrlStmt)]
        public void GivenIAccessTheUrl()
        {
            string getWhiteList = ConfigurationHelper.Url;
            _whitelistUser = new UserCaller(getWhiteList);
        }

        [When(Constants.GetUsersStmt)]
        public void WhenIGetAllTheWhiteListUsersFromService()
        {
            _whitelistUserInformation = _whitelistUser.GetWhiteListUsers();
        }

        [Then(Constants.SeeUsersCntStmt)]
        public void ThenWhiteListUserCountShouldbe()
        {
            Assert.IsTrue(_whitelistUserInformation[0].Code == 2000);
            Assert.IsTrue(_whitelistUserInformation[0].Message == Constants.SuccessMessage);
            Assert.IsTrue(_whitelistUserInformation[0].Data.Users.Count == _dbConnect.GetUserCount());
        }
    }
}

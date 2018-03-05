using System.Collections.Generic;
using RestSharp;

namespace DH.Curbside.API.RegressionTest.API.WhitelistUser
{
    public class UserCaller
    {
        readonly RestClient _client;
        public UserCaller(string baseurl)
        {
            _client = new RestClient(baseurl);
        }

        /// <summary>
        /// GetWhitelist User Call
        /// </summary>        
        public List<UserModel> GetWhiteListUsers()
        {
            var request = new RestRequest("whitelist", Method.GET);
            var response = _client.Execute<List<UserModel>>(request);
            return response.Data;
         }
    }
}

using System.Collections.Generic;

namespace DH.Curbside.API.RegressionTest.API.WhitelistUser
{
    public class UserModel
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public Data Data { get; set; }
    }
    public class User
    {
        public int UserId { get; set; }
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public int ClientApplicationId { get; set; }
    }

    public class Data
    {
        public List<User> Users { get; set; }
    }




}


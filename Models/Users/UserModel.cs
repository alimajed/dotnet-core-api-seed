using System;

namespace DotNetWebApiSeed.Models.Users
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
    }
}
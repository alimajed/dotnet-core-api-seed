using System;
using System.ComponentModel.DataAnnotations;

namespace DotNetWebApiSeed.Models.Users
{
    public class RegisterModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        
        [Required]
        public DateTime? DateOfBirth { get; set; }
        
        [Required]
        public string Gender { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
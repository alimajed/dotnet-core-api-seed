using DotNetWebApiSeed.Entities;

namespace DotNetWebApiSeed.Interfaces
{
    public interface IAuthenticationService
    {
        public User Authenticate(string username, string password);
    }
}
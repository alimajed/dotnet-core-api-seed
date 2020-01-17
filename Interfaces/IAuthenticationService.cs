using DotNetWebApiSeed.Models.Users;

namespace DotNetWebApiSeed.Interfaces
{
    public interface IAuthenticationService
    {
        UserModel Authenticate(string username, string password);
    }
}
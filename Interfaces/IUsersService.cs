using System.Collections.Generic;
using DotNetWebApiSeed.Models.Users;

namespace DotNetWebApiSeed.Interfaces
{
    public interface IUsersService
    {
        IEnumerable<UserModel> GetAll(); 
        UserModel GetById(int id);
        UserModel Create(RegisterModel user);
        void Update(int id, UpdateModel user);
        void Delete(int id);
    }
}
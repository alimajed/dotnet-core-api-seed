using AutoMapper;
using DotNetWebApiSeed.Data.Entities;
using DotNetWebApiSeed.Models.Users;

namespace DotNetWebApiSeed.Helpers.Mappers
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile() {
            CreateMap<User, UserModel>();
        }
    }
}
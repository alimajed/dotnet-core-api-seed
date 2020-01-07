using System.Collections.Generic;
using System.Linq;
using DotNetWebApiSeed.Entities;

namespace DotNetWebApiSeed.Extensions
{
    public static class UsersWithoutPasswordsExtension
    {
        public static IEnumerable<User> UsersWithoutPasswords(this IEnumerable<User> users) {
            return users.Select(x => x.UsersWithoutPasswords());
        }

        public static User UsersWithoutPasswords(this User user) {
            user.Password = null;
            return user;
        }
    }
}
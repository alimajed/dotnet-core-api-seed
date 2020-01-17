using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DotNetWebApiSeed.Data;
using DotNetWebApiSeed.Data.Entities;
using DotNetWebApiSeed.Interfaces;
using DotNetWebApiSeed.Models.Users;

namespace DotNetWebApiSeed.Services
{
    public class UsersService : IUsersService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UsersService(DataContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }
        
        public IEnumerable<UserModel> GetAll()
        {
            var users = _context.Users;
            return _mapper.Map<IList<UserModel>>(users);
        }

        public UserModel GetById(int id)
        {
            var user = _context.Users.Find(id);
            return _mapper.Map<UserModel>(user);
        }

        public UserModel Create(RegisterModel user)
        {
            if (string.IsNullOrWhiteSpace(user.Password))
                throw new Exception("Password is required");

            if (_context.Users.Any(x => x.Username == user.Username))
                throw new Exception("Username \"" + user.Username + "\" is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(user.Password, out passwordHash, out passwordSalt);

            var newUser = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth,
                Gender = user.Gender,
                Username = user.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

            return _mapper.Map<UserModel>(newUser);
        }

        public void Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public void Update(int id, UpdateModel userInfo)
        {
            var user = _context.Users.Find(id);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            if (!string.IsNullOrWhiteSpace(userInfo.Username) && userInfo.Username != user.Username)
            {
                if (_context.Users.Any(x => x.Username == userInfo.Username))
                {
                    throw new Exception("Username " + userInfo.Username + " is already taken");
                }
                user.Username = userInfo.Username;
            }

            if (!string.IsNullOrWhiteSpace(userInfo.FirstName))
            {
                user.FirstName = userInfo.FirstName;
            }

            if (!string.IsNullOrWhiteSpace(userInfo.LastName))
            {
                user.LastName = userInfo.LastName;
            }

            if (!string.IsNullOrWhiteSpace(userInfo.Password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(userInfo.Password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            _context.Users.Update(user);
            _context.SaveChanges();
        }

        #region private
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        #endregion
    }
}
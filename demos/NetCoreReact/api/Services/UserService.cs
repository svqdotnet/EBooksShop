using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using LoginAPI.Models;
using System.Text;

namespace LoginAPI.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        User Create(User user, string password);
    }

    public class UserService : IUserService
    {
        private LoginTestContext _context;

        public UserService(LoginTestContext context)
        {
            _context = context;
        }

        public User Authenticate(string username, string password)
        {
            var user = _context.User.Where(x => x.Username == username).SingleOrDefault();

            if (user != null && VerifyHash(password, user.Password, user.Salt))
            {
                return user;
            }
            return null;
        }

        private static bool VerifyHash(string password, byte[] hash, byte[] salt)
        {
            if (hash.Length != 64 || salt.Length != 128)
            {
                return false;
            }
            using (var hmac = new HMACSHA512(salt))
            {
                var cHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < cHash.Length; i++)
                {
                    if (cHash[i] != hash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public User Create(User user, string password)
        {
            if (_context.User.Where(x => x.Username == user.Username).Any())
            {
                return null;
            }

            using (var hmac = new HMACSHA512())
            {
                user.Salt = hmac.Key;
                user.Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }

            user.RoleId = 1; // TODO implement role behaviour, this is just to ignore DB constraint
            _context.User.Add(user);
            _context.SaveChanges();

            return user;
        }
    }
}
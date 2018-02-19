using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerDemo.Api.Services
{
    public class UserService : IUserService
    {
        public Task<string> LoginUserAsync(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public Task LogoutUserAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task CreateUserAsync(User body)
        {
            throw new System.NotImplementedException();
        }

        public Task CreateUsersWithArrayInputAsync(IEnumerable<User> body)
        {
            throw new System.NotImplementedException();
        }

        public Task CreateUsersWithListInputAsync(IEnumerable<User> body)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteUserAsync(string username)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> GetUserByNameAsync(string username)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateUserAsync(string username, User body)
        {
            throw new System.NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerDemo.Api.Services
{
    public interface IUserService
    {
        Task<string> LoginUserAsync(string username, string password);
        Task LogoutUserAsync();
        Task CreateUserAsync(User body);
        Task CreateUsersWithArrayInputAsync(IEnumerable<User> body);
        Task CreateUsersWithListInputAsync(IEnumerable<User> body);
        Task DeleteUserAsync(string username);
        Task<User> GetUserByNameAsync(string username);
        Task UpdateUserAsync(string username, User body);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerDemo.Api.Controllers
{
    public partial class UserController : IUserApiController
    {
        public Task CreateWithArrayAsync(IEnumerable<User> body)
        {
            throw new NotImplementedException();
        }

        public Task CreateWithListAsync(IEnumerable<User> body)
        {
            throw new NotImplementedException();
        }

        public Task<string> LoginAsync(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task LogoutAsync()
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerDemo.Api.Controllers
{
    public partial class StoreController : IStoreApiController
    {
        public Task<Dictionary<string, int>> InventoryAsync()
        {
            throw new NotImplementedException();
        }

        public Task OrderDeleteAsync(long orderId)
        {
            throw new NotImplementedException();
        }

        public Task<Order> OrderGetAsync(long orderId)
        {
            throw new NotImplementedException();
        }

        public Task<Order> OrderPostAsync(Order body)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerDemo.Api.Services
{
    public class StoreService : IStoreService
    {
        public Task<Dictionary<string, int>> GetInventoryAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Order> PlaceOrderAsync(Order body)
        {
            throw new System.NotImplementedException();
        }

        public Task<Order> GetOrderByIdAsync(long orderId)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteOrderAsync(long orderId)
        {
            throw new System.NotImplementedException();
        }
    }
}

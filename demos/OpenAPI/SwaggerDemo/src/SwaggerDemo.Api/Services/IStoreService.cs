using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerDemo.Api.Services
{
    public interface IStoreService
    {
        Task<Dictionary<string, int>> GetInventoryAsync();
        Task<Order> PlaceOrderAsync(Order body);
        Task<Order> GetOrderByIdAsync(long orderId);
        Task DeleteOrderAsync(long orderId);
    }
}

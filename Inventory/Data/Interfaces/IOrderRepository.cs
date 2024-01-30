using System.Collections.Generic;
using Inventory.Model;

namespace Inventory.Data.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(FilterOrder filterOrder);
        List<Order> GetOrders(FilterOrder filterOrder);
    }
}

using System.Collections.Generic;
using Inventory.Model;

namespace Inventory.Data.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(int id);
        List<Order> GetOrders(int? id = null);
    }
}

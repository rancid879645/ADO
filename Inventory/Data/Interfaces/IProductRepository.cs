using Inventory.Model;
using System.Collections.Generic;

namespace Inventory.Data.Interfaces
{
    public interface IProductRepository
    {
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
        List<Product> GetProducts(int? id = null);

    }
}

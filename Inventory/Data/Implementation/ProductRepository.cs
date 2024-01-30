using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Inventory.Data.Interfaces;
using Inventory.Model;
using System.Configuration;
using System.Xml.Linq;


namespace Inventory.Data.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString = "Data Source=EPCOBOGW0669\\SQLEXPRESS;Initial Catalog=Inventory;Integrated Security=True;";
        public void CreateProduct(Product product)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("InsertProduct", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", product.Id);
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Description", product.Description);
                    command.Parameters.AddWithValue("@Weight", product.Weight);
                    command.Parameters.AddWithValue("@Height", product.Height);
                    command.Parameters.AddWithValue("@Width", product.Width);
                    command.Parameters.AddWithValue("@Length", product.Length);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateProduct(Product product)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("UpdateProduct", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProductId", product.Id);
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Description", product.Description);
                    command.Parameters.AddWithValue("@Weight", product.Weight);
                    command.Parameters.AddWithValue("@Height", product.Height);
                    command.Parameters.AddWithValue("@Width", product.Width);
                    command.Parameters.AddWithValue("@Length", product.Length);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteProduct(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("DeleteProduct", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProductId", id);

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Product> GetProducts(int? id = null)
        {
            var products = new List<Product>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("GetProducts", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    if (id.HasValue)
                    {
                        command.Parameters.AddWithValue("@ProductId", id.Value);
                    }

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var product = new Product
                            {
                                Id = (int)reader["Id"],
                                Name = reader["Name"].ToString(),
                                Description = reader["Description"].ToString(),
                                Weight = (int)reader["Weight"],
                                Height = (int)reader["Height"],
                                Width = (int)reader["Width"],
                                Length = (int)reader["Length"]
                            };

                            products.Add(product);
                        }
                    }
                }
            }

            return products;
        }
    }
}

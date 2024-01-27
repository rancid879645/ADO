using Inventory.Data.Interfaces;
using Inventory.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace Inventory.Data.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        public void CreateOrder(Order order)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateOrder(Order order)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteOrder(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Order> GetOrders(int? id = null)
        {
            var orders = new List<Order>();
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (var command = new SqlCommand("GetOrderById", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var order = new Order
                                {
                                    Id = (int)reader["Id"],
                                    Status = reader["Status"].ToString(),
                                    CreatedDate = (DateTime)reader["CreatedDate"],
                                    UpdatedDate = (DateTime)reader["UpdatedDate"],
                                    ProductId = (int)reader["ProductId"]
                                };

                                orders.Add(order);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            return orders;
        }
    }
}

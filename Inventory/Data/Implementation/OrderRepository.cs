using Inventory.Data.Interfaces;
using Inventory.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices.ComTypes;


namespace Inventory.Data.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly string _connectionString = "Data Source=EPCOBOGW0669\\SQLEXPRESS;Initial Catalog=Inventory;Integrated Security=True;";

        public void CreateOrder(Order order)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("InsertOrder", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", order.Id);
                    command.Parameters.AddWithValue("@StatusId", order.StatusId);
                    command.Parameters.AddWithValue("@CreatedDate", order.CreatedDate);
                    command.Parameters.AddWithValue("@UpdatedDate", order.UpdatedDate);
                    command.Parameters.AddWithValue("@ProductId", order.ProductId);

                    command.ExecuteNonQuery();
                }
            }
        }
        
        public void UpdateOrder(Order order)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("UpdateOrder", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OrderId", order.Id);
                    command.Parameters.AddWithValue("@StatusId", order.StatusId);
                    command.Parameters.AddWithValue("@UpdatedDate", order.UpdatedDate);
                    command.Parameters.AddWithValue("@ProductId", order.ProductId);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteOrder(FilterOrder filterOrder)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("DeleteOrders", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Month", filterOrder.Month);
                    command.Parameters.AddWithValue("@Year", filterOrder.Year);
                    command.Parameters.AddWithValue("@StatusId", filterOrder.StatusId);
                    command.Parameters.AddWithValue("@ProductId", filterOrder.ProductId);
                    command.Parameters.AddWithValue("@OrderId", filterOrder.OrderId);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error deleting orders: " + ex.Message);
                    }
                }
            }
        }

        public List<Order> GetOrders(FilterOrder filterOrder)
        {
            var orders = new List<Order>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("GetOrders", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Month", filterOrder.Month);
                    command.Parameters.AddWithValue("@Year", filterOrder.Year);
                    command.Parameters.AddWithValue("@StatusId", filterOrder.StatusId);
                    command.Parameters.AddWithValue("@ProductId", filterOrder.ProductId);
                    command.Parameters.AddWithValue("@OrderId", filterOrder.OrderId);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var order = new Order
                            {
                                Id = (int)reader["Id"],
                                StatusId = (int)reader["StatusId"],
                                CreatedDate = (DateTime)reader["CreatedDate"],
                                UpdatedDate = (DateTime)reader["UpdatedDate"],
                                ProductId = (int)reader["ProductId"]
                            };

                            orders.Add(order);
                        }
                    }
                }
            }

            return orders;
        }
    }
}

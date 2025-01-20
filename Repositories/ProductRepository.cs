using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
using MyBack.Models;


namespace MyBack.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;

        // Constructor que recibe la cadena de conexión
        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Product> GetProducts()
        {
            var productos = new List<Product>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // Llamamos al procedimiento almacenado
                using (var command = new SqlCommand("sp_GetProductos", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var producto = new Product
                            {
                                Id = (int)reader["Id"],
                                NombreProducto = reader["NombreProducto"].ToString(),
                                ImagenProducto = (byte[])reader["ImagenProducto"],
                                PrecioUnitario = (decimal)reader["PrecioUnitario"],
                                evt = reader["ext"].ToString()
                            };
                            productos.Add(producto);
                        }
                    }
                }
            }

            return productos;
        }
    }
}
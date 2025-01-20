using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using MyBack.Models;

namespace MyBack.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly string _connectionString;

        public ClientRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Client> GetClientes()
        {
            var clientes = new List<Client>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("sp_GetClientes", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var cliente = new Client
                            {
                                Id = (int)reader["Id"],
                                RazonSocial = reader["RazonSocial"].ToString(),
                                IdTipoCliente = (int)reader["IdTipoCliente"],
                                FechaCreacion = (DateTime)reader["FechaCreacion"],
                                RFC = reader["RFC"].ToString()
                            };
                            clientes.Add(cliente);
                        }
                    }
                }
            }

            return clientes;
        }
    }
}

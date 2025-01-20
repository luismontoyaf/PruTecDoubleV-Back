using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using MyBack.Models;

namespace MyBack.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly string _connectionString;

        public InvoiceRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void SaveInvoice(Invoice invoice, List<InvoiceDetail> invoiceDetails)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("sp_InsertarFactura", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Parámetros de la factura
                    command.Parameters.AddWithValue("@RazonSocial", invoice.NombreCliente);
                    command.Parameters.AddWithValue("@NumeroFactura", invoice.NumeroFactura);
                    command.Parameters.AddWithValue("@NumeroTotalArticulos", invoice.NumeroTotalArticulos);
                    command.Parameters.AddWithValue("@SubtotalFactura", invoice.SubtotalFactura);
                    command.Parameters.AddWithValue("@TotalImpuestos", invoice.TotalImpuestos);
                    command.Parameters.AddWithValue("@TotalFactura", invoice.TotalFactura);

                    // DataTable para los detalles de la factura
                    var detailTable = new DataTable();
                    detailTable.Columns.Add("NombreProducto", typeof(string));
                    detailTable.Columns.Add("CantidadDelProducto", typeof(int));
                    detailTable.Columns.Add("PrecioUnitarioDelProducto", typeof(decimal));
                    detailTable.Columns.Add("SubtotalProducto", typeof(decimal));
                    detailTable.Columns.Add("Notas", typeof(string));

                    foreach (var detail in invoiceDetails)
                    {
                        detailTable.Rows.Add(detail.NombreProducto, detail.CantidadDelProducto, detail.PrecioUnitarioDelProducto, detail.SubtotalProducto, detail.Notas);
                    }

                    var parameter = new SqlParameter("@DetalleFactura", SqlDbType.Structured)
                    {
                        TypeName = "dbo.TblDetalleFacturasType",
                        Value = detailTable
                    };
                    command.Parameters.Add(parameter);

                    command.ExecuteNonQuery();
                }
            }
        }


       public List<InvoicesFound> SearchInvoice(string? razonSocial, string? numeroFactura)
        {
            var invoices = new List<InvoicesFound>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("sp_SearchInvoice", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@RazonSocial", (object?)razonSocial ?? DBNull.Value);
                    command.Parameters.AddWithValue("@NumeroFactura", (object?)numeroFactura ?? DBNull.Value);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var invoice = new InvoicesFound
                            {
                                NumeroFactura = reader["NumeroFactura"].ToString(),
                                FechaEmisionFactura = reader["FechaEmisionFactura"] != DBNull.Value ? (DateTime)reader["FechaEmisionFactura"] : DateTime.MinValue,
                                TotalFactura = reader["TotalFactura"] != DBNull.Value ? (decimal)reader["TotalFactura"] : 0m
                            };

                            invoices.Add(invoice);
                        }
                    }
                }
            }

            return invoices;
        }

    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace MyBack.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; } 
        public required DateTime FechaEmisionFactura { get; set; }
        public required string NombreCliente { get; set; }
        public required int NumeroFactura { get; set; }
        public required int NumeroTotalArticulos { get; set; }
        public required decimal SubtotalFactura { get; set; }
        public required decimal TotalImpuestos { get; set; }
        public required decimal TotalFactura { get; set; }
    }

    public class InvoiceDetail
    {
        [Key]
        public int Id { get; set; } 
        public required string NombreProducto { get; set; }
        public required int CantidadDelProducto { get; set; }
        public required decimal PrecioUnitarioDelProducto { get; set; }
        public required decimal SubtotalProducto { get; set; }
        public required string Notas { get; set; }
    }

    public class InvoiceRequest
    {
        public Invoice Invoice { get; set; }
        public List<InvoiceDetail> InvoiceDetails { get; set; }
    }

    public class SearchInvoice {
        public string? Client { get; set; }
        public string? NumeroFactura { get; set; }
    }

    public class InvoicesFound{
        public string? NumeroFactura { get; set; }
        public DateTime FechaEmisionFactura { get; set; }
        public decimal TotalFactura { get; set; } 
    }
}
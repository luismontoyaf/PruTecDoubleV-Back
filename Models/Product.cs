using System;
using System.ComponentModel.DataAnnotations;

namespace MyBack.Models
{
    public class Product
    {
        [Key]
        public required int Id { get; set; } 
        public required string NombreProducto { get; set; }
        public required byte[] ImagenProducto { get; set; }
        public required decimal PrecioUnitario { get; set; }
        public required string evt { get; set; }       
    }
}

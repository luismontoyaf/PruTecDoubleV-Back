using System;
using System.ComponentModel.DataAnnotations;

namespace MyBack.Models
{
    public class Client
    {
        [Key]
        public required int Id { get; set; }              
        public required string RazonSocial { get; set; } 
        public required int IdTipoCliente { get; set; }   
        public required DateTime FechaCreacion { get; set; }
        public required string RFC { get; set; }  
    }
}

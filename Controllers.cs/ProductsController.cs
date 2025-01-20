using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.Data.SqlClient;
using MyBack.Services;
using MyBack.Models;

namespace MyBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            // Llamamos al servicio que obtiene los datos
            List<Product> productos = _productService.GetAllProducts();

            // Devolvemos los datos directamente
            return Ok(productos);
        }
    }
}

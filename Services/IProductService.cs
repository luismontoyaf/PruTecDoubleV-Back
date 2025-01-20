using MyBack.Models;
using System.Collections.Generic;

namespace MyBack.Services
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
    }
}

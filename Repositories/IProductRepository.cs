using MyBack.Models;
using System.Collections.Generic;

namespace MyBack.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
    }
}
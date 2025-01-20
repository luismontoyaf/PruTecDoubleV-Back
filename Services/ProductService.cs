using MyBack.Repositories;
using MyBack.Models;
using System.Collections.Generic;

namespace MyBack.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.GetProducts();
        }
    }
}

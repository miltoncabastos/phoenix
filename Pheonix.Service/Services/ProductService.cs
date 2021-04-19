using Pheonix.Domain.Entities;
using Pheonix.Interfaces.Products;
using Pheonix.Service.Interfaces;

namespace Pheonix.Service.Services
{
    public class ProductService : BaseService<Product>, IProductService
    {
        public ProductService(IProductRepository productRepository) : base(productRepository)
        {
        }
    }
}

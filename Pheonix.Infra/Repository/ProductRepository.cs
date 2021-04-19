using Pheonix.Domain.Entities;
using Pheonix.Infra.Context;
using Pheonix.Interfaces.Products;

namespace Pheonix.Infra.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(PheonixContext pheonixContext) : base(pheonixContext)
        {

        }
    }
}

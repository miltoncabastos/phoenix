using Microsoft.EntityFrameworkCore;
using Pheonix.Domain.Entities;
using Pheonix.Infra.Context;
using Pheonix.Interfaces.Stocks;
using System.Collections.Generic;
using System.Linq;

namespace Pheonix.Infra.Repository
{
    public class StockRepository : BaseRepository<Stock>, IStockRepository
    {

        public StockRepository(PheonixContext pheonixContext) : base(pheonixContext)
        {

        }

        public IList<Stock> GetStocksCliente(int idClient)
        {
            return Query()
                .Where(stock => stock.ClientId == idClient)
                .Include(stock => stock.Client)
                .Include(stock => stock.Product)
                .ToList();
        }

        public Stock GetStockClienteProduct(int clientId, int productId)
        {
            return Query()
                .FirstOrDefault(stock => stock.ClientId == clientId && stock.ProductId == productId);
        }
    }
}

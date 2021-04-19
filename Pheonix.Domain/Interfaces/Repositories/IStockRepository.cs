using Pheonix.Domain.Entities;
using Pheonix.Domain.Interfaces;
using System.Collections.Generic;

namespace Pheonix.Interfaces.Stocks
{
    public interface IStockRepository : IBaseRepository<Stock>
    {
        IList<Stock> GetStocksCliente(int idClient);
        Stock GetStockClienteProduct(int clientId, int productId);
    }
}

using Pheonix.Domain.Entities;
using Pheonix.Service.Dto.Stocks;

namespace Pheonix.Service.Interfaces
{
    public interface IStockService : IBaseService<Stock>
    {
        Stock Add(StockCreate stock);
        ClientStockDto GetStocksClient(int clientId);
        void AddAmountInStockClient(StockAddAndSubtractAmountDto addStock);        
        void SubtractAmountInStockClient(StockAddAndSubtractAmountDto subtractStock);        
    }
}

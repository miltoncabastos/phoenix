using Pheonix.Domain.Entities;
using Pheonix.Interfaces.Stocks;
using Pheonix.Service.Dto.Stocks;
using Pheonix.Service.Interfaces;
using Pheonix.Service.Validators;
using System;
using System.Linq;

namespace Pheonix.Service.Services
{
    public class StockService : BaseService<Stock>, IStockService
    {
        private readonly IStockRepository _stockRepository;

        public StockService(IStockRepository stockRepository) : base(stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public Stock Add(StockCreate stock)
        {
            var stockCreate = new Stock
            {
                ClientId = stock.ClientId,
                ProductId = stock.ProductId,
                Amount = decimal.Zero
            };

            return Add<StockValidator>(stockCreate);
        }

        public ClientStockDto GetStocksClient(int clientId)
        {
            var stock = _stockRepository.GetStocksCliente(clientId).ToList();

            var client = stock.First().Client;
            var products = stock
                .Select(s => new ClientStockProductDto {
                    ProductId = s.ProductId,
                    ProductDescription = s.Product.Description,
                    ProductAmount = s.Amount
            });

            return new ClientStockDto
            {
                ClientId = client.Id,
                ClientName = client.Name,
                Products = products.ToList()
            };
        }

        public void AddAmountInStockClient(StockAddAndSubtractAmountDto addStock)
        {
            var stock = GetStockForClientAndProduct(addStock.ClientId, addStock.ProductId);
            stock.AddAmount(addStock.Amount);
            _stockRepository.Update(stock);
        }        

        public void SubtractAmountInStockClient(StockAddAndSubtractAmountDto subtractStock)
        {
            var stock = GetStockForClientAndProduct(subtractStock.ClientId, subtractStock.ProductId);
            stock.SubtractAmount(subtractStock.Amount);
            _stockRepository.Update(stock);
        }

        private Stock GetStockForClientAndProduct(int clientId, int productId)
        {
            return _stockRepository.GetStockClienteProduct(clientId, productId)
                ?? throw new Exception("Estoque não encontrado");
        }
    }
}

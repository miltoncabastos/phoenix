using Microsoft.AspNetCore.Mvc;
using Pheonix.Service.Dto.Stocks;
using Pheonix.Service.Interfaces;
using Pheonix.W.Controllers;

namespace Pheonix.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockController : BaseController
    {
        private readonly IStockService _stockService;

        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }        

        [HttpGet]
        [Route("{idClient}")]
        public IActionResult GetStockForClient(int idClient)
        {
            return Execute(() => _stockService.GetStocksClient(idClient));
        }

        [HttpPost]
        public IActionResult AddAmountStock([FromBody] StockCreate stock)
        {
            if (stock == null)
                return NotFound();

            return Execute(() => _stockService.Add(stock).Id);
        }

        [HttpPost]
        [Route("/add-amount-stock")]
        public IActionResult AddAmountStock([FromBody] StockAddAndSubtractAmountDto addStock)
        {
            return Execute(() =>
            {
                _stockService.AddAmountInStockClient(addStock);
                return true;
            });
        }

        [HttpPost]
        [Route("/subtract-amount-stock")]
        public IActionResult SubtractAmountStock([FromBody] StockAddAndSubtractAmountDto addStock)
        {
            return Execute(() =>
            {
                _stockService.SubtractAmountInStockClient(addStock);
                return true;
            });
        }
    }
}

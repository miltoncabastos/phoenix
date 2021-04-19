namespace Pheonix.Service.Dto.Stocks
{
    public class StockAddAndSubtractAmountDto
    {
        public int ClientId { get; set; }
        public int ProductId { get; set; }
        public decimal Amount { get; set; }
    }
}

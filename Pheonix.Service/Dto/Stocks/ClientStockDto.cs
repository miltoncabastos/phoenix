using System.Collections.Generic;

namespace Pheonix.Service.Dto.Stocks
{
    public class ClientStockDto
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public IList<ClientStockProductDto> Products { get; set; }
    }
}

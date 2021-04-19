using FluentAssertions;
using Pheonix.Domain.Entities;
using Xunit;

namespace Pheonix.Tests.Domain
{
    public class StockTest
    {
        [Theory]
        [InlineData(2)]
        [InlineData(6)]
        [InlineData(14)]
        public void AddAmount_Ok(decimal amountForAdd)
        {
            // Arrange
            var amountOriginal = 5;
            var stock = new Stock
            {
                Id = 1,
                ClientId = 1,
                ProductId = 1,
                Actived = true,
                Amount = amountOriginal
            };

            // Act
            stock.AddAmount(amountForAdd);

            // Assert
            stock.Amount.Should().Be(amountOriginal + amountForAdd);
        }
    }
}

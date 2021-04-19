using Bogus;
using FluentAssertions;
using Pheonix.Domain.Entities;
using Pheonix.Infra.Repository;
using Xunit;

namespace Pheonix.Tests.Infra.Repository
{
    public class StockRepositoryTest
    {
        [Fact]
        public void GetStockClienteProduct_Ok()
        {
            // Arrange
            var context = DbContextFake.GetDbContext();

            var client = new Faker<Client>()
                .RuleFor(o => o.Id, f => 1)
                .RuleFor(o => o.Name, f => string.Empty)
                .RuleFor(o => o.Email, f => f.Person.Email)
                .RuleFor(o => o.Actived, f => true)
                .Generate();

            var product = new Faker<Product>()
                .RuleFor(o => o.Id, f => 1)
                .RuleFor(o => o.Description, f => f.Lorem.Paragraph())
                .Generate();

            var stock = new Stock
            {
                Id = 1,
                Client = client,
                Product = product,
                Actived = true,
                Amount = 0
            };

            context.Add(client);
            context.Add(product);
            context.Add(stock);
            context.SaveChanges();

            var stockRepository = new StockRepository(context);

            // Act
            var result = stockRepository.GetStockClienteProduct(client.Id, product.Id);

            // Assert
            result.Should().BeEquivalentTo(stock);
        }
    }
}

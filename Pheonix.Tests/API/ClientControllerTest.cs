using Bogus;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Pheonix.API.Controllers;
using Pheonix.Domain.Entities;
using Pheonix.Service.Interfaces;
using Xunit;

namespace Pheonix.Tests.API
{
    public class ClientControllerTest
    {
        [Fact]
        public void Get_Ok()
        {
            // Arrange
            var client = new Faker<Client>()
                .RuleFor(o => o.Id, f => 1)
                .RuleFor(o => o.Name, f => f.Person.FullName)
                .RuleFor(o => o.Email, f => f.Person.Email)
                .RuleFor(o => o.Actived, f => true)
                .Generate();

            var clientService = new Mock<IClientService>();
            clientService
                .Setup(service => service.Get(It.IsAny<int>()))
                .Returns(client);

            var controller = new ClientController(clientService.Object);

            // Act
            var result = controller.Get(1);

            // Assert
            var response =  Assert.IsType<OkObjectResult>(result);
            var responseClient = Assert.IsType<Client>(response.Value);
            responseClient.Should().BeEquivalentTo(client);
        }
    }
}

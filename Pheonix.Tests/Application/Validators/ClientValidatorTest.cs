using Bogus;
using FluentAssertions;
using Pheonix.Domain.Entities;
using Pheonix.Service.Validators;
using Xunit;

namespace Pheonix.Tests.Application.Validators
{
    public class ClientValidatorTest
    {
        [Fact]
        public void Name_Error()
        {
            // Arrange
            var client = new Faker<Client>()
                .RuleFor(o => o.Id, f => 1)
                .RuleFor(o => o.Name, f => string.Empty)
                .RuleFor(o => o.Email, f => f.Person.Email)
                .RuleFor(o => o.Actived, f => true)
                .Generate();

            // Act
            var validator = new ClientValidator().Validate(client);

            // Assert
            validator.IsValid.Should().BeFalse();
            validator.Errors[0].ErrorMessage.Should().Be("O nome deve ser preenchido");
        }
    }
}

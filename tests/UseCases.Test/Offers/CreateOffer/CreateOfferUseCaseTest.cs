using Bogus;
using Moq;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.UseCases.Offers.CreateOffer;
using RocketseatAuction.API.Communication.Request;
using Xunit;
using RocketseatAuction.API.Services;
using RocketseatAuction.API.Entities;
using FluentAssertions;

namespace UseCases.Test.Offers.CreateOffer;

public class CreateOfferUseCaseTest
{
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void Success(int itemId)
    {
        var request = new Faker< RequestCreateOfferJson>()
            .RuleFor(r => r.Price, f => f.Random.Decimal(1, 10)).Generate();
        var offerRepository = new Mock<IOfferRepository>();
        var loggedUser = new Mock<ILoggedUser>();
        loggedUser.Setup(x => x.User())
            .Returns(new User());
        var useCase = new CreateOfferUseCase(loggedUser.Object, offerRepository.Object);

        var act = () => useCase.Execute(itemId, request);

        act.Should().NotThrow();
    }
}

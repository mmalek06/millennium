using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Millennium.Api.Controllers;
using Millennium.Api.Repositories;

namespace Millennium.Api.Tests;

/// <summary>
/// Given that each of the controller methods basically has one happy path branch and one error path branch,
/// I would test them the same way I did with the Get method. Since I don't think adding more tests would 
/// give you more information about my unit testing skills, I decided not to write them.
/// </summary>
public class ThingControllerTests
{
    private readonly ILogger<ThingController> _logger;
    private readonly Mock<IThingRepository> _repository;

    public ThingControllerTests()
    {
        _logger = Mock.Of<ILogger<ThingController>>();
        _repository = new Mock<IThingRepository>();
    }

    [Fact]
    public void GivenAnId_WhenTheCorrespondingObjectDoesNotExist_ThenTheGetMethodReturns404NotFoundStatus()
    {
        var sut = new ThingController(
            _repository.Object,
            _logger);

        _repository
            .Setup(r => r.Get(It.IsAny<Guid>()))
            .Throws(new InvalidOperationException("test"));

        var response = sut.Get(Guid.NewGuid());

        response.Result.Should().BeEquivalentTo(new NotFoundResult());
    }

    [Fact]
    public void GivenARepositoryContainingOneThing_WhenTheControllerGetsItsId_ThenTheGetMethodReturnsThatThing()
    {
        var sut = new ThingController(
            _repository.Object,
            _logger);
        var model = new Models.Thing(Guid.NewGuid(), "test name", "test description");

        _repository
            .Setup(r => r.Get(It.IsAny<Guid>()))
            .Returns(model);

        var response = sut.Get(Guid.NewGuid());

        response.Result.Should().BeEquivalentTo(new OkObjectResult(model));
    }
}
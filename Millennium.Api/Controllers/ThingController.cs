using Microsoft.AspNetCore.Mvc;
using Millennium.Api.Dtos;
using Millennium.Api.Extensions;
using Millennium.Api.Models;
using Millennium.Api.Repositories;

namespace Millennium.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Consumes("application/json", "application/xml")]
[Produces("application/json", "application/xml")]
public class ThingController : ControllerBase
{
    private readonly IThingRepository _repository;
    private readonly ILogger<ThingController> _logger;

    public ThingController(
        IThingRepository repository,
        ILogger<ThingController> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Thing), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Thing> Get(Guid id)
    {
        try
        {
            return Ok(_repository.Get(id));
        }
        catch (InvalidOperationException exc)
        {
            _logger.LogError(exc, "An error has occurred while getting a thing.");

            return NotFound();
        }
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult Post(ThingRequestModel dto)
    {
        try
        {
            _repository.Create(dto.ToModel());

            return Ok();
        }
        catch (InvalidOperationException exc)
        {
            _logger.LogError(exc, "An error has occurred while creating a thing.");

            return BadRequest();
        }
    }

    [HttpPut]
    [ProducesResponseType(typeof(Thing), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Put(ThingRequestModel dto)
    {
        try
        {
            _repository.Update(dto.ToModel());

            return Ok();
        }
        catch (InvalidOperationException exc)
        {
            _logger.LogError(exc, "An error has occurred while creating a thing.");

            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult Delete(Guid id)
    {
        try
        {
            _repository.Delete(id);

            return NoContent();
        }
        catch (InvalidOperationException exc)
        {
            _logger.LogError(exc, "An error has occurred while deleting a thing.");

            return BadRequest();
        }
    }
}
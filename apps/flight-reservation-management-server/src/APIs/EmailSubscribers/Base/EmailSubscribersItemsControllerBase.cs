using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class EmailSubscribersItemsControllerBase : ControllerBase
{
    protected readonly IEmailSubscribersItemsService _service;

    public EmailSubscribersItemsControllerBase(IEmailSubscribersItemsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one EmailSubscribers
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<EmailSubscribers>> CreateEmailSubscribers(
        EmailSubscribersCreateInput input
    )
    {
        var emailSubscribers = await _service.CreateEmailSubscribers(input);

        return CreatedAtAction(
            nameof(EmailSubscribers),
            new { id = emailSubscribers.Id },
            emailSubscribers
        );
    }

    /// <summary>
    /// Delete one EmailSubscribers
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteEmailSubscribers(
        [FromRoute()] EmailSubscribersWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteEmailSubscribers(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many EmailSubscribersItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<EmailSubscribers>>> EmailSubscribersItems(
        [FromQuery()] EmailSubscribersFindManyArgs filter
    )
    {
        return Ok(await _service.EmailSubscribersItems(filter));
    }

    /// <summary>
    /// Meta data about EmailSubscribers records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> EmailSubscribersItemsMeta(
        [FromQuery()] EmailSubscribersFindManyArgs filter
    )
    {
        return Ok(await _service.EmailSubscribersItemsMeta(filter));
    }

    /// <summary>
    /// Get one EmailSubscribers
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<EmailSubscribers>> EmailSubscribers(
        [FromRoute()] EmailSubscribersWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.EmailSubscribers(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one EmailSubscribers
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateEmailSubscribers(
        [FromRoute()] EmailSubscribersWhereUniqueInput uniqueId,
        [FromQuery()] EmailSubscribersUpdateInput emailSubscribersUpdateDto
    )
    {
        try
        {
            await _service.UpdateEmailSubscribers(uniqueId, emailSubscribersUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}

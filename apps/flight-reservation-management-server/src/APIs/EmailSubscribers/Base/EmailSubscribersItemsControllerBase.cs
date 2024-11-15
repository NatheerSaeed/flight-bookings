using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class EmailSubscribersControllerBase : ControllerBase
{
    protected readonly IEmailSubscribersService _service;

    public EmailSubscribersControllerBase(IEmailSubscribersService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one EmailSubscribers
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<EmailSubscribers>> CreateEmailSubscriber(
        EmailSubscriberCreateInput input
    )
    {
        var emailSubscribers = await _service.CreateEmailSubscriber(input);

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
    public async Task<ActionResult> DeleteEmailSubscriber(
        [FromRoute()] EmailSubscribersWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteEmailSubscriber(uniqueId);
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
    public async Task<ActionResult<List<EmailSubscribers>>> EmailSubscribersSearchAsync(
        [FromQuery()] EmailSubscriberFindManyArgs filter
    )
    {
        return Ok(await _service.EmailSubscribersSearchAsync(filter));
    }

    /// <summary>
    /// Meta data about EmailSubscribers records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> EmailSubscribersItemsMeta(
        [FromQuery()] EmailSubscriberFindManyArgs filter
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
    public async Task<ActionResult> UpdateEmailSubscriber(
        [FromRoute()] EmailSubscribersWhereUniqueInput uniqueId,
        [FromQuery()] EmailSubscriberUpdateInput emailSubscribersUpdateDto
    )
    {
        try
        {
            await _service.UpdateEmailSubscriber(uniqueId, emailSubscribersUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}

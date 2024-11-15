using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class OnlinePaymentsControllerBase : ControllerBase
{
    protected readonly IOnlinePaymentsService _service;

    public OnlinePaymentsControllerBase(IOnlinePaymentsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one OnlinePayments
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<OnlinePayments>> CreateOnlinePayment(
        OnlinePaymentCreateInput input
    )
    {
        var onlinePayments = await _service.CreateOnlinePayment(input);

        return CreatedAtAction(
            nameof(OnlinePayments),
            new { id = onlinePayments.Id },
            onlinePayments
        );
    }

    /// <summary>
    /// Delete one OnlinePayments
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteOnlinePayment(
        [FromRoute()] OnlinePaymentsWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteOnlinePayment(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many OnlinePaymentsItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<OnlinePayments>>> OnlinePaymentsItems(
        [FromQuery()] OnlinePaymentFindManyArgs filter
    )
    {
        return Ok(await _service.OnlinePaymentsItems(filter));
    }

    /// <summary>
    /// Meta data about OnlinePayments records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> OnlinePaymentsItemsMeta(
        [FromQuery()] OnlinePaymentFindManyArgs filter
    )
    {
        return Ok(await _service.OnlinePaymentsItemsMeta(filter));
    }

    /// <summary>
    /// Get one OnlinePayments
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<OnlinePayments>> OnlinePayments(
        [FromRoute()] OnlinePaymentsWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.OnlinePayments(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one OnlinePayments
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateOnlinePayment(
        [FromRoute()] OnlinePaymentsWhereUniqueInput uniqueId,
        [FromQuery()] OnlinePaymentUpdateInput onlinePaymentsUpdateDto
    )
    {
        try
        {
            await _service.UpdateOnlinePayment(uniqueId, onlinePaymentsUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a user_ record for OnlinePayments
    /// </summary>
    [HttpGet("{Id}/user")]
    public async Task<ActionResult<List<User>>> GetUser(
        [FromRoute()] OnlinePaymentsWhereUniqueInput uniqueId
    )
    {
        var user = await _service.GetUser(uniqueId);
        return Ok(user);
    }
}

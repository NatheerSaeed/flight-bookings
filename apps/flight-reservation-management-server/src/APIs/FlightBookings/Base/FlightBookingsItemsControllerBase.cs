using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class FlightBookingsControllerBase : ControllerBase
{
    protected readonly IFlightBookingsService _service;

    public FlightBookingsControllerBase(IFlightBookingsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one FlightBookings
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<FlightBookings>> CreateFlightBookings(
        FlightBookingCreateInput input
    )
    {
        var flightBookings = await _service.CreateFlightBookings(input);

        return CreatedAtAction(
            nameof(FlightBookings),
            new { id = flightBookings.Id },
            flightBookings
        );
    }

    /// <summary>
    /// Delete one FlightBookings
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteFlightBookings(
        [FromRoute()] FlightBookingsWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteFlightBookings(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many FlightBookingsItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<FlightBookings>>> FlightBookingsItems(
        [FromQuery()] FlightBookingFindManyArgs filter
    )
    {
        return Ok(await _service.FlightBookingsItems(filter));
    }

    /// <summary>
    /// Meta data about FlightBookings records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> FlightBookingsItemsMeta(
        [FromQuery()] FlightBookingFindManyArgs filter
    )
    {
        return Ok(await _service.FlightBookingsItemsMeta(filter));
    }

    /// <summary>
    /// Get one FlightBookings
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<FlightBookings>> FlightBookings(
        [FromRoute()] FlightBookingsWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.FlightBookings(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one FlightBookings
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateFlightBookings(
        [FromRoute()] FlightBookingsWhereUniqueInput uniqueId,
        [FromQuery()] FlightBookingUpdateInput flightBookingsUpdateDto
    )
    {
        try
        {
            await _service.UpdateFlightBookings(uniqueId, flightBookingsUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a user_ record for FlightBookings
    /// </summary>
    [HttpGet("{Id}/user")]
    public async Task<ActionResult<List<User>>> GetUser(
        [FromRoute()] FlightBookingsWhereUniqueInput uniqueId
    )
    {
        var user = await _service.GetUser(uniqueId);
        return Ok(user);
    }

    /// <summary>
    /// Get a voucher_ record for FlightBookings
    /// </summary>
    [HttpGet("{Id}/voucher")]
    public async Task<ActionResult<List<Vouchers>>> GetVoucher(
        [FromRoute()] FlightBookingsWhereUniqueInput uniqueId
    )
    {
        var vouchers = await _service.GetVoucher(uniqueId);
        return Ok(vouchers);
    }
}

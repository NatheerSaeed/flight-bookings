using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class FlightBookingsItemsControllerBase : ControllerBase
{
    protected readonly IFlightBookingsItemsService _service;

    public FlightBookingsItemsControllerBase(IFlightBookingsItemsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one FlightBookings
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<FlightBookings>> CreateFlightBookings(
        FlightBookingsCreateInput input
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
        [FromQuery()] FlightBookingsFindManyArgs filter
    )
    {
        return Ok(await _service.FlightBookingsItems(filter));
    }

    /// <summary>
    /// Meta data about FlightBookings records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> FlightBookingsItemsMeta(
        [FromQuery()] FlightBookingsFindManyArgs filter
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
        [FromQuery()] FlightBookingsUpdateInput flightBookingsUpdateDto
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
}

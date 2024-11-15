using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class CarBookingsControllerBase : ControllerBase
{
    protected readonly ICarBookingsService _service;

    public CarBookingsControllerBase(ICarBookingsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one CarBookings
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<CarBookings>> CreateCarBookings(CarBookingCreateInput input)
    {
        var carBookings = await _service.CreateCarBookings(input);

        return CreatedAtAction(nameof(CarBookings), new { id = carBookings.Id }, carBookings);
    }

    /// <summary>
    /// Delete one CarBookings
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteCarBookings(
        [FromRoute()] CarBookingsWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteCarBookings(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many CarBookingsItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<CarBookings>>> CarBookingsItems(
        [FromQuery()] CarBookingFindManyArgs filter
    )
    {
        return Ok(await _service.CarBookingsItems(filter));
    }

    /// <summary>
    /// Meta data about CarBookings records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> CarBookingsItemsMeta(
        [FromQuery()] CarBookingFindManyArgs filter
    )
    {
        return Ok(await _service.CarBookingsItemsMeta(filter));
    }

    /// <summary>
    /// Get one CarBookings
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<CarBookings>> CarBookings(
        [FromRoute()] CarBookingsWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.CarBookings(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one CarBookings
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateCarBookings(
        [FromRoute()] CarBookingsWhereUniqueInput uniqueId,
        [FromQuery()] CarBookingUpdateInput carBookingsUpdateDto
    )
    {
        try
        {
            await _service.UpdateCarBookings(uniqueId, carBookingsUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a user_ record for CarBookings
    /// </summary>
    [HttpGet("{Id}/user")]
    public async Task<ActionResult<List<User>>> GetUser(
        [FromRoute()] CarBookingsWhereUniqueInput uniqueId
    )
    {
        var user = await _service.GetUser(uniqueId);
        return Ok(user);
    }
}

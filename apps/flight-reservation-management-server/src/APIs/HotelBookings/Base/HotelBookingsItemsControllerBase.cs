using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class HotelBookingsControllerBase : ControllerBase
{
    protected readonly IHotelBookingsService _service;

    public HotelBookingsControllerBase(IHotelBookingsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one HotelBookings
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<HotelBookings>> CreateHotelBookings(
        HotelBookingCreateInput input
    )
    {
        var hotelBookings = await _service.CreateHotelBookings(input);

        return CreatedAtAction(nameof(HotelBookings), new { id = hotelBookings.Id }, hotelBookings);
    }

    /// <summary>
    /// Delete one HotelBookings
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteHotelBookings(
        [FromRoute()] HotelBookingsWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteHotelBookings(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many HotelBookingsItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<HotelBookings>>> HotelBookingsItems(
        [FromQuery()] HotelBookingFindManyArgs filter
    )
    {
        return Ok(await _service.HotelBookingsItems(filter));
    }

    /// <summary>
    /// Meta data about HotelBookings records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> HotelBookingsItemsMeta(
        [FromQuery()] HotelBookingFindManyArgs filter
    )
    {
        return Ok(await _service.HotelBookingsItemsMeta(filter));
    }

    /// <summary>
    /// Get one HotelBookings
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<HotelBookings>> HotelBookings(
        [FromRoute()] HotelBookingsWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.HotelBookings(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one HotelBookings
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateHotelBookings(
        [FromRoute()] HotelBookingsWhereUniqueInput uniqueId,
        [FromQuery()] HotelBookingUpdateInput hotelBookingsUpdateDto
    )
    {
        try
        {
            await _service.UpdateHotelBookings(uniqueId, hotelBookingsUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a user_ record for HotelBookings
    /// </summary>
    [HttpGet("{Id}/user")]
    public async Task<ActionResult<List<User>>> GetUser(
        [FromRoute()] HotelBookingsWhereUniqueInput uniqueId
    )
    {
        var user = await _service.GetUser(uniqueId);
        return Ok(user);
    }

    /// <summary>
    /// Get a voucher_ record for HotelBookings
    /// </summary>
    [HttpGet("{Id}/voucher")]
    public async Task<ActionResult<List<Vouchers>>> GetVoucher(
        [FromRoute()] HotelBookingsWhereUniqueInput uniqueId
    )
    {
        var vouchers = await _service.GetVoucher(uniqueId);
        return Ok(vouchers);
    }
}

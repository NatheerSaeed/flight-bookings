using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class VouchersControllerBase : ControllerBase
{
    protected readonly IVouchersService _service;

    public VouchersControllerBase(IVouchersService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Vouchers
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Vouchers>> CreateVouchers(VoucherCreateInput input)
    {
        var vouchers = await _service.CreateVouchers(input);

        return CreatedAtAction(nameof(Vouchers), new { id = vouchers.Id }, vouchers);
    }

    /// <summary>
    /// Delete one Vouchers
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteVouchers([FromRoute()] VouchersWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteVouchers(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many VouchersItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Vouchers>>> VouchersItems(
        [FromQuery()] VoucherFindManyArgs filter
    )
    {
        return Ok(await _service.VouchersItems(filter));
    }

    /// <summary>
    /// Meta data about Vouchers records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> VouchersItemsMeta(
        [FromQuery()] VoucherFindManyArgs filter
    )
    {
        return Ok(await _service.VouchersItemsMeta(filter));
    }

    /// <summary>
    /// Get one Vouchers
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Vouchers>> Vouchers(
        [FromRoute()] VouchersWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Vouchers(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Vouchers
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateVouchers(
        [FromRoute()] VouchersWhereUniqueInput uniqueId,
        [FromQuery()] VoucherUpdateInput vouchersUpdateDto
    )
    {
        try
        {
            await _service.UpdateVouchers(uniqueId, vouchersUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple FlightBookingsItems records to Vouchers
    /// </summary>
    [HttpPost("{Id}/flightBookingsItems")]
    public async Task<ActionResult> ConnectFlightBookingsItems(
        [FromRoute()] VouchersWhereUniqueInput uniqueId,
        [FromQuery()] FlightBookingsWhereUniqueInput[] flightBookingsItemsId
    )
    {
        try
        {
            await _service.ConnectFlightBookingsItems(uniqueId, flightBookingsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple FlightBookingsItems records from Vouchers
    /// </summary>
    [HttpDelete("{Id}/flightBookingsItems")]
    public async Task<ActionResult> DisconnectFlightBookingsItems(
        [FromRoute()] VouchersWhereUniqueInput uniqueId,
        [FromBody()] FlightBookingsWhereUniqueInput[] flightBookingsItemsId
    )
    {
        try
        {
            await _service.DisconnectFlightBookingsItems(uniqueId, flightBookingsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple FlightBookingsItems records for Vouchers
    /// </summary>
    [HttpGet("{Id}/flightBookingsItems")]
    public async Task<ActionResult<List<FlightBookings>>> FindFlightBookingsItems(
        [FromRoute()] VouchersWhereUniqueInput uniqueId,
        [FromQuery()] FlightBookingFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindFlightBookingsItems(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple FlightBookingsItems records for Vouchers
    /// </summary>
    [HttpPatch("{Id}/flightBookingsItems")]
    public async Task<ActionResult> UpdateFlightBookingsItems(
        [FromRoute()] VouchersWhereUniqueInput uniqueId,
        [FromBody()] FlightBookingsWhereUniqueInput[] flightBookingsItemsId
    )
    {
        try
        {
            await _service.UpdateFlightBookingsItems(uniqueId, flightBookingsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple HotelBookingsItems records to Vouchers
    /// </summary>
    [HttpPost("{Id}/hotelBookingsItems")]
    public async Task<ActionResult> ConnectHotelBookingsItems(
        [FromRoute()] VouchersWhereUniqueInput uniqueId,
        [FromQuery()] HotelBookingsWhereUniqueInput[] hotelBookingsItemsId
    )
    {
        try
        {
            await _service.ConnectHotelBookingsItems(uniqueId, hotelBookingsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple HotelBookingsItems records from Vouchers
    /// </summary>
    [HttpDelete("{Id}/hotelBookingsItems")]
    public async Task<ActionResult> DisconnectHotelBookingsItems(
        [FromRoute()] VouchersWhereUniqueInput uniqueId,
        [FromBody()] HotelBookingsWhereUniqueInput[] hotelBookingsItemsId
    )
    {
        try
        {
            await _service.DisconnectHotelBookingsItems(uniqueId, hotelBookingsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple HotelBookingsItems records for Vouchers
    /// </summary>
    [HttpGet("{Id}/hotelBookingsItems")]
    public async Task<ActionResult<List<HotelBookings>>> FindHotelBookingsItems(
        [FromRoute()] VouchersWhereUniqueInput uniqueId,
        [FromQuery()] HotelBookingFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindHotelBookingsItems(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple HotelBookingsItems records for Vouchers
    /// </summary>
    [HttpPatch("{Id}/hotelBookingsItems")]
    public async Task<ActionResult> UpdateHotelBookingsItems(
        [FromRoute()] VouchersWhereUniqueInput uniqueId,
        [FromBody()] HotelBookingsWhereUniqueInput[] hotelBookingsItemsId
    )
    {
        try
        {
            await _service.UpdateHotelBookingsItems(uniqueId, hotelBookingsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}

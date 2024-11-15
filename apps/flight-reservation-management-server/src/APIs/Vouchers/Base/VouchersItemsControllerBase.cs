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
    public async Task<ActionResult<Vouchers>> CreateVoucher(VoucherCreateInput input)
    {
        var vouchers = await _service.CreateVoucher(input);

        return CreatedAtAction(nameof(Vouchers), new { id = vouchers.Id }, vouchers);
    }

    /// <summary>
    /// Delete one Vouchers
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteVoucher([FromRoute()] VouchersWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteVoucher(uniqueId);
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
    public async Task<ActionResult> UpdateVoucher(
        [FromRoute()] VouchersWhereUniqueInput uniqueId,
        [FromQuery()] VoucherUpdateInput vouchersUpdateDto
    )
    {
        try
        {
            await _service.UpdateVoucher(uniqueId, vouchersUpdateDto);
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
    public async Task<ActionResult> UpdateFlightBookingsItem(
        [FromRoute()] VouchersWhereUniqueInput uniqueId,
        [FromBody()] FlightBookingsWhereUniqueInput[] flightBookingsItemsId
    )
    {
        try
        {
            await _service.UpdateFlightBookingsItem(uniqueId, flightBookingsItemsId);
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
    public async Task<ActionResult> UpdateHotelBookingsItem(
        [FromRoute()] VouchersWhereUniqueInput uniqueId,
        [FromBody()] HotelBookingsWhereUniqueInput[] hotelBookingsItemsId
    )
    {
        try
        {
            await _service.UpdateHotelBookingsItem(uniqueId, hotelBookingsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}

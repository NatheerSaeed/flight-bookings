using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class HotelDealsControllerBase : ControllerBase
{
    protected readonly IHotelDealsService _service;

    public HotelDealsControllerBase(IHotelDealsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one HotelDeals
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<HotelDeals>> CreateHotelDeal(HotelDealCreateInput input)
    {
        var hotelDeals = await _service.CreateHotelDeal(input);

        return CreatedAtAction(nameof(HotelDeals), new { id = hotelDeals.Id }, hotelDeals);
    }

    /// <summary>
    /// Delete one HotelDeals
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteHotelDeal(
        [FromRoute()] HotelDealsWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteHotelDeal(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many HotelDealsItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<HotelDeals>>> HotelDealsItems(
        [FromQuery()] HotelDealFindManyArgs filter
    )
    {
        return Ok(await _service.HotelDealsItems(filter));
    }

    /// <summary>
    /// Meta data about HotelDeals records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> HotelDealsItemsMeta(
        [FromQuery()] HotelDealFindManyArgs filter
    )
    {
        return Ok(await _service.HotelDealsItemsMeta(filter));
    }

    /// <summary>
    /// Get one HotelDeals
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<HotelDeals>> HotelDeals(
        [FromRoute()] HotelDealsWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.HotelDeals(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one HotelDeals
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateHotelDeal(
        [FromRoute()] HotelDealsWhereUniqueInput uniqueId,
        [FromQuery()] HotelDealUpdateInput hotelDealsUpdateDto
    )
    {
        try
        {
            await _service.UpdateHotelDeal(uniqueId, hotelDealsUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a package_ record for HotelDeals
    /// </summary>
    [HttpGet("{Id}/packageField")]
    public async Task<ActionResult<List<Packages>>> GetPackageField(
        [FromRoute()] HotelDealsWhereUniqueInput uniqueId
    )
    {
        var packages = await _service.GetPackageField(uniqueId);
        return Ok(packages);
    }
}

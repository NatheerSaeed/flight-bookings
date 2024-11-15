using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class HotelsControllerBase : ControllerBase
{
    protected readonly IHotelsService _service;

    public HotelsControllerBase(IHotelsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Hotels
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Hotels>> CreateHotel(HotelCreateInput input)
    {
        var hotels = await _service.CreateHotel(input);

        return CreatedAtAction(nameof(Hotels), new { id = hotels.Id }, hotels);
    }

    /// <summary>
    /// Delete one Hotels
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteHotel([FromRoute()] HotelsWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteHotel(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many HotelsItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Hotels>>> HotelsItems(
        [FromQuery()] HotelFindManyArgs filter
    )
    {
        return Ok(await _service.HotelsItems(filter));
    }

    /// <summary>
    /// Meta data about Hotels records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> HotelsItemsMeta(
        [FromQuery()] HotelFindManyArgs filter
    )
    {
        return Ok(await _service.HotelsItemsMeta(filter));
    }

    /// <summary>
    /// Get one Hotels
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Hotels>> Hotels([FromRoute()] HotelsWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Hotels(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Hotels
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateHotel(
        [FromRoute()] HotelsWhereUniqueInput uniqueId,
        [FromQuery()] HotelUpdateInput hotelsUpdateDto
    )
    {
        try
        {
            await _service.UpdateHotel(uniqueId, hotelsUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a role_ record for Hotels
    /// </summary>
    [HttpGet("{Id}/role")]
    public async Task<ActionResult<List<Roles>>> GetRole(
        [FromRoute()] HotelsWhereUniqueInput uniqueId
    )
    {
        var roles = await _service.GetRole(uniqueId);
        return Ok(roles);
    }
}

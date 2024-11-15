using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class AirportsItemsControllerBase : ControllerBase
{
    protected readonly IAirportsItemsService _service;

    public AirportsItemsControllerBase(IAirportsItemsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Airports
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Airports>> CreateAirports(AirportsCreateInput input)
    {
        var airports = await _service.CreateAirports(input);

        return CreatedAtAction(nameof(Airports), new { id = airports.Id }, airports);
    }

    /// <summary>
    /// Delete one Airports
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteAirports([FromRoute()] AirportsWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteAirports(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many AirportsItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Airports>>> AirportsItems(
        [FromQuery()] AirportsFindManyArgs filter
    )
    {
        return Ok(await _service.AirportsItems(filter));
    }

    /// <summary>
    /// Meta data about Airports records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> AirportsItemsMeta(
        [FromQuery()] AirportsFindManyArgs filter
    )
    {
        return Ok(await _service.AirportsItemsMeta(filter));
    }

    /// <summary>
    /// Get one Airports
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Airports>> Airports(
        [FromRoute()] AirportsWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Airports(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Airports
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateAirports(
        [FromRoute()] AirportsWhereUniqueInput uniqueId,
        [FromQuery()] AirportsUpdateInput airportsUpdateDto
    )
    {
        try
        {
            await _service.UpdateAirports(uniqueId, airportsUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}

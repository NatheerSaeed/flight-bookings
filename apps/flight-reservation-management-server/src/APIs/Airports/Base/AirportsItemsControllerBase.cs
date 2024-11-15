using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class AirportsControllerBase : ControllerBase
{
    protected readonly IAirportsService _service;

    public AirportsControllerBase(IAirportsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Airports
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Airports>> CreateAirport(AirportCreateInput input)
    {
        var airports = await _service.CreateAirport(input);

        return CreatedAtAction(nameof(Airports), new { id = airports.Id }, airports);
    }

    /// <summary>
    /// Delete one Airports
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteAirport([FromRoute()] AirportsWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteAirport(uniqueId);
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
    public async Task<ActionResult<List<Airports>>> AirportsSearchAsync(
        [FromQuery()] AirportFindManyArgs filter
    )
    {
        return Ok(await _service.AirportsSearchAsync(filter));
    }

    /// <summary>
    /// Meta data about Airports records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> AirportsItemsMeta(
        [FromQuery()] AirportFindManyArgs filter
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
    public async Task<ActionResult> UpdateAirport(
        [FromRoute()] AirportsWhereUniqueInput uniqueId,
        [FromQuery()] AirportUpdateInput airportsUpdateDto
    )
    {
        try
        {
            await _service.UpdateAirport(uniqueId, airportsUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}

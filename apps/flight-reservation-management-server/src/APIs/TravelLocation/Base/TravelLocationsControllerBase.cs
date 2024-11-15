using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class TravelLocationsControllerBase : ControllerBase
{
    protected readonly ITravelLocationsService _service;

    public TravelLocationsControllerBase(ITravelLocationsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one TravelLocation
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<TravelLocation>> CreateTravelLocation(
        TravelLocationCreateInput input
    )
    {
        var travelLocation = await _service.CreateTravelLocation(input);

        return CreatedAtAction(
            nameof(TravelLocation),
            new { id = travelLocation.Id },
            travelLocation
        );
    }

    /// <summary>
    /// Delete one TravelLocation
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteTravelLocation(
        [FromRoute()] TravelLocationWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteTravelLocation(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many TravelLocations
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<TravelLocation>>> TravelLocations(
        [FromQuery()] TravelLocationFindManyArgs filter
    )
    {
        return Ok(await _service.TravelLocations(filter));
    }

    /// <summary>
    /// Meta data about TravelLocation records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> TravelLocationsMeta(
        [FromQuery()] TravelLocationFindManyArgs filter
    )
    {
        return Ok(await _service.TravelLocationsMeta(filter));
    }

    /// <summary>
    /// Get one TravelLocation
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<TravelLocation>> TravelLocation(
        [FromRoute()] TravelLocationWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.TravelLocation(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one TravelLocation
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateTravelLocation(
        [FromRoute()] TravelLocationWhereUniqueInput uniqueId,
        [FromQuery()] TravelLocationUpdateInput travelLocationUpdateDto
    )
    {
        try
        {
            await _service.UpdateTravelLocation(uniqueId, travelLocationUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}

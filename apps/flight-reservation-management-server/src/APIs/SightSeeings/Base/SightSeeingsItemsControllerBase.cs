using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class SightSeeingsItemsControllerBase : ControllerBase
{
    protected readonly ISightSeeingsItemsService _service;

    public SightSeeingsItemsControllerBase(ISightSeeingsItemsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one SightSeeings
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<SightSeeings>> CreateSightSeeings(SightSeeingsCreateInput input)
    {
        var sightSeeings = await _service.CreateSightSeeings(input);

        return CreatedAtAction(nameof(SightSeeings), new { id = sightSeeings.Id }, sightSeeings);
    }

    /// <summary>
    /// Delete one SightSeeings
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteSightSeeings(
        [FromRoute()] SightSeeingsWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteSightSeeings(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many SightSeeingsItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<SightSeeings>>> SightSeeingsItems(
        [FromQuery()] SightSeeingsFindManyArgs filter
    )
    {
        return Ok(await _service.SightSeeingsItems(filter));
    }

    /// <summary>
    /// Meta data about SightSeeings records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> SightSeeingsItemsMeta(
        [FromQuery()] SightSeeingsFindManyArgs filter
    )
    {
        return Ok(await _service.SightSeeingsItemsMeta(filter));
    }

    /// <summary>
    /// Get one SightSeeings
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<SightSeeings>> SightSeeings(
        [FromRoute()] SightSeeingsWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.SightSeeings(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one SightSeeings
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateSightSeeings(
        [FromRoute()] SightSeeingsWhereUniqueInput uniqueId,
        [FromQuery()] SightSeeingsUpdateInput sightSeeingsUpdateDto
    )
    {
        try
        {
            await _service.UpdateSightSeeings(uniqueId, sightSeeingsUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a attraction_ record for SightSeeings
    /// </summary>
    [HttpGet("{Id}/attraction")]
    public async Task<ActionResult<List<Attractions>>> GetAttraction(
        [FromRoute()] SightSeeingsWhereUniqueInput uniqueId
    )
    {
        var attractions = await _service.GetAttraction(uniqueId);
        return Ok(attractions);
    }

    /// <summary>
    /// Get a package_ record for SightSeeings
    /// </summary>
    [HttpGet("{Id}/packageField")]
    public async Task<ActionResult<List<Packages>>> GetPackageField(
        [FromRoute()] SightSeeingsWhereUniqueInput uniqueId
    )
    {
        var packages = await _service.GetPackageField(uniqueId);
        return Ok(packages);
    }
}

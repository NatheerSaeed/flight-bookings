using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class AttractionsItemsControllerBase : ControllerBase
{
    protected readonly IAttractionsItemsService _service;

    public AttractionsItemsControllerBase(IAttractionsItemsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Attractions
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Attractions>> CreateAttractions(AttractionsCreateInput input)
    {
        var attractions = await _service.CreateAttractions(input);

        return CreatedAtAction(nameof(Attractions), new { id = attractions.Id }, attractions);
    }

    /// <summary>
    /// Delete one Attractions
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteAttractions(
        [FromRoute()] AttractionsWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteAttractions(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many AttractionsItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Attractions>>> AttractionsItems(
        [FromQuery()] AttractionsFindManyArgs filter
    )
    {
        return Ok(await _service.AttractionsItems(filter));
    }

    /// <summary>
    /// Meta data about Attractions records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> AttractionsItemsMeta(
        [FromQuery()] AttractionsFindManyArgs filter
    )
    {
        return Ok(await _service.AttractionsItemsMeta(filter));
    }

    /// <summary>
    /// Get one Attractions
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Attractions>> Attractions(
        [FromRoute()] AttractionsWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Attractions(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Attractions
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateAttractions(
        [FromRoute()] AttractionsWhereUniqueInput uniqueId,
        [FromQuery()] AttractionsUpdateInput attractionsUpdateDto
    )
    {
        try
        {
            await _service.UpdateAttractions(uniqueId, attractionsUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a package_ record for Attractions
    /// </summary>
    [HttpGet("{Id}/packageField")]
    public async Task<ActionResult<List<Packages>>> GetPackageField(
        [FromRoute()] AttractionsWhereUniqueInput uniqueId
    )
    {
        var packages = await _service.GetPackageField(uniqueId);
        return Ok(packages);
    }

    /// <summary>
    /// Connect multiple SightSeeingsItems records to Attractions
    /// </summary>
    [HttpPost("{Id}/sightSeeingsItems")]
    public async Task<ActionResult> ConnectSightSeeingsItems(
        [FromRoute()] AttractionsWhereUniqueInput uniqueId,
        [FromQuery()] SightSeeingsWhereUniqueInput[] sightSeeingsItemsId
    )
    {
        try
        {
            await _service.ConnectSightSeeingsItems(uniqueId, sightSeeingsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple SightSeeingsItems records from Attractions
    /// </summary>
    [HttpDelete("{Id}/sightSeeingsItems")]
    public async Task<ActionResult> DisconnectSightSeeingsItems(
        [FromRoute()] AttractionsWhereUniqueInput uniqueId,
        [FromBody()] SightSeeingsWhereUniqueInput[] sightSeeingsItemsId
    )
    {
        try
        {
            await _service.DisconnectSightSeeingsItems(uniqueId, sightSeeingsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple SightSeeingsItems records for Attractions
    /// </summary>
    [HttpGet("{Id}/sightSeeingsItems")]
    public async Task<ActionResult<List<SightSeeings>>> FindSightSeeingsItems(
        [FromRoute()] AttractionsWhereUniqueInput uniqueId,
        [FromQuery()] SightSeeingsFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindSightSeeingsItems(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple SightSeeingsItems records for Attractions
    /// </summary>
    [HttpPatch("{Id}/sightSeeingsItems")]
    public async Task<ActionResult> UpdateSightSeeingsItems(
        [FromRoute()] AttractionsWhereUniqueInput uniqueId,
        [FromBody()] SightSeeingsWhereUniqueInput[] sightSeeingsItemsId
    )
    {
        try
        {
            await _service.UpdateSightSeeingsItems(uniqueId, sightSeeingsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}

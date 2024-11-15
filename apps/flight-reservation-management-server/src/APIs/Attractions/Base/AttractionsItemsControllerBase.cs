using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class AttractionsControllerBase : ControllerBase
{
    protected readonly IAttractionsService _service;

    public AttractionsControllerBase(IAttractionsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Attractions
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Attractions>> CreateAttraction(AttractionCreateInput input)
    {
        var attractions = await _service.CreateAttraction(input);

        return CreatedAtAction(nameof(Attractions), new { id = attractions.Id }, attractions);
    }

    /// <summary>
    /// Delete one Attractions
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteAttraction(
        [FromRoute()] AttractionsWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteAttraction(uniqueId);
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
        [FromQuery()] AttractionFindManyArgs filter
    )
    {
        return Ok(await _service.AttractionsItems(filter));
    }

    /// <summary>
    /// Meta data about Attractions records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> AttractionsItemsMeta(
        [FromQuery()] AttractionFindManyArgs filter
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
    public async Task<ActionResult> UpdateAttraction(
        [FromRoute()] AttractionsWhereUniqueInput uniqueId,
        [FromQuery()] AttractionUpdateInput attractionsUpdateDto
    )
    {
        try
        {
            await _service.UpdateAttraction(uniqueId, attractionsUpdateDto);
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
        [FromQuery()] SightSeeingFindManyArgs filter
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
    public async Task<ActionResult> UpdateSightSeeingsItem(
        [FromRoute()] AttractionsWhereUniqueInput uniqueId,
        [FromBody()] SightSeeingsWhereUniqueInput[] sightSeeingsItemsId
    )
    {
        try
        {
            await _service.UpdateSightSeeingsItem(uniqueId, sightSeeingsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}

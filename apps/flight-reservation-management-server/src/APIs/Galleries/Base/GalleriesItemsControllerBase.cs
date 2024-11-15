using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class GalleriesItemsControllerBase : ControllerBase
{
    protected readonly IGalleriesItemsService _service;

    public GalleriesItemsControllerBase(IGalleriesItemsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Galleries
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Galleries>> CreateGalleries(GalleriesCreateInput input)
    {
        var galleries = await _service.CreateGalleries(input);

        return CreatedAtAction(nameof(Galleries), new { id = galleries.Id }, galleries);
    }

    /// <summary>
    /// Delete one Galleries
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteGalleries(
        [FromRoute()] GalleriesWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteGalleries(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many GalleriesItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Galleries>>> GalleriesItems(
        [FromQuery()] GalleriesFindManyArgs filter
    )
    {
        return Ok(await _service.GalleriesItems(filter));
    }

    /// <summary>
    /// Meta data about Galleries records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> GalleriesItemsMeta(
        [FromQuery()] GalleriesFindManyArgs filter
    )
    {
        return Ok(await _service.GalleriesItemsMeta(filter));
    }

    /// <summary>
    /// Get one Galleries
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Galleries>> Galleries(
        [FromRoute()] GalleriesWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Galleries(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Galleries
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateGalleries(
        [FromRoute()] GalleriesWhereUniqueInput uniqueId,
        [FromQuery()] GalleriesUpdateInput galleriesUpdateDto
    )
    {
        try
        {
            await _service.UpdateGalleries(uniqueId, galleriesUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a package_ record for Galleries
    /// </summary>
    [HttpGet("{Id}/packageField")]
    public async Task<ActionResult<List<Packages>>> GetPackageField(
        [FromRoute()] GalleriesWhereUniqueInput uniqueId
    )
    {
        var packages = await _service.GetPackageField(uniqueId);
        return Ok(packages);
    }
}

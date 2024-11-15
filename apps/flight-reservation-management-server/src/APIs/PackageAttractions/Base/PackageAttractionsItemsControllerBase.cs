using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class PackageAttractionsControllerBase : ControllerBase
{
    protected readonly IPackageAttractionsService _service;

    public PackageAttractionsControllerBase(IPackageAttractionsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one PackageAttractions
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<PackageAttractions>> CreatePackageAttractions(
        PackageAttractionCreateInput input
    )
    {
        var packageAttractions = await _service.CreatePackageAttractions(input);

        return CreatedAtAction(
            nameof(PackageAttractions),
            new { id = packageAttractions.Id },
            packageAttractions
        );
    }

    /// <summary>
    /// Delete one PackageAttractions
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeletePackageAttractions(
        [FromRoute()] PackageAttractionsWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeletePackageAttractions(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many PackageAttractionsItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<PackageAttractions>>> PackageAttractionsItems(
        [FromQuery()] PackageAttractionFindManyArgs filter
    )
    {
        return Ok(await _service.PackageAttractionsItems(filter));
    }

    /// <summary>
    /// Meta data about PackageAttractions records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> PackageAttractionsItemsMeta(
        [FromQuery()] PackageAttractionFindManyArgs filter
    )
    {
        return Ok(await _service.PackageAttractionsItemsMeta(filter));
    }

    /// <summary>
    /// Get one PackageAttractions
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<PackageAttractions>> PackageAttractions(
        [FromRoute()] PackageAttractionsWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.PackageAttractions(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one PackageAttractions
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdatePackageAttractions(
        [FromRoute()] PackageAttractionsWhereUniqueInput uniqueId,
        [FromQuery()] PackageAttractionUpdateInput packageAttractionsUpdateDto
    )
    {
        try
        {
            await _service.UpdatePackageAttractions(uniqueId, packageAttractionsUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a package_ record for PackageAttractions
    /// </summary>
    [HttpGet("{Id}/packageField")]
    public async Task<ActionResult<List<Packages>>> GetPackageField(
        [FromRoute()] PackageAttractionsWhereUniqueInput uniqueId
    )
    {
        var packages = await _service.GetPackageField(uniqueId);
        return Ok(packages);
    }
}

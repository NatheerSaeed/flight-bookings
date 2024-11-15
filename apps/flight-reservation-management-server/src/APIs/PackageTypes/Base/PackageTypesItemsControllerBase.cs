using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class PackageTypesItemsControllerBase : ControllerBase
{
    protected readonly IPackageTypesItemsService _service;

    public PackageTypesItemsControllerBase(IPackageTypesItemsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one PackageTypes
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<PackageTypes>> CreatePackageTypes(PackageTypesCreateInput input)
    {
        var packageTypes = await _service.CreatePackageTypes(input);

        return CreatedAtAction(nameof(PackageTypes), new { id = packageTypes.Id }, packageTypes);
    }

    /// <summary>
    /// Delete one PackageTypes
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeletePackageTypes(
        [FromRoute()] PackageTypesWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeletePackageTypes(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many PackageTypesItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<PackageTypes>>> PackageTypesItems(
        [FromQuery()] PackageTypesFindManyArgs filter
    )
    {
        return Ok(await _service.PackageTypesItems(filter));
    }

    /// <summary>
    /// Meta data about PackageTypes records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> PackageTypesItemsMeta(
        [FromQuery()] PackageTypesFindManyArgs filter
    )
    {
        return Ok(await _service.PackageTypesItemsMeta(filter));
    }

    /// <summary>
    /// Get one PackageTypes
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<PackageTypes>> PackageTypes(
        [FromRoute()] PackageTypesWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.PackageTypes(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one PackageTypes
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdatePackageTypes(
        [FromRoute()] PackageTypesWhereUniqueInput uniqueId,
        [FromQuery()] PackageTypesUpdateInput packageTypesUpdateDto
    )
    {
        try
        {
            await _service.UpdatePackageTypes(uniqueId, packageTypesUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}

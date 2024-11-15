using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class PackageTypesControllerBase : ControllerBase
{
    protected readonly IPackageTypesService _service;

    public PackageTypesControllerBase(IPackageTypesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one PackageTypes
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<PackageTypes>> CreatePackageType(PackageTypeCreateInput input)
    {
        var packageTypes = await _service.CreatePackageType(input);

        return CreatedAtAction(nameof(PackageTypes), new { id = packageTypes.Id }, packageTypes);
    }

    /// <summary>
    /// Delete one PackageTypes
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeletePackageType(
        [FromRoute()] PackageTypesWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeletePackageType(uniqueId);
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
        [FromQuery()] PackageTypeFindManyArgs filter
    )
    {
        return Ok(await _service.PackageTypesItems(filter));
    }

    /// <summary>
    /// Meta data about PackageTypes records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> PackageTypesItemsMeta(
        [FromQuery()] PackageTypeFindManyArgs filter
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
    public async Task<ActionResult> UpdatePackageType(
        [FromRoute()] PackageTypesWhereUniqueInput uniqueId,
        [FromQuery()] PackageTypeUpdateInput packageTypesUpdateDto
    )
    {
        try
        {
            await _service.UpdatePackageType(uniqueId, packageTypesUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}

using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class PackageCategoriesItemsControllerBase : ControllerBase
{
    protected readonly IPackageCategoriesItemsService _service;

    public PackageCategoriesItemsControllerBase(IPackageCategoriesItemsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one PackageCategories
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<PackageCategories>> CreatePackageCategories(
        PackageCategoriesCreateInput input
    )
    {
        var packageCategories = await _service.CreatePackageCategories(input);

        return CreatedAtAction(
            nameof(PackageCategories),
            new { id = packageCategories.Id },
            packageCategories
        );
    }

    /// <summary>
    /// Delete one PackageCategories
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeletePackageCategories(
        [FromRoute()] PackageCategoriesWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeletePackageCategories(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many PackageCategoriesItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<PackageCategories>>> PackageCategoriesItems(
        [FromQuery()] PackageCategoriesFindManyArgs filter
    )
    {
        return Ok(await _service.PackageCategoriesItems(filter));
    }

    /// <summary>
    /// Meta data about PackageCategories records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> PackageCategoriesItemsMeta(
        [FromQuery()] PackageCategoriesFindManyArgs filter
    )
    {
        return Ok(await _service.PackageCategoriesItemsMeta(filter));
    }

    /// <summary>
    /// Get one PackageCategories
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<PackageCategories>> PackageCategories(
        [FromRoute()] PackageCategoriesWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.PackageCategories(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one PackageCategories
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdatePackageCategories(
        [FromRoute()] PackageCategoriesWhereUniqueInput uniqueId,
        [FromQuery()] PackageCategoriesUpdateInput packageCategoriesUpdateDto
    )
    {
        try
        {
            await _service.UpdatePackageCategories(uniqueId, packageCategoriesUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}

using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class PackageCategoriesControllerBase : ControllerBase
{
    protected readonly IPackageCategoriesService _service;

    public PackageCategoriesControllerBase(IPackageCategoriesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one PackageCategories
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<PackageCategories>> CreatePackageCategorie(
        PackageCategorieCreateInput input
    )
    {
        var packageCategories = await _service.CreatePackageCategorie(input);

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
    public async Task<ActionResult> DeletePackageCategorie(
        [FromRoute()] PackageCategoriesWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeletePackageCategorie(uniqueId);
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
        [FromQuery()] PackageCategorieFindManyArgs filter
    )
    {
        return Ok(await _service.PackageCategoriesItems(filter));
    }

    /// <summary>
    /// Meta data about PackageCategories records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> PackageCategoriesItemsMeta(
        [FromQuery()] PackageCategorieFindManyArgs filter
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
    public async Task<ActionResult> UpdatePackageCategorie(
        [FromRoute()] PackageCategoriesWhereUniqueInput uniqueId,
        [FromQuery()] PackageCategorieUpdateInput packageCategoriesUpdateDto
    )
    {
        try
        {
            await _service.UpdatePackageCategorie(uniqueId, packageCategoriesUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}

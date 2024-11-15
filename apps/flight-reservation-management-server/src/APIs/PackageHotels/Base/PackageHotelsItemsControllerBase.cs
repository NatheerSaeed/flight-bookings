using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class PackageHotelsItemsControllerBase : ControllerBase
{
    protected readonly IPackageHotelsItemsService _service;

    public PackageHotelsItemsControllerBase(IPackageHotelsItemsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one PackageHotels
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<PackageHotels>> CreatePackageHotels(
        PackageHotelsCreateInput input
    )
    {
        var packageHotels = await _service.CreatePackageHotels(input);

        return CreatedAtAction(nameof(PackageHotels), new { id = packageHotels.Id }, packageHotels);
    }

    /// <summary>
    /// Delete one PackageHotels
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeletePackageHotels(
        [FromRoute()] PackageHotelsWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeletePackageHotels(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many PackageHotelsItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<PackageHotels>>> PackageHotelsItems(
        [FromQuery()] PackageHotelsFindManyArgs filter
    )
    {
        return Ok(await _service.PackageHotelsItems(filter));
    }

    /// <summary>
    /// Meta data about PackageHotels records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> PackageHotelsItemsMeta(
        [FromQuery()] PackageHotelsFindManyArgs filter
    )
    {
        return Ok(await _service.PackageHotelsItemsMeta(filter));
    }

    /// <summary>
    /// Get one PackageHotels
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<PackageHotels>> PackageHotels(
        [FromRoute()] PackageHotelsWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.PackageHotels(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one PackageHotels
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdatePackageHotels(
        [FromRoute()] PackageHotelsWhereUniqueInput uniqueId,
        [FromQuery()] PackageHotelsUpdateInput packageHotelsUpdateDto
    )
    {
        try
        {
            await _service.UpdatePackageHotels(uniqueId, packageHotelsUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a package_ record for PackageHotels
    /// </summary>
    [HttpGet("{Id}/packageField")]
    public async Task<ActionResult<List<Packages>>> GetPackageField(
        [FromRoute()] PackageHotelsWhereUniqueInput uniqueId
    )
    {
        var packages = await _service.GetPackageField(uniqueId);
        return Ok(packages);
    }
}

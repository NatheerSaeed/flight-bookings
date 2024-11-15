using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class PackageBookingsItemsControllerBase : ControllerBase
{
    protected readonly IPackageBookingsItemsService _service;

    public PackageBookingsItemsControllerBase(IPackageBookingsItemsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one PackageBookings
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<PackageBookings>> CreatePackageBookings(
        PackageBookingsCreateInput input
    )
    {
        var packageBookings = await _service.CreatePackageBookings(input);

        return CreatedAtAction(
            nameof(PackageBookings),
            new { id = packageBookings.Id },
            packageBookings
        );
    }

    /// <summary>
    /// Delete one PackageBookings
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeletePackageBookings(
        [FromRoute()] PackageBookingsWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeletePackageBookings(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many PackageBookingsItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<PackageBookings>>> PackageBookingsItems(
        [FromQuery()] PackageBookingsFindManyArgs filter
    )
    {
        return Ok(await _service.PackageBookingsItems(filter));
    }

    /// <summary>
    /// Meta data about PackageBookings records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> PackageBookingsItemsMeta(
        [FromQuery()] PackageBookingsFindManyArgs filter
    )
    {
        return Ok(await _service.PackageBookingsItemsMeta(filter));
    }

    /// <summary>
    /// Get one PackageBookings
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<PackageBookings>> PackageBookings(
        [FromRoute()] PackageBookingsWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.PackageBookings(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one PackageBookings
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdatePackageBookings(
        [FromRoute()] PackageBookingsWhereUniqueInput uniqueId,
        [FromQuery()] PackageBookingsUpdateInput packageBookingsUpdateDto
    )
    {
        try
        {
            await _service.UpdatePackageBookings(uniqueId, packageBookingsUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a package_ record for PackageBookings
    /// </summary>
    [HttpGet("{Id}/packageField")]
    public async Task<ActionResult<List<Packages>>> GetPackageField(
        [FromRoute()] PackageBookingsWhereUniqueInput uniqueId
    )
    {
        var packages = await _service.GetPackageField(uniqueId);
        return Ok(packages);
    }

    /// <summary>
    /// Get a user_ record for PackageBookings
    /// </summary>
    [HttpGet("{Id}/user")]
    public async Task<ActionResult<List<User>>> GetUser(
        [FromRoute()] PackageBookingsWhereUniqueInput uniqueId
    )
    {
        var user = await _service.GetUser(uniqueId);
        return Ok(user);
    }
}

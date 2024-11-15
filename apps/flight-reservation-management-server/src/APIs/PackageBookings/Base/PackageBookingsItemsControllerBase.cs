using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class PackageBookingsControllerBase : ControllerBase
{
    protected readonly IPackageBookingsService _service;

    public PackageBookingsControllerBase(IPackageBookingsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one PackageBookings
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<PackageBookings>> CreatePackageBooking(
        PackageBookingCreateInput input
    )
    {
        var packageBookings = await _service.CreatePackageBooking(input);

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
    public async Task<ActionResult> DeletePackageBooking(
        [FromRoute()] PackageBookingsWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeletePackageBooking(uniqueId);
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
    public async Task<ActionResult<List<PackageBookings>>> PackageBookingsSearchAsync(
        [FromQuery()] PackageBookingFindManyArgs filter
    )
    {
        return Ok(await _service.PackageBookingsSearchAsync(filter));
    }

    /// <summary>
    /// Meta data about PackageBookings records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> PackageBookingsItemsMeta(
        [FromQuery()] PackageBookingFindManyArgs filter
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
    public async Task<ActionResult> UpdatePackageBooking(
        [FromRoute()] PackageBookingsWhereUniqueInput uniqueId,
        [FromQuery()] PackageBookingUpdateInput packageBookingsUpdateDto
    )
    {
        try
        {
            await _service.UpdatePackageBooking(uniqueId, packageBookingsUpdateDto);
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

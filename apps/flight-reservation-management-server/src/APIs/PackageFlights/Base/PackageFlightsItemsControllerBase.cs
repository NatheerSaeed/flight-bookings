using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class PackageFlightsControllerBase : ControllerBase
{
    protected readonly IPackageFlightsService _service;

    public PackageFlightsControllerBase(IPackageFlightsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one PackageFlights
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<PackageFlights>> CreatePackageFlights(
        PackageFlightCreateInput input
    )
    {
        var packageFlights = await _service.CreatePackageFlights(input);

        return CreatedAtAction(
            nameof(PackageFlights),
            new { id = packageFlights.Id },
            packageFlights
        );
    }

    /// <summary>
    /// Delete one PackageFlights
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeletePackageFlights(
        [FromRoute()] PackageFlightsWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeletePackageFlights(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many PackageFlightsItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<PackageFlights>>> PackageFlightsItems(
        [FromQuery()] PackageFlightFindManyArgs filter
    )
    {
        return Ok(await _service.PackageFlightsItems(filter));
    }

    /// <summary>
    /// Meta data about PackageFlights records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> PackageFlightsItemsMeta(
        [FromQuery()] PackageFlightFindManyArgs filter
    )
    {
        return Ok(await _service.PackageFlightsItemsMeta(filter));
    }

    /// <summary>
    /// Get one PackageFlights
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<PackageFlights>> PackageFlights(
        [FromRoute()] PackageFlightsWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.PackageFlights(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one PackageFlights
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdatePackageFlights(
        [FromRoute()] PackageFlightsWhereUniqueInput uniqueId,
        [FromQuery()] PackageFlightUpdateInput packageFlightsUpdateDto
    )
    {
        try
        {
            await _service.UpdatePackageFlights(uniqueId, packageFlightsUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a package_ record for PackageFlights
    /// </summary>
    [HttpGet("{Id}/packageField")]
    public async Task<ActionResult<List<Packages>>> GetPackageField(
        [FromRoute()] PackageFlightsWhereUniqueInput uniqueId
    )
    {
        var packages = await _service.GetPackageField(uniqueId);
        return Ok(packages);
    }
}

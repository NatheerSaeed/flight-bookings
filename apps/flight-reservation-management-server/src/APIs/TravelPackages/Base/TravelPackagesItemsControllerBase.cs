using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class TravelPackagesControllerBase : ControllerBase
{
    protected readonly ITravelPackagesService _service;

    public TravelPackagesControllerBase(ITravelPackagesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one TravelPackages
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<TravelPackages>> CreateTravelPackage(
        TravelPackageCreateInput input
    )
    {
        var travelPackages = await _service.CreateTravelPackage(input);

        return CreatedAtAction(
            nameof(TravelPackages),
            new { id = travelPackages.Id },
            travelPackages
        );
    }

    /// <summary>
    /// Delete one TravelPackages
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteTravelPackage(
        [FromRoute()] TravelPackagesWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteTravelPackage(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many TravelPackagesItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<TravelPackages>>> TravelPackagesItems(
        [FromQuery()] TravelPackageFindManyArgs filter
    )
    {
        return Ok(await _service.TravelPackagesItems(filter));
    }

    /// <summary>
    /// Meta data about TravelPackages records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> TravelPackagesItemsMeta(
        [FromQuery()] TravelPackageFindManyArgs filter
    )
    {
        return Ok(await _service.TravelPackagesItemsMeta(filter));
    }

    /// <summary>
    /// Get one TravelPackages
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<TravelPackages>> TravelPackages(
        [FromRoute()] TravelPackagesWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.TravelPackages(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one TravelPackages
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateTravelPackage(
        [FromRoute()] TravelPackagesWhereUniqueInput uniqueId,
        [FromQuery()] TravelPackageUpdateInput travelPackagesUpdateDto
    )
    {
        try
        {
            await _service.UpdateTravelPackage(uniqueId, travelPackagesUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}

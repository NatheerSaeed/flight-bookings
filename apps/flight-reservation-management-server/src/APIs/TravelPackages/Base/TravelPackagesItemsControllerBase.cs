using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class TravelPackagesItemsControllerBase : ControllerBase
{
    protected readonly ITravelPackagesItemsService _service;

    public TravelPackagesItemsControllerBase(ITravelPackagesItemsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one TravelPackages
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<TravelPackages>> CreateTravelPackages(
        TravelPackagesCreateInput input
    )
    {
        var travelPackages = await _service.CreateTravelPackages(input);

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
    public async Task<ActionResult> DeleteTravelPackages(
        [FromRoute()] TravelPackagesWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteTravelPackages(uniqueId);
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
        [FromQuery()] TravelPackagesFindManyArgs filter
    )
    {
        return Ok(await _service.TravelPackagesItems(filter));
    }

    /// <summary>
    /// Meta data about TravelPackages records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> TravelPackagesItemsMeta(
        [FromQuery()] TravelPackagesFindManyArgs filter
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
    public async Task<ActionResult> UpdateTravelPackages(
        [FromRoute()] TravelPackagesWhereUniqueInput uniqueId,
        [FromQuery()] TravelPackagesUpdateInput travelPackagesUpdateDto
    )
    {
        try
        {
            await _service.UpdateTravelPackages(uniqueId, travelPackagesUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}

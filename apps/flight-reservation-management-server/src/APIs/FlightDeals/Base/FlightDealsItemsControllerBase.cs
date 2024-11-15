using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class FlightDealsControllerBase : ControllerBase
{
    protected readonly IFlightDealsService _service;

    public FlightDealsControllerBase(IFlightDealsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one FlightDeals
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<FlightDeals>> CreateFlightDeal(FlightDealCreateInput input)
    {
        var flightDeals = await _service.CreateFlightDeal(input);

        return CreatedAtAction(nameof(FlightDeals), new { id = flightDeals.Id }, flightDeals);
    }

    /// <summary>
    /// Delete one FlightDeals
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteFlightDeal(
        [FromRoute()] FlightDealsWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteFlightDeal(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many FlightDealsItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<FlightDeals>>> FlightDealsItems(
        [FromQuery()] FlightDealFindManyArgs filter
    )
    {
        return Ok(await _service.FlightDealsItems(filter));
    }

    /// <summary>
    /// Meta data about FlightDeals records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> FlightDealsItemsMeta(
        [FromQuery()] FlightDealFindManyArgs filter
    )
    {
        return Ok(await _service.FlightDealsItemsMeta(filter));
    }

    /// <summary>
    /// Get one FlightDeals
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<FlightDeals>> FlightDeals(
        [FromRoute()] FlightDealsWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.FlightDeals(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one FlightDeals
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateFlightDeal(
        [FromRoute()] FlightDealsWhereUniqueInput uniqueId,
        [FromQuery()] FlightDealUpdateInput flightDealsUpdateDto
    )
    {
        try
        {
            await _service.UpdateFlightDeal(uniqueId, flightDealsUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a package_ record for FlightDeals
    /// </summary>
    [HttpGet("{Id}/packageField")]
    public async Task<ActionResult<List<Packages>>> GetPackageField(
        [FromRoute()] FlightDealsWhereUniqueInput uniqueId
    )
    {
        var packages = await _service.GetPackageField(uniqueId);
        return Ok(packages);
    }
}

using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class FlightDealsItemsControllerBase : ControllerBase
{
    protected readonly IFlightDealsItemsService _service;

    public FlightDealsItemsControllerBase(IFlightDealsItemsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one FlightDeals
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<FlightDeals>> CreateFlightDeals(FlightDealsCreateInput input)
    {
        var flightDeals = await _service.CreateFlightDeals(input);

        return CreatedAtAction(nameof(FlightDeals), new { id = flightDeals.Id }, flightDeals);
    }

    /// <summary>
    /// Delete one FlightDeals
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteFlightDeals(
        [FromRoute()] FlightDealsWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteFlightDeals(uniqueId);
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
        [FromQuery()] FlightDealsFindManyArgs filter
    )
    {
        return Ok(await _service.FlightDealsItems(filter));
    }

    /// <summary>
    /// Meta data about FlightDeals records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> FlightDealsItemsMeta(
        [FromQuery()] FlightDealsFindManyArgs filter
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
    public async Task<ActionResult> UpdateFlightDeals(
        [FromRoute()] FlightDealsWhereUniqueInput uniqueId,
        [FromQuery()] FlightDealsUpdateInput flightDealsUpdateDto
    )
    {
        try
        {
            await _service.UpdateFlightDeals(uniqueId, flightDealsUpdateDto);
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

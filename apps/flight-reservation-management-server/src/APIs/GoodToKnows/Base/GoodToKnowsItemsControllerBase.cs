using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class GoodToKnowsItemsControllerBase : ControllerBase
{
    protected readonly IGoodToKnowsItemsService _service;

    public GoodToKnowsItemsControllerBase(IGoodToKnowsItemsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one GoodToKnows
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<GoodToKnows>> CreateGoodToKnows(GoodToKnowsCreateInput input)
    {
        var goodToKnows = await _service.CreateGoodToKnows(input);

        return CreatedAtAction(nameof(GoodToKnows), new { id = goodToKnows.Id }, goodToKnows);
    }

    /// <summary>
    /// Delete one GoodToKnows
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteGoodToKnows(
        [FromRoute()] GoodToKnowsWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteGoodToKnows(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many GoodToKnowsItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<GoodToKnows>>> GoodToKnowsItems(
        [FromQuery()] GoodToKnowsFindManyArgs filter
    )
    {
        return Ok(await _service.GoodToKnowsItems(filter));
    }

    /// <summary>
    /// Meta data about GoodToKnows records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> GoodToKnowsItemsMeta(
        [FromQuery()] GoodToKnowsFindManyArgs filter
    )
    {
        return Ok(await _service.GoodToKnowsItemsMeta(filter));
    }

    /// <summary>
    /// Get one GoodToKnows
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<GoodToKnows>> GoodToKnows(
        [FromRoute()] GoodToKnowsWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.GoodToKnows(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one GoodToKnows
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateGoodToKnows(
        [FromRoute()] GoodToKnowsWhereUniqueInput uniqueId,
        [FromQuery()] GoodToKnowsUpdateInput goodToKnowsUpdateDto
    )
    {
        try
        {
            await _service.UpdateGoodToKnows(uniqueId, goodToKnowsUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a package_ record for GoodToKnows
    /// </summary>
    [HttpGet("{Id}/packageField")]
    public async Task<ActionResult<List<Packages>>> GetPackageField(
        [FromRoute()] GoodToKnowsWhereUniqueInput uniqueId
    )
    {
        var packages = await _service.GetPackageField(uniqueId);
        return Ok(packages);
    }
}

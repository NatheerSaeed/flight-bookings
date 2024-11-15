using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class GoodToKnowsControllerBase : ControllerBase
{
    protected readonly IGoodToKnowsService _service;

    public GoodToKnowsControllerBase(IGoodToKnowsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one GoodToKnows
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<GoodToKnows>> CreateGoodToKnow(GoodToKnowCreateInput input)
    {
        var goodToKnows = await _service.CreateGoodToKnow(input);

        return CreatedAtAction(nameof(GoodToKnows), new { id = goodToKnows.Id }, goodToKnows);
    }

    /// <summary>
    /// Delete one GoodToKnows
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteGoodToKnow(
        [FromRoute()] GoodToKnowsWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteGoodToKnow(uniqueId);
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
        [FromQuery()] GoodToKnowFindManyArgs filter
    )
    {
        return Ok(await _service.GoodToKnowsItems(filter));
    }

    /// <summary>
    /// Meta data about GoodToKnows records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> GoodToKnowsItemsMeta(
        [FromQuery()] GoodToKnowFindManyArgs filter
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
    public async Task<ActionResult> UpdateGoodToKnow(
        [FromRoute()] GoodToKnowsWhereUniqueInput uniqueId,
        [FromQuery()] GoodToKnowUpdateInput goodToKnowsUpdateDto
    )
    {
        try
        {
            await _service.UpdateGoodToKnow(uniqueId, goodToKnowsUpdateDto);
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

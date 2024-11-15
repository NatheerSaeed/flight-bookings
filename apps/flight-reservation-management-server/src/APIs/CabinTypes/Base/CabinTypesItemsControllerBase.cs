using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class CabinTypesItemsControllerBase : ControllerBase
{
    protected readonly ICabinTypesItemsService _service;

    public CabinTypesItemsControllerBase(ICabinTypesItemsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one CabinTypes
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<CabinTypes>> CreateCabinTypes(CabinTypesCreateInput input)
    {
        var cabinTypes = await _service.CreateCabinTypes(input);

        return CreatedAtAction(nameof(CabinTypes), new { id = cabinTypes.Id }, cabinTypes);
    }

    /// <summary>
    /// Delete one CabinTypes
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteCabinTypes(
        [FromRoute()] CabinTypesWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteCabinTypes(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many CabinTypesItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<CabinTypes>>> CabinTypesItems(
        [FromQuery()] CabinTypesFindManyArgs filter
    )
    {
        return Ok(await _service.CabinTypesItems(filter));
    }

    /// <summary>
    /// Meta data about CabinTypes records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> CabinTypesItemsMeta(
        [FromQuery()] CabinTypesFindManyArgs filter
    )
    {
        return Ok(await _service.CabinTypesItemsMeta(filter));
    }

    /// <summary>
    /// Get one CabinTypes
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<CabinTypes>> CabinTypes(
        [FromRoute()] CabinTypesWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.CabinTypes(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one CabinTypes
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateCabinTypes(
        [FromRoute()] CabinTypesWhereUniqueInput uniqueId,
        [FromQuery()] CabinTypesUpdateInput cabinTypesUpdateDto
    )
    {
        try
        {
            await _service.UpdateCabinTypes(uniqueId, cabinTypesUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}

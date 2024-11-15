using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class CabinTypesControllerBase : ControllerBase
{
    protected readonly ICabinTypesService _service;

    public CabinTypesControllerBase(ICabinTypesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one CabinTypes
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<CabinTypes>> CreateCabinType(CabinTypeCreateInput input)
    {
        var cabinTypes = await _service.CreateCabinType(input);

        return CreatedAtAction(nameof(CabinTypes), new { id = cabinTypes.Id }, cabinTypes);
    }

    /// <summary>
    /// Delete one CabinTypes
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteCabinType(
        [FromRoute()] CabinTypesWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteCabinType(uniqueId);
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
    public async Task<ActionResult<List<CabinTypes>>> CabinTypesSearchAsync(
        [FromQuery()] CabinTypeFindManyArgs filter
    )
    {
        return Ok(await _service.CabinTypesSearchAsync(filter));
    }

    /// <summary>
    /// Meta data about CabinTypes records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> CabinTypesItemsMeta(
        [FromQuery()] CabinTypeFindManyArgs filter
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
    public async Task<ActionResult> UpdateCabinType(
        [FromRoute()] CabinTypesWhereUniqueInput uniqueId,
        [FromQuery()] CabinTypeUpdateInput cabinTypesUpdateDto
    )
    {
        try
        {
            await _service.UpdateCabinType(uniqueId, cabinTypesUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}

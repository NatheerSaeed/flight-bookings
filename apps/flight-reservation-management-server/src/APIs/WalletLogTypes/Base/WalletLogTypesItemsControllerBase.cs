using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class WalletLogTypesControllerBase : ControllerBase
{
    protected readonly IWalletLogTypesService _service;

    public WalletLogTypesControllerBase(IWalletLogTypesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one WalletLogTypes
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<WalletLogTypes>> CreateWalletLogType(
        WalletLogTypeCreateInput input
    )
    {
        var walletLogTypes = await _service.CreateWalletLogType(input);

        return CreatedAtAction(
            nameof(WalletLogTypes),
            new { id = walletLogTypes.Id },
            walletLogTypes
        );
    }

    /// <summary>
    /// Delete one WalletLogTypes
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteWalletLogType(
        [FromRoute()] WalletLogTypesWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteWalletLogType(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many WalletLogTypesItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<WalletLogTypes>>> WalletLogTypesSearchAsync(
        [FromQuery()] WalletLogTypeFindManyArgs filter
    )
    {
        return Ok(await _service.WalletLogTypesSearchAsync(filter));
    }

    /// <summary>
    /// Meta data about WalletLogTypes records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> WalletLogTypesItemsMeta(
        [FromQuery()] WalletLogTypeFindManyArgs filter
    )
    {
        return Ok(await _service.WalletLogTypesItemsMeta(filter));
    }

    /// <summary>
    /// Get one WalletLogTypes
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<WalletLogTypes>> WalletLogTypes(
        [FromRoute()] WalletLogTypesWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.WalletLogTypes(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one WalletLogTypes
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateWalletLogType(
        [FromRoute()] WalletLogTypesWhereUniqueInput uniqueId,
        [FromQuery()] WalletLogTypeUpdateInput walletLogTypesUpdateDto
    )
    {
        try
        {
            await _service.UpdateWalletLogType(uniqueId, walletLogTypesUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}

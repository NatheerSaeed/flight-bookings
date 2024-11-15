using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class WalletLogTypesItemsControllerBase : ControllerBase
{
    protected readonly IWalletLogTypesItemsService _service;

    public WalletLogTypesItemsControllerBase(IWalletLogTypesItemsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one WalletLogTypes
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<WalletLogTypes>> CreateWalletLogTypes(
        WalletLogTypesCreateInput input
    )
    {
        var walletLogTypes = await _service.CreateWalletLogTypes(input);

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
    public async Task<ActionResult> DeleteWalletLogTypes(
        [FromRoute()] WalletLogTypesWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteWalletLogTypes(uniqueId);
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
    public async Task<ActionResult<List<WalletLogTypes>>> WalletLogTypesItems(
        [FromQuery()] WalletLogTypesFindManyArgs filter
    )
    {
        return Ok(await _service.WalletLogTypesItems(filter));
    }

    /// <summary>
    /// Meta data about WalletLogTypes records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> WalletLogTypesItemsMeta(
        [FromQuery()] WalletLogTypesFindManyArgs filter
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
    public async Task<ActionResult> UpdateWalletLogTypes(
        [FromRoute()] WalletLogTypesWhereUniqueInput uniqueId,
        [FromQuery()] WalletLogTypesUpdateInput walletLogTypesUpdateDto
    )
    {
        try
        {
            await _service.UpdateWalletLogTypes(uniqueId, walletLogTypesUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}

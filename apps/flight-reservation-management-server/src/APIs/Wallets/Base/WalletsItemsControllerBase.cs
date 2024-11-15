using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class WalletsControllerBase : ControllerBase
{
    protected readonly IWalletsService _service;

    public WalletsControllerBase(IWalletsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Wallets
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Wallets>> CreateWallet(WalletCreateInput input)
    {
        var wallets = await _service.CreateWallet(input);

        return CreatedAtAction(nameof(Wallets), new { id = wallets.Id }, wallets);
    }

    /// <summary>
    /// Delete one Wallets
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteWallet([FromRoute()] WalletsWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteWallet(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many WalletsItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Wallets>>> WalletsSearchAsync(
        [FromQuery()] WalletFindManyArgs filter
    )
    {
        return Ok(await _service.WalletsSearchAsync(filter));
    }

    /// <summary>
    /// Meta data about Wallets records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> WalletsItemsMeta(
        [FromQuery()] WalletFindManyArgs filter
    )
    {
        return Ok(await _service.WalletsItemsMeta(filter));
    }

    /// <summary>
    /// Get one Wallets
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Wallets>> Wallets([FromRoute()] WalletsWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Wallets(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Wallets
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateWallet(
        [FromRoute()] WalletsWhereUniqueInput uniqueId,
        [FromQuery()] WalletUpdateInput walletsUpdateDto
    )
    {
        try
        {
            await _service.UpdateWallet(uniqueId, walletsUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a user_ record for Wallets
    /// </summary>
    [HttpGet("{Id}/user")]
    public async Task<ActionResult<List<User>>> GetUser(
        [FromRoute()] WalletsWhereUniqueInput uniqueId
    )
    {
        var user = await _service.GetUser(uniqueId);
        return Ok(user);
    }
}

using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class WalletLogsControllerBase : ControllerBase
{
    protected readonly IWalletLogsService _service;

    public WalletLogsControllerBase(IWalletLogsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one WalletLogs
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<WalletLogs>> CreateWalletLog(WalletLogCreateInput input)
    {
        var walletLogs = await _service.CreateWalletLog(input);

        return CreatedAtAction(nameof(WalletLogs), new { id = walletLogs.Id }, walletLogs);
    }

    /// <summary>
    /// Delete one WalletLogs
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteWalletLog(
        [FromRoute()] WalletLogsWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteWalletLog(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many WalletLogsItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<WalletLogs>>> WalletLogsSearchAsync(
        [FromQuery()] WalletLogFindManyArgs filter
    )
    {
        return Ok(await _service.WalletLogsSearchAsync(filter));
    }

    /// <summary>
    /// Meta data about WalletLogs records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> WalletLogsItemsMeta(
        [FromQuery()] WalletLogFindManyArgs filter
    )
    {
        return Ok(await _service.WalletLogsItemsMeta(filter));
    }

    /// <summary>
    /// Get one WalletLogs
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<WalletLogs>> WalletLogs(
        [FromRoute()] WalletLogsWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.WalletLogs(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one WalletLogs
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateWalletLog(
        [FromRoute()] WalletLogsWhereUniqueInput uniqueId,
        [FromQuery()] WalletLogUpdateInput walletLogsUpdateDto
    )
    {
        try
        {
            await _service.UpdateWalletLog(uniqueId, walletLogsUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a user_ record for WalletLogs
    /// </summary>
    [HttpGet("{Id}/user")]
    public async Task<ActionResult<List<User>>> GetUser(
        [FromRoute()] WalletLogsWhereUniqueInput uniqueId
    )
    {
        var user = await _service.GetUser(uniqueId);
        return Ok(user);
    }
}

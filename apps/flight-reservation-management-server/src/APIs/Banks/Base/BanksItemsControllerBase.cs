using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class BanksControllerBase : ControllerBase
{
    protected readonly IBanksService _service;

    public BanksControllerBase(IBanksService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Banks
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Banks>> CreateBanks(BankCreateInput input)
    {
        var banks = await _service.CreateBanks(input);

        return CreatedAtAction(nameof(Banks), new { id = banks.Id }, banks);
    }

    /// <summary>
    /// Delete one Banks
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteBanks([FromRoute()] BanksWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteBanks(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many BanksItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Banks>>> BanksItems([FromQuery()] BankFindManyArgs filter)
    {
        return Ok(await _service.BanksItems(filter));
    }

    /// <summary>
    /// Meta data about Banks records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> BanksItemsMeta(
        [FromQuery()] BankFindManyArgs filter
    )
    {
        return Ok(await _service.BanksItemsMeta(filter));
    }

    /// <summary>
    /// Get one Banks
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Banks>> Banks([FromRoute()] BanksWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Banks(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Banks
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateBanks(
        [FromRoute()] BanksWhereUniqueInput uniqueId,
        [FromQuery()] BankUpdateInput banksUpdateDto
    )
    {
        try
        {
            await _service.UpdateBanks(uniqueId, banksUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple BankDetailsItems records to Banks
    /// </summary>
    [HttpPost("{Id}/bankDetailsItems")]
    public async Task<ActionResult> ConnectBankDetailsItems(
        [FromRoute()] BanksWhereUniqueInput uniqueId,
        [FromQuery()] BankDetailsWhereUniqueInput[] bankDetailsItemsId
    )
    {
        try
        {
            await _service.ConnectBankDetailsItems(uniqueId, bankDetailsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple BankDetailsItems records from Banks
    /// </summary>
    [HttpDelete("{Id}/bankDetailsItems")]
    public async Task<ActionResult> DisconnectBankDetailsItems(
        [FromRoute()] BanksWhereUniqueInput uniqueId,
        [FromBody()] BankDetailsWhereUniqueInput[] bankDetailsItemsId
    )
    {
        try
        {
            await _service.DisconnectBankDetailsItems(uniqueId, bankDetailsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple BankDetailsItems records for Banks
    /// </summary>
    [HttpGet("{Id}/bankDetailsItems")]
    public async Task<ActionResult<List<BankDetails>>> FindBankDetailsItems(
        [FromRoute()] BanksWhereUniqueInput uniqueId,
        [FromQuery()] BankDetailFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindBankDetailsItems(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple BankDetailsItems records for Banks
    /// </summary>
    [HttpPatch("{Id}/bankDetailsItems")]
    public async Task<ActionResult> UpdateBankDetailsItems(
        [FromRoute()] BanksWhereUniqueInput uniqueId,
        [FromBody()] BankDetailsWhereUniqueInput[] bankDetailsItemsId
    )
    {
        try
        {
            await _service.UpdateBankDetailsItems(uniqueId, bankDetailsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}

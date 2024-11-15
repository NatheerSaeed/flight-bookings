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
    public async Task<ActionResult<Banks>> CreateBank(BankCreateInput input)
    {
        var banks = await _service.CreateBank(input);

        return CreatedAtAction(nameof(Banks), new { id = banks.Id }, banks);
    }

    /// <summary>
    /// Delete one Banks
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteBank([FromRoute()] BanksWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteBank(uniqueId);
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
    public async Task<ActionResult<List<Banks>>> BanksSearchAsync([FromQuery()] BankFindManyArgs filter)
    {
        return Ok(await _service.BanksSearchAsync(filter));
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
    public async Task<ActionResult> UpdateBank(
        [FromRoute()] BanksWhereUniqueInput uniqueId,
        [FromQuery()] BankUpdateInput banksUpdateDto
    )
    {
        try
        {
            await _service.UpdateBank(uniqueId, banksUpdateDto);
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
    public async Task<ActionResult> ConnectBankDetailsSearchAsync(
        [FromRoute()] BanksWhereUniqueInput uniqueId,
        [FromQuery()] BankDetailsWhereUniqueInput[] bankDetailsItemsId
    )
    {
        try
        {
            await _service.ConnectBankDetailsSearchAsync(uniqueId, bankDetailsItemsId);
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
    public async Task<ActionResult> DisconnectBankDetailsSearchAsync(
        [FromRoute()] BanksWhereUniqueInput uniqueId,
        [FromBody()] BankDetailsWhereUniqueInput[] bankDetailsItemsId
    )
    {
        try
        {
            await _service.DisconnectBankDetailsSearchAsync(uniqueId, bankDetailsItemsId);
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
    public async Task<ActionResult<List<BankDetails>>> FindBankDetailsSearchAsync(
        [FromRoute()] BanksWhereUniqueInput uniqueId,
        [FromQuery()] BankDetailFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindBankDetailsSearchAsync(uniqueId, filter));
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
    public async Task<ActionResult> UpdateBankDetailsItem(
        [FromRoute()] BanksWhereUniqueInput uniqueId,
        [FromBody()] BankDetailsWhereUniqueInput[] bankDetailsItemsId
    )
    {
        try
        {
            await _service.UpdateBankDetailsItem(uniqueId, bankDetailsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}

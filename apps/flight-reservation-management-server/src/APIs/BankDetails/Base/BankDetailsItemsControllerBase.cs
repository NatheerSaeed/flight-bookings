using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class BankDetailsControllerBase : ControllerBase
{
    protected readonly IBankDetailsService _service;

    public BankDetailsControllerBase(IBankDetailsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one BankDetails
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<BankDetails>> CreateBankDetail(BankDetailCreateInput input)
    {
        var bankDetails = await _service.CreateBankDetail(input);

        return CreatedAtAction(nameof(BankDetails), new { id = bankDetails.Id }, bankDetails);
    }

    /// <summary>
    /// Delete one BankDetails
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteBankDetail(
        [FromRoute()] BankDetailsWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteBankDetail(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many BankDetailsItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<BankDetails>>> BankDetailsSearchAsync(
        [FromQuery()] BankDetailFindManyArgs filter
    )
    {
        return Ok(await _service.BankDetailsSearchAsync(filter));
    }

    /// <summary>
    /// Meta data about BankDetails records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> BankDetailsItemsMeta(
        [FromQuery()] BankDetailFindManyArgs filter
    )
    {
        return Ok(await _service.BankDetailsItemsMeta(filter));
    }

    /// <summary>
    /// Get one BankDetails
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<BankDetails>> BankDetails(
        [FromRoute()] BankDetailsWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.BankDetails(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one BankDetails
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateBankDetail(
        [FromRoute()] BankDetailsWhereUniqueInput uniqueId,
        [FromQuery()] BankDetailUpdateInput bankDetailsUpdateDto
    )
    {
        try
        {
            await _service.UpdateBankDetail(uniqueId, bankDetailsUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a bank_ record for BankDetails
    /// </summary>
    [HttpGet("{Id}/bank")]
    public async Task<ActionResult<List<Banks>>> GetBank(
        [FromRoute()] BankDetailsWhereUniqueInput uniqueId
    )
    {
        var banks = await _service.GetBank(uniqueId);
        return Ok(banks);
    }
}

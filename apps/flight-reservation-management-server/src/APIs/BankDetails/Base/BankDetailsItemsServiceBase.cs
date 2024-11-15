using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class BankDetailsServiceBase : IBankDetailsService
{
    protected readonly FlightReservationManagementDbContext _context;

    public BankDetailsServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one BankDetails
    /// </summary>
    public async Task<BankDetails> CreateBankDetail(BankDetailCreateInput inputDto)
    {
        var bankDetails = new BankDetail
        {
            AccountName = inputDto.AccountName,
            AccountNumber = inputDto.AccountNumber,
            BankBranch = inputDto.BankBranch,
            CreatedAt = inputDto.CreatedAt,
            IfscCode = inputDto.IfscCode,
            Pan = inputDto.Pan,
            Status = inputDto.Status,
            UpdatedAt = inputDto.UpdatedAt
        };

        if (inputDto.Id != null)
        {
            bankDetails.Id = inputDto.Id;
        }
        if (inputDto.Bank != null)
        {
            bankDetails.Bank = await _context
                .BanksItems.Where(banks => inputDto.Bank.Id == banks.Id)
                .FirstOrDefaultAsync();
        }

        _context.BankDetailsItems.Add(bankDetails);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<BankDetail>(bankDetails.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one BankDetails
    /// </summary>
    public async Task DeleteBankDetail(BankDetailsWhereUniqueInput uniqueId)
    {
        var bankDetails = await _context.BankDetailsItems.FindAsync(uniqueId.Id);
        if (bankDetails == null)
        {
            throw new NotFoundException();
        }

        _context.BankDetailsItems.Remove(bankDetails);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many BankDetailsItems
    /// </summary>
    public async Task<List<BankDetails>> BankDetailsItems(BankDetailFindManyArgs findManyArgs)
    {
        var bankDetailsItems = await _context
            .BankDetailsItems.Include(x => x.Bank)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return bankDetailsItems.ConvertAll(bankDetails => bankDetails.ToDto());
    }

    /// <summary>
    /// Meta data about BankDetails records
    /// </summary>
    public async Task<MetadataDto> BankDetailsItemsMeta(BankDetailFindManyArgs findManyArgs)
    {
        var count = await _context.BankDetailsItems.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one BankDetails
    /// </summary>
    public async Task<BankDetails> BankDetails(BankDetailsWhereUniqueInput uniqueId)
    {
        var bankDetailsItems = await this.BankDetailsItems(
            new BankDetailFindManyArgs { Where = new BankDetailWhereInput { Id = uniqueId.Id } }
        );
        var bankDetails = bankDetailsItems.FirstOrDefault();
        if (bankDetails == null)
        {
            throw new NotFoundException();
        }

        return bankDetails;
    }

    /// <summary>
    /// Update one BankDetails
    /// </summary>
    public async Task UpdateBankDetail(
        BankDetailsWhereUniqueInput uniqueId,
        BankDetailUpdateInput updateDto
    )
    {
        var bankDetails = updateDto.ToModel(uniqueId);

        if (updateDto.Bank != null)
        {
            bankDetails.Bank = await _context
                .BanksItems.Where(banks => updateDto.Bank == banks.Id)
                .FirstOrDefaultAsync();
        }

        _context.Entry(bankDetails).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.BankDetailsItems.Any(e => e.Id == bankDetails.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }

    /// <summary>
    /// Get a bank_ record for BankDetails
    /// </summary>
    public async Task<Banks> GetBank(BankDetailsWhereUniqueInput uniqueId)
    {
        var bankDetails = await _context
            .BankDetailsItems.Where(bankDetails => bankDetails.Id == uniqueId.Id)
            .Include(bankDetails => bankDetails.Bank)
            .FirstOrDefaultAsync();
        if (bankDetails == null)
        {
            throw new NotFoundException();
        }
        return bankDetails.Bank.ToDto();
    }
}

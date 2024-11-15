using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class BanksServiceBase : IBanksService
{
    protected readonly FlightReservationManagementDbContext _context;

    public BanksServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Banks
    /// </summary>
    public async Task<Banks> CreateBank(BankCreateInput inputDto)
    {
        var banks = new Bank
        {
            CreatedAt = inputDto.CreatedAt,
            Name = inputDto.Name,
            UpdatedAt = inputDto.UpdatedAt
        };

        if (inputDto.Id != null)
        {
            banks.Id = inputDto.Id;
        }
        if (inputDto.BankDetailsItems != null)
        {
            banks.BankDetailsItems = await _context
                .BankDetailsItems.Where(bankDetails =>
                    inputDto.BankDetailsItems.Select(t => t.Id).Contains(bankDetails.Id)
                )
                .ToListAsync();
        }

        _context.BanksItems.Add(banks);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<Bank>(banks.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Banks
    /// </summary>
    public async Task DeleteBank(BanksWhereUniqueInput uniqueId)
    {
        var banks = await _context.BanksItems.FindAsync(uniqueId.Id);
        if (banks == null)
        {
            throw new NotFoundException();
        }

        _context.BanksItems.Remove(banks);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many BanksItems
    /// </summary>
    public async Task<List<Banks>> BanksItems(BankFindManyArgs findManyArgs)
    {
        var banksItems = await _context
            .BanksItems.Include(x => x.BankDetailsItems)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return banksItems.ConvertAll(banks => banks.ToDto());
    }

    /// <summary>
    /// Meta data about Banks records
    /// </summary>
    public async Task<MetadataDto> BanksItemsMeta(BankFindManyArgs findManyArgs)
    {
        var count = await _context.BanksItems.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Banks
    /// </summary>
    public async Task<Banks> Banks(BanksWhereUniqueInput uniqueId)
    {
        var banksItems = await this.BanksItems(
            new BankFindManyArgs { Where = new BankWhereInput { Id = uniqueId.Id } }
        );
        var banks = banksItems.FirstOrDefault();
        if (banks == null)
        {
            throw new NotFoundException();
        }

        return banks;
    }

    /// <summary>
    /// Update one Banks
    /// </summary>
    public async Task UpdateBank(BanksWhereUniqueInput uniqueId, BankUpdateInput updateDto)
    {
        var banks = updateDto.ToModel(uniqueId);

        if (updateDto.BankDetailsItems != null)
        {
            banks.BankDetailsItems = await _context
                .BankDetailsItems.Where(bankDetails =>
                    updateDto.BankDetailsItems.Select(t => t).Contains(bankDetails.Id)
                )
                .ToListAsync();
        }

        _context.Entry(banks).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.BanksItems.Any(e => e.Id == banks.Id))
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
    /// Connect multiple BankDetailsItems records to Banks
    /// </summary>
    public async Task ConnectBankDetailsItems(
        BanksWhereUniqueInput uniqueId,
        BankDetailsWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .BanksItems.Include(x => x.BankDetailsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .BankDetailsItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.BankDetailsItems);

        foreach (var child in childrenToConnect)
        {
            parent.BankDetailsItems.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple BankDetailsItems records from Banks
    /// </summary>
    public async Task DisconnectBankDetailsItems(
        BanksWhereUniqueInput uniqueId,
        BankDetailsWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .BanksItems.Include(x => x.BankDetailsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .BankDetailsItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.BankDetailsItems?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple BankDetailsItems records for Banks
    /// </summary>
    public async Task<List<BankDetails>> FindBankDetailsItems(
        BanksWhereUniqueInput uniqueId,
        BankDetailFindManyArgs bankFindManyArgs
    )
    {
        var bankDetailsItems = await _context
            .BankDetailsItems.Where(m => m.BankId == uniqueId.Id)
            .ApplyWhere(bankFindManyArgs.Where)
            .ApplySkip(bankFindManyArgs.Skip)
            .ApplyTake(bankFindManyArgs.Take)
            .ApplyOrderBy(bankFindManyArgs.SortBy)
            .ToListAsync();

        return bankDetailsItems.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple BankDetailsItems records for Banks
    /// </summary>
    public async Task UpdateBankDetailsItem(
        BanksWhereUniqueInput uniqueId,
        BankDetailsWhereUniqueInput[] childrenIds
    )
    {
        var banks = await _context
            .BanksItems.Include(t => t.BankDetailsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (banks == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .BankDetailsItems.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        banks.BankDetailsItems = children;
        await _context.SaveChangesAsync();
    }
}

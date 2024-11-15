using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class BankPaymentsItemsServiceBase : IBankPaymentsItemsService
{
    protected readonly FlightReservationManagementDbContext _context;

    public BankPaymentsItemsServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one BankPayments
    /// </summary>
    public async Task<BankPayments> CreateBankPayments(BankPaymentsCreateInput createDto)
    {
        var bankPayments = new BankPaymentsDbModel
        {
            Amount = createDto.Amount,
            BankDetailId = createDto.BankDetailId,
            BookingReference = createDto.BookingReference,
            CreatedAt = createDto.CreatedAt,
            Reference = createDto.Reference,
            SlipPhoto = createDto.SlipPhoto,
            Status = createDto.Status,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            bankPayments.Id = createDto.Id;
        }
        if (createDto.User != null)
        {
            bankPayments.User = await _context
                .Users.Where(user => createDto.User.Id == user.Id)
                .FirstOrDefaultAsync();
        }

        _context.BankPaymentsItems.Add(bankPayments);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<BankPaymentsDbModel>(bankPayments.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one BankPayments
    /// </summary>
    public async Task DeleteBankPayments(BankPaymentsWhereUniqueInput uniqueId)
    {
        var bankPayments = await _context.BankPaymentsItems.FindAsync(uniqueId.Id);
        if (bankPayments == null)
        {
            throw new NotFoundException();
        }

        _context.BankPaymentsItems.Remove(bankPayments);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many BankPaymentsItems
    /// </summary>
    public async Task<List<BankPayments>> BankPaymentsItems(BankPaymentsFindManyArgs findManyArgs)
    {
        var bankPaymentsItems = await _context
            .BankPaymentsItems.Include(x => x.User)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return bankPaymentsItems.ConvertAll(bankPayments => bankPayments.ToDto());
    }

    /// <summary>
    /// Meta data about BankPayments records
    /// </summary>
    public async Task<MetadataDto> BankPaymentsItemsMeta(BankPaymentsFindManyArgs findManyArgs)
    {
        var count = await _context.BankPaymentsItems.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one BankPayments
    /// </summary>
    public async Task<BankPayments> BankPayments(BankPaymentsWhereUniqueInput uniqueId)
    {
        var bankPaymentsItems = await this.BankPaymentsItems(
            new BankPaymentsFindManyArgs { Where = new BankPaymentsWhereInput { Id = uniqueId.Id } }
        );
        var bankPayments = bankPaymentsItems.FirstOrDefault();
        if (bankPayments == null)
        {
            throw new NotFoundException();
        }

        return bankPayments;
    }

    /// <summary>
    /// Update one BankPayments
    /// </summary>
    public async Task UpdateBankPayments(
        BankPaymentsWhereUniqueInput uniqueId,
        BankPaymentsUpdateInput updateDto
    )
    {
        var bankPayments = updateDto.ToModel(uniqueId);

        if (updateDto.User != null)
        {
            bankPayments.User = await _context
                .Users.Where(user => updateDto.User == user.Id)
                .FirstOrDefaultAsync();
        }

        _context.Entry(bankPayments).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.BankPaymentsItems.Any(e => e.Id == bankPayments.Id))
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
    /// Get a user_ record for BankPayments
    /// </summary>
    public async Task<User> GetUser(BankPaymentsWhereUniqueInput uniqueId)
    {
        var bankPayments = await _context
            .BankPaymentsItems.Where(bankPayments => bankPayments.Id == uniqueId.Id)
            .Include(bankPayments => bankPayments.User)
            .FirstOrDefaultAsync();
        if (bankPayments == null)
        {
            throw new NotFoundException();
        }
        return bankPayments.User.ToDto();
    }
}
